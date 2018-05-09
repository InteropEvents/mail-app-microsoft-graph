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
    }
})

var params;
var onPanelLoad = {};



$(function () {
    var menus = $(".menu").find(".category");

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

        if (location.hash && location.hash.length > 1) {

            var hash = params.hash.replace(/%20/g, " ");
            onPanelLoad[hash]();
            $(document.getElementById(hash)).show();

            sample.removeClass("hidden");
            sample.removeClass("slideOut");
            sample.addClass("slideIn");

            title.html(hash);

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

function log(that) {
    var footer = $(".footer");
    var response = $("#response", footer),
        request = $("#request", footer),
        codeSituation = $("#codeSituation", footer);

    request.html("<span class='caption'>endpoint:</span>"),
        response.html("<span class='caption'>response:</span>"),
        codeSituation.html("<span class='caption'>code location:</span>");

    if (that) {
        if (that.url) request.html(that.method + " " + that.url);
        if (that.codeSituation) codeSituation.html(that.codeSituation);
        if (that.res) response.html(JSON.stringify(that.res, null, 4));
    }
}