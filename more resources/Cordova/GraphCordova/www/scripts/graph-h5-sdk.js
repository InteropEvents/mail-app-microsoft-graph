// require cordova.oauth2.js
// require jquery
function codeRowNum(depth) {
    if (!depth)
        depth = 1;
    try {
        throw new Error();
    } catch (e) {
        var stack = e.stack.substring(5).replace(/[\r\n]/i, "").split(/[\r\n]/g);
        var codeRow = stack[depth];
        return codeRow.substring(codeRow.lastIndexOf("/") + 1, codeRow.lastIndexOf(":"));
    }
}


$.hashParam = function (hashstr) {
    var hash = hashstr.split("&");
    var params = {}
    for (var i = 0; i < hash.length; i++) {
        var split = hash[i].indexOf("=");
        params[hash[i].substring(0, split)] = hash[i].substring(split + 1);
    }
    return params;
}

$.graph = function (setting, relogin) {
    this.setting = setting;
    this.endpoint = "https://graph.microsoft.com/";
    this.edition = "v1.0";
    that = this;

    if (!relogin) {

        if (setting.response_type === "token" && window.location.hash && window.location.hash.indexOf("access_token") >= 0) {
            this.login(location.hash.substring(location.hash.indexOf("=") + 1, location.hash.indexOf("&")), $.hashParam(location.hash.substring(1)))
            location.hash = "";
            return;
        }

        if (window.sessionStorage.token) {
            this.login(window.sessionStorage.token, JSON.parse(window.sessionStorage.authorization));
            return;
        }

    }

    if (relogin)
        $.oauth2(this.setting, this.login.bind(this)
            , function (error, response) {
                throw error;
            });
}

$.graph.prototype.login = function (token, authorization) {
    this.token = window.sessionStorage.token = token;
    this.authorization = authorization;
    window.sessionStorage.authorization = JSON.stringify(authorization);
    setTimeout(this.refreshToken.bind(this), 500000)//refresh interval
    setTimeout(GetMyProfile, 0, true)
}

$.graph.prototype.refreshToken = function () {

    var that = this;
    switch (this.setting.response_type) {
        case "token":
            var params = {
                client_id: this.setting.client_id,
                prompt: "none",
                scope: this.setting.other_params.scope,
                redirect_uri: this.setting.redirect_uri,
                response_type: this.setting.response_type,
            }
            this.GetUser().then(function (me) {
                params.login_hint = me.res.userPrincipalName;
                var iframe = $("<iframe>").hide().attr("src", this.setting.auth_url + "?" + $.param(params));
                $("body").append(iframe);
                $(iframe).on("load", function (e) {
                    var sessionStorage = e.currentTarget.contentWindow.sessionStorage;
                    that.login(sessionStorage.token, JSON.parse(sessionStorage.authorization))
                    $(this).remove();
                })
            }.bind(this))

            break;
        case "code":
            if (!(this.authorization && this.authorization.refresh_token))
                throw "no authorization or refresh_token set";

            var params = {
                client_id: this.setting.client_id,
                redirect_uri: this.setting.redirect_uri,
                grant_type: "refresh_token",
                refresh_token: this.authorization.refresh_token
            }
            // var url = $.param(params);
            $.ajax({
                url: this.setting.token_url,
                data: params,
                type: 'POST',
                success: function (res) {
                    that.login(res.access_token, res);
                },
                error: function (err) {
                    console.error("refreshToken failed");
                    console.error(err);
                }
            })
            break;

        default:
            throw "unknown refresh mothed";
            break;
    }
}

