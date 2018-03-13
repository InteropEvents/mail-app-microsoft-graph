Date.prototype.toUTCString = function () {

    function zeroCompletion(time) {
        return ("00" + time).slice(-2);
    }
    // 2017 - 04 - 15T12: 00:00
    return this.getFullYear() + "-" +
        zeroCompletion(this.getMonth() + 1) + "-" +
        zeroCompletion(this.getDate()) + "T" +
        zeroCompletion(this.getHours()) + ":" +
        zeroCompletion(this.getMinutes()) + ":" +
        zeroCompletion(this.getSeconds())
}

Object.defineProperty(Date, "timeZone", {
    get: function () {
        var hourOffset = parseInt(new Date().getTimezoneOffset() / 60);

        return "Etc/GMT" +
            (hourOffset > 0 ? "+" + hourOffset :
                hourOffset == 0 ? "" :
                    "-" + Math.abs(hourOffset));
        // return new Date().toString().match(/[^\(\)]+(?=\))/g)[0];
    }
})

$("form").on("reset", function () {
    $(this).find("editor").html("");
});

var params;
var render = function () {

    function format(object) {
        f = {
            brace: 0
        };
        var jsonStr = JSON.stringify(object);
        return jsonStr.replace(/({|}[,]*|[^{}:]+:[^{}:,]*[,{]*)/g, function (m, p1) {
            var rtnFn = function () {
                return '<div style="text-indent: ' + (f['brace'] * 20) + 'px;">' + p1 + '</div>';
            },
                rtnStr = 0;
            if (p1.lastIndexOf('{') === (p1.length - 1)) {
                rtnStr = rtnFn();
                f['brace'] += 1;
            } else if (p1.indexOf('}') === 0) {
                f['brace'] -= 1;
                rtnStr = rtnFn();
            } else {
                rtnStr = rtnFn();
            }
            return rtnStr;
        });
    }

    function log(that) {
        request.html("<span class='caption'>endpoint:</span>"),
            response.html("<span class='caption'>response:</span>"),
            codeSituation.html("<span class='caption'>code location:</span>");

        if (that) {
            if (that.url) request.html(that.method + " " + that.url);
            if (that.codeSituation) codeSituation.html(that.codeSituation);
            if (that.res) response.html(JSON.stringify(that.res, null, 4));
        }
    }

    var footer = $(".footer");
    var response = $("#response", footer),
        request = $("#request", footer),
        codeSituation = $("#codeSituation", footer);

    var map = {
        log: function () { },
        GetMyProfile: function (data) {
            var container = $(".login");
            if (data) {
                container.find("label").text(data.displayName || data.userPrincipalName + "/");
                container.find("a").text("switch user");
            } else {
                container.find("label").text();
                container.find("a").text("login");
            }
        },
        //mail scenario
        CreateMessage: function () {
        },
        Listmessages: function (data) {
            var container = $(document.getElementById("Show Mail List")).children(".container");
            container.html("");
            $.each(data.value, function (index, item) {
                var html = "";
                html += '<a class="link" href="#Show Single Mail?id=' + item.id + '">' +
                    "<div class=\"mail-item\">" +
                    "<p><b>From:</b>" + (item.from ? item.from.emailAddress.name + " " + item.from.emailAddress.address : "") + " " + (item.isRead ? "" : '<span class=\"unread\">(未读)</span>') + "</p>" +
                    "<p><b>Subject:</b>" + item.subject + "</p>" +
                    "<p class=\"content\">" + item.bodyPreview || item.body.content.replace(/<.*?>/ig, "") + "</p>" +
                    "<span class=\"date\">" + item.sentDateTime + "</span>" +
                    '</div>' +
                    "</a>";
                container.append(html);
            });
        },
        ShowSingleMail: function (data) {
            var container = $(document.getElementById("Show Single Mail")).children(".container");
            var head = container.children(".head");
            var content = container.children(".content").find("editor");
            head.html(''), content.html('');

            var toRecipients = data.toRecipients.map(function (item) {
                return item.emailAddress.address + "(" + item.emailAddress.name + ")";
            });

            head.append("<p><b>From</b>:" + (data.from ? data.from.emailAddress.address + "(" + data.from.emailAddress.name + ")" : "") + "</p>");
            head.append("<p><b>Subject</b>:" + data.subject + "</p>");
            head.append("<p><span class=\"date\">" + data.sentDateTime + "</span></p>");

            if (data.body.contentType === "html")
                content.html(data.body.content);
            else
                content.text(data.body.content);
        },
        CreateFolderUnderInbox: function (data) {
            var container = $(document.getElementById("Show Mail Folder")).children(".container");
            var str = '<a href="#Show Mail List?id=' + data.id + '" class="mail-folder">' +
                '<span class="delete" onclick="DeleteFolderUnderInbox(\'' + data.id + '\')">×</span>' +
                '<div>' +
                '<img src="images/folder.png" />' +
                '<span>' + data.displayName + '</span>' +
                '</div>' +
                '</a>'
            container.prepend(str);
        },
        ListmailFolders: function (data) {
            var container = $(document.getElementById("Show Mail Folder")).children(".container");
            container.html("");
            $.each(data.value, function (index, item) {
                var str;
                if (item.displayName.indexOf("example ") < 0)
                    str = '<a href="javascript:" class="mail-folder" style="opacity:0.5;" >' +
                        '<div>' +
                        '<img src="images/folder.png" />' +
                        '<span>' + item.displayName + '</span>' +
                        '</div>' +
                        '</a>'
                else

                    str = '<a href="#Show Mail List?id=' + item.id + '" class="mail-folder">' +
                        '<span class="delete" onclick="DeleteFolderUnderInbox(\'' + item.id + '\')">×</span>' +
                        '<div>' +
                        '<img src="images/folder.png" />' +
                        '<span>' + item.displayName + '</span>' +
                        '</div>' +
                        '</a>'
                container.append(str);
            })
        },
        //calender scenario
        GetCalendarList: function (data) {
            var container = $(document.getElementById("Get Calendar List")).children(".container");
            container.html("");
            $.each(data.value, function (index, item) {
                var str = '<a href="#Get Meeting List?id=' + item.id + '" class="mail-folder">' +
                    (item.name.indexOf("example ") >= 0 ? '<span class="delete" onclick="DeleteCalendar(\'' + item.id + '\')">×</span>' : "") +
                    '<div>' +
                    '<img src="images/calendar.png" />' +
                    '<span>' + item.name + '</span>' +
                    '</div>' +
                    '</a>'
                container.append(str);
            })
        },
        GetOneCalendar: function (data) {
            var panel = $(document.getElementById("Get Meeting List"));
            var name = panel.find("[name=name]");
            if (data) {
                name.text(data.name);
                if (data.name.indexOf("example ") >= 0) {
                    panel.find("[name=update]").removeAttr("disabled")
                }
            } else {
                name.text("");
            }
        },
        GetCalendarGroupList: function (data) {
            var container = $(document.getElementById("Get Calendar Group List")).children(".container");
            container.html("");
            $.each(data.value, function (index, item) {
                var str = '<a href="#Get Calendar List?id=' + item.id + '" class="mail-folder">' +
                    (item.name.indexOf("example ") >= 0 ? '<span class="delete" onclick="DeleteCalendarGroup(\'' + item.id + '\')">×</span>' : "") +
                    '<div>' +
                    '<img src="images/calendar_group.png" />' +
                    '<span>' + item.name + '</span>' +
                    '</div>' +
                    '</a>'
                container.append(str);
            })
        },
        GetOneCalendarGroup: function (data) {
            var panel = $(document.getElementById("Get Calendar List"));
            var name = panel.find("[name=name]").text(data.name);
        },
        //meeting scenario
        GetMeetingList: function (data) {
            var container = $(document.getElementById("Get Meeting List")).children(".container").html("");
            $.each(data.value, function (index, item) {
                var html;

                if (item.eventId)
                    html = '<a class="link" href="#Get One Meeting?id=' + item.eventId + '">' +
                        "<div class=\"mail-item\">" +
                        "<p><b>Subject:</b>" + item.eventSubject + "</p>" +
                        "<p><b>Location:</b>" + item.eventLocation.displayName + "</p>" +
                        "<p><b>FireTime:</b>" + item.reminderFireTime.dateTime.substring(0, 19) + "</p>" +
                        "<p><b>StartTime:</b>" + item.eventStartTime.dateTime.substring(0, 19) + "</p>" +
                        '</div>' +
                        "</a>";
                else
                    html = '<a class="link" href="#Get One Meeting?id=' + item.id + '">' +
                        "<div class=\"mail-item\">" +
                        // (!item.isCancelled && item.isReminderOn ? "<span class='remind'>remind</span>" : "") +
                        "<p><b>Sender:</b>" + item.organizer.emailAddress.name + " " + item.organizer.emailAddress.address + "</p>" +
                        "<p><b>Subject:</b>" + item.subject + "</p>" +
                        "<p class=\"content\">" + (item.bodyPreview || item.body.content.replace(/<.*?>/ig, "")) + "</p>" +
                        "<span class=\"date\">" + item.start.dateTime.substring(0, 19) + "</span>" +
                        '</div>' +
                        "</a>";

                container.append(html);
            });
        },
        GetOneMeeting: function (data) {
            var container = $(document.getElementById("Get One Meeting"));
            var form = container.find("form").get(0);
            var content = container.find("editor");

            var btns = container.find(".top input");
            if (data.isOrganizer) {
                btns.slice(0, 3).hide();
                btns.eq(3).attr("class", "input1 last first");
            } else {
                btns.slice(0, 3).show();
                btns.eq(3).attr("class", "input4 last");
            }
            form.reset(), content.html('');

            form.organizer.value = data.organizer.emailAddress.name + " " + data.organizer.emailAddress.address
            form.attendee.value = data.attendees[0] ? data.attendees[0].emailAddress.name + " " + data.attendees[0].emailAddress.address : "";
            form.start.value = data.start.dateTime;
            form.end.value = data.end.dateTime;
            form.location.value = data.location.displayName;
            form.subject.value = data.subject;

            if (data.body.contentType === "html")
                content.html(data.body.content);
            else
                content.text(data.body.content);
        },
        //contact scenario
        GetContactList: function (data) {
            var container = $(document.getElementById("Contact List")).children(".container");
            container.html("");
            $.each(data.value, function (index, item) {
                var html =
                    '<a class="link" href="#Show Single Contact?id=' + item.id + '">' +
                    "<div class=\"mail-item\">" +
                    "<p><b>DisplayName:</b>" + item.displayName + "</p>" +
                    "<p><b>EmailAddresses:</b>" + (item.emailAddresses[0] ? item.emailAddresses[0].address : "-") + "</p>" +
                    '</div>' +
                    "</a>";
                container.append(html);
            });
        },
        GetOneContact: function (data) {
            var container = $(document.getElementById("Show Single Contact"));
            var form = container.find("form").get(0);

            form.givenName.value = data.givenName;
            form.surname.value = data.surname;
            form.email.value = data.emailAddresses[0] ?
                data.emailAddresses[0].address : "";
            form.mobilePhone.value = data.mobilePhone;
            form.birthday.value = data.birthday;
            form.businessPhones.value = data.businessPhones;
            form.companyName.value = data.companyName;
        },

        chooseFolder: function () {
            var container = $(document.getElementById("Show Single Mail")).find(".chooseFolder .folderBox");
            container.html("");
            container.append($("<p>").html("No Data"))

            new Promise(function (resolve, reject) {
                if (params.storge.mailFolders) {
                    var data = JSON.parse(params.storge.mailFolders);
                    render.log({
                        method: "local",
                        url: "storge",
                        codeSituation: codeRowNum(),
                        res: data
                    });
                    resolve(data)
                }
                else {
                    ListmailFolders().then(resolve);
                }
            }).then(function (data) {
                data = data.res.value;
                if (data && data.length) {
                    container.html("");
                    $.each(data, function (index, item) {
                        container.append("<p onclick='chooseFolder(\"" + item.id + "\")'>" + item.displayName + "</p>")
                    })
                }
            });

        },
    }

    return function () {
        var handle = {};

        for (var pi in map) {
            handle[pi] = push(map[pi], pi);
        }

        function push(func, pi) {
            // var container = $(document.getElementById(pi)).children(".container");
            return function (that, autoLog) {
                if (autoLog || typeof autoLog != "boolean")
                    log(that);
                if (!that) that = {};
                return func.call(that, that.res);
            }
        }

        return handle;
    }();
}()

$(function () {
    var menus = $(".menu").find(".category");
    var map = {
        //mail
        "Show Mail Folder": ListmailFolders,
        "Show Mail List": ShowMailList,
        "Show Single Mail": ShowSingleMail,
        "Show Mail List": ShowMailList,
        "Send Mail": function () {
            var panel = $(document.getElementById("Send Mail"));
            var head = panel.find(".head");
            var content = panel.find(".content").find("editor").html("");
            var form = panel.find("form").get(0);
            form.reset();

            GetMyProfile().then(function (me) {
                var date = new Date();
                var a = {
                    "message": {
                        "subject": "Hello " + me.displayName,
                        "body": {
                            "contentType": "Text",
                            "content": "Congratulation！Your mail was created successfully."
                        },
                        "toRecipients": [
                            {
                                "emailAddress": {
                                    "address": me.mail
                                }
                            }
                        ],
                    },
                }

                form.address.value = me.mail || me.userPrincipalName;
                form.subject.value = "Hello " + me.displayName;
                content.html("Congratulation！Your mail was created successfully.");
            })
        },
        //calender
        "Get Calendar List": function () {
            var panel = $(document.getElementById("Get Calendar List"));
            var name = panel.find("[name=name]").text("loading");
            GetOneCalendarGroup();
            GetCalendarList();
        },
        "Get One Calendar": GetOneCalendar,
        "Create Calendar Group": function () {
        },
        "Get Calendar Group List": GetCalendarGroupList,
        "Get One Calendar Group": GetOneCalendarGroup,
        //meeting
        "Create Meeting": function () {
            var panel = $(document.getElementById("Create Meeting"));
            var form = panel.find("form"), content = panel.find(".content editor").html("");

            form.get(0).reset();

            GetMyProfile().then(function (me) {
                var date = new Date();

                date.setUTCHours(date.getUTCHours() + 1);
                var starttime = date.toUTCString();
                date.setUTCHours(date.getUTCHours() + 1);
                var endtime = date.toUTCString();

                form.get(0).subject.value = "Let us have a meeting " + me.displayName;
                form.get(0).attendees.value = me.mail || me.userPrincipalName;
                form.get(0).location.value = "Meeting room 001";
                form.get(0).start.value = starttime;
                form.get(0).end.value = endtime;

                content.html("The meeting will begin at " + starttime + " and ending at " + endtime + ".");
            })
        },
        "Get Meeting List": function () {
            var panel = $(document.getElementById("Get Meeting List"));
            var update = panel.find("[name=update]").attr("disabled", "disabled");
            var name = panel.find("[name=name]").text("loading");
            GetOneCalendar();
            GetInMeetingList();
        },
        "Get One Meeting": GetOneMeeting,
        //conact
        "Contact List": ShowContactList,
        "Show Single Contact": ShowSingleContact,
    };

    menus.find("a").each(function () {
        var $this = $(this);
        $this.attr("href", "#" + $this.find("p").text());
    })
    menus.find(".categoryHead").click(function () {
        var parent = $(this).parent();
        if (parent.hasClass("show")) {
            parent.removeClass("show");
        } else {
            menus.removeClass("show");
            parent.addClass("show");
        }
    })

    var sample = $("#sample");
    var title = $("#title");
    var sheets = sample.children(".sheet");

    var footer = $(".footer");
    var response = $("#response", footer),
        request = $("#request", footer),
        codeSituation = $("#codeSituation", footer);

    function reParams() {
        var storge = params ? params.storge || {} : {};
        params = { storge: storge };
        if (window.location.hash && window.location.hash.length > 1) {
            var hash = window.location.hash.split("?");
            var operation = hash[0].substring(1);
            if (hash[1]) {
                $.extend(params, $.hashParam(hash[1]));
            }
            params.hash = operation;
        }
    }

    window.addEventListener("hashchange", function () {
        if (location.hash && location.hash.indexOf("access_token") >= 0) {
            return login();
        }
        reParams();
        sheets.hide();

        request.html(""), response.html(""), codeSituation.html("");//clear log console

        $(document.getElementById(params.hash)).show();

        if (map[params.hash]) {
            map[params.hash]();
        }

        if (location.hash && location.hash.length > 1) {

            sample.removeClass("hidden");
            sample.removeClass("slideOut");
            sample.addClass("slideIn");

            title.html(params.hash);

        } else {
            sample.removeClass("slideIn");
            sample.addClass("slideOut");
        }
    }, false)

    sample.on("animationend", function () {
        if ($(this).hasClass("slideOut"))
            $(this).addClass("hidden");
    })

    //trigger the event named hashchange
    var e = window.document.createEvent("HTMLEvents");
    e.initEvent("hashchange", true, false);
    window.dispatchEvent(e);

})
