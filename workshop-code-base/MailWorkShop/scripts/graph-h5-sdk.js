// require cordova.oauth2.js
// require jquery
!function () {
    //get row number and file from stack
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
}()

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


