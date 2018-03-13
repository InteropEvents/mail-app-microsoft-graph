var Graph = function () {
    "use strict";

    var nativeclient_endpoint = "https://login.microsoftonline.com/common/oauth2/nativeclient"
    var authorize_endpoint = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize"

    return Graph = function (setting, mode) {
        this.config = {};
        this.config.setting = setting;
    },
        Graph.prototype.getAuthenticationUrl = function () {
            let setting = this.config.setting;

            var authParams = {
                client_id: setting.appId,
                redirect_uri: setting.redirectUri,
                scope: setting.scopes,
                response_mode: 'fragment',
                response_type: "code"
            };

            return authorize_endpoint + "?" + function (param) {
                var arr = [];
                for (var key in param) {
                    if (param.hasOwnProperty(key)) {
                        var element = param[key];
                        arr.push(`${key}=${encodeURIComponent(element)}`);
                    }
                }
                return arr.join("&");
            }(authParams);
        },
        Graph.prototype.isAuthenticated = function () {
            return (sessionStorage.accessToken != null && sessionStorage.accessToken.length > 0);
        },
        Graph.prototype.codeUrlHandler = function (url) {
            var setting = this.config.setting;
            url = url.split("#")[1];
            var code = parseHashParams(url).code;

            $.ajax({
                method:"post",
                data: {
                    client_id: setting.client_id,
                    scope: setting.scopes,
                    code: code,
                    redirect_uri: nativeclient_endpoint,
                    grant_type: "authorization_code"
                },
                success: function (res) {

                }
            })
            return (sessionStorage.accessToken != null && sessionStorage.accessToken.length > 0);
        },
        Graph.prototype.getAccessToken = function (callback) {
            var now = new Date().getTime();
            var isExpired = now > parseInt(sessionStorage.tokenExpires);
            if (sessionStorage.accessToken && !isExpired) {
                if (callback) {
                    callback(sessionStorage.accessToken);
                }
            } else {
                //refresh token
            }
        },
        Graph;

    function parseHashParams(hash) {
        var params = hash.split('&');

        var paramarray = {};
        params.forEach(function (param) {
            param = param.split('=');
            paramarray[param[0]] = param[1];
        });

        return paramarray;
    }
}()