!function () {
    function request(url, data, method) {
        var that = this;
        var stack = codeRowNum(3);

        if (!method && typeof data === "string")
            method = data, data = null;

        url = this.endpoint + this.edition + url;

        var promise = new Promise(function (resolve, reject) {
            var option = {
                url: url,
                headers: {
                    'Authorization': 'Bearer ' + that.token,
                    "Content-Type": "application/json",
                    "Prefer": 'outlook.timezone="' + Date.timeZone + '"'
                },
                method: method,
                success: function (res) {
                    this.res = this.response = res;
                    this.status = "success";
                    resolve(this);
                },
                error: function (res) {
                    this.res = this.response = res;
                    this.status = "error";
                    reject(this);
                }
            };
            option.context = {
                url: option.url,
                method: option.method,
                codeSituation: stack,
                data: {}
            }
            if (data) {
                option.data = data;
                option.context.data = option.data;
            }
            $.ajax(option);
        })
        promise.catch(function (ajax) {
            var err = ajax.res;
            console.info(err.status + " " + err.statusText)
            console.info(err.responseText)
            alert(err.responseText);
        });
        return promise;
    }

    $.post = function post(url, data) {
        if (typeof data === "object")//used to crossDomain
            data = JSON.stringify(data);
        return request.call(this, url, data, "POST");
    }

    $.get = function get(url, data) {
        return request.call(this, url, data, "GET");
    }

    $.patch = function patch(url, data) {
        if (typeof data === "object")//used to crossDomain
            data = JSON.stringify(data);
        return request.call(this, url, data, "PATCH");
    }

    $.del = function del(url, data) {
        if (typeof data === "object")//used to crossDomain
            data = JSON.stringify(data);
        return request.call(this, url, data, "DELETE");
    }

    var graph = {
        GetUser: function () {
            //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_get
            return $.get.call(this, "/me");
        },
        // /*
        //      Mail Scenario
        // */
        // CreateMessage: function (data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_messages
        //     return post.call(this, "/me/messages", data);
        // },
        // //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_sendmail
        // SendMail: function (data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_sendmail
        //     return post.call(this, "/me/sendMail", data);
        // },
        // DeleteMessage: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_delete
        //     return del.call(this, "/me/messages/" + id);
        // },
        // Listmessages: function (folderId, keyword) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_messages
        //     var data;
        //     if (keyword) {
        //         data = {
        //             "$search": '"' + keyword + '"'
        //         };
        //     }
        //     if (folderId)
        //         return get.call(this, "/me/mailFolders/" + folderId + "/messages", data);
        //     else
        //         return get.call(this, "/me/mailFolders/Inbox/messages", data);
        // },
        // Getmessage: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_get
        //     return get.call(this, "/me/messages/" + id);
        // },
        // Updatemessage: function (id, data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_update
        //     return patch.call(this, "/me/messages/" + id, data)
        // },
        // CreateMailFolder: function (foldername) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_mailfolders
        //     return post.call(this, "/me/mailFolders", { displayName: foldername })
        // },
        // //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/mailfolder_delete
        // DeletemailFolder: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/mailfolder_delete
        //     return del.call(this, "/me/mailFolders/" + id);
        // },
        // Movemessage: function (id, DestinationId) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_move
        //     return post.call(this, "/me/messages/" + id + "/move", { DestinationId: DestinationId })
        // },
        // Copymessage: function (id, DestinationId) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_copy
        //     return post.call(this, "/me/messages/" + id + "/copy", { DestinationId: DestinationId });
        // },
        // //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_mailfolders
        // ListmailFolders: function () {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_mailfolders
        //     return get.call(this, "/me/mailFolders");
        // },
        /*
           Calendar Scenario
        */
        // CreateCalendar: function (id, data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_calendars
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendargroup_post_calendars
        //     if (id)
        //         return post.call(this, "/me/calendarGroups/" + id + "/calendars", data);
        //     else
        //         return post.call(this, "/me/calendars", data);
        // },
        // ListCalendars: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_calendars
        //     if (id)
        //         return get.call(this, "/me/calendargroups/" + id + "/calendars");
        //     else
        //         return get.call(this, "/me/calendars");
        // },
        // UpdateCalendars: function (id, data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendar_update
        //     return patch.call(this, "/me/calendars/" + id, data);
        // },
        // DeleteCalendars: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendar_delete
        //     return del.call(this, "/me/calendars/" + id);
        // },
        // GetCalendar: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendar_get
        //     return get.call(this, "/me/calendars/" + id);
        // },
        // CreateCalendarGroup: function (data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_calendargroups
        //     return post.call(this, "/me/calendarGroups", data);
        // },
        // ListCalendarGroups: function () {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_calendargroups
        //     return get.call(this, "/me/calendarGroups");
        // },
        // GetCalendarGroup: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendargroup_get
        //     return get.call(this, "/me/calendarGroups/" + id);
        // },
        // DeleteCalendarGroup: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendargroup_delete
        //     return del.call(this, "/me/calendarGroups/" + id);
        // },
        // /*
        //    Meeting Scenario
        // */
        // CreateEvent: function (data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_events
        //     return post.call(this, "/me/events", data)
        // },
        // ListEvent: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_events
        //     if (id)
        //         return get.call(this, "/me/calendars/" + id + "/events");
        //     else
        //         return get.call(this, "/me/events");
        // },
        // GetEvent: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_get
        //     return get.call(this, "/me/events/" + id);
        // },
        // UpdateEvent: function (id, data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_update
        //     return patch.call(this, "/me/events/" + id, data)
        // },
        // AcceptEvent: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_accept
        //     return post.call(this, "/me/events/" + id + "/accept");
        // },
        // TentativelyAcceptEvent: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_tentativelyaccept
        //     return post.call(this, "/me/events/" + id + "/tentativelyAccept");
        // },
        // DeclineEvent: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_decline
        //     return post.call(this, "/me/events/" + id + "/decline");
        // },
        // DeleteEvent: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_delete
        //     return del.call(this, "/me/events/" + id);
        // },
        // ReminderView: function (start, end) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_reminderview
        //     return get.call(this, "/me/reminderView(startDateTime='" + start + "',endDateTime='" + end + "')");
        // },
        // DismissReminderEvent: function (id) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_dismissreminder
        //     return post.call(this, "/me/events/" + id + "/dismissReminder");
        // },
        // SnoozeReminderEvent: function (id, data) {
        //     //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_snoozereminder
        //     return post.call(this, "/me/events/" + id + "/snoozeReminder", data);
        // },
    }

    $.extend($.graph.prototype, graph);
}()

function GetMyProfile(update) {
    return new Promise(function (resolve, reject) {
        if (!graph.token) {
            resolve();
        } else {
            if (params.storge.me && !update) {
                resolve(JSON.parse(params.storge.me));
            } else {
                graph.GetUser().then(function (that) {
                    render.GetMyProfile(that, false);
                    params.storge.me = JSON.stringify(that.res);
                    resolve(that.res)
                });
            }
        }
    })

}