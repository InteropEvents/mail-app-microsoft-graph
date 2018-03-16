/*
  Mail Scenario
*/
onPanelLoad["Show Mail List"] = ShowMailList;
onPanelLoad["Create Mail"] = CreateMail;

$.graph.prototype.GetUser = function () {
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_get
    return $.get.call(this, "/me");
},

$.graph.prototype.SendMail = function (data) {
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_sendmail
    return $.post.call(this, "/me/sendMail", data);
},
    $.graph.prototype.Listmessages = function () {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_messages
        return $.get.call(this, "/me/mailFolders/Inbox/messages");
    };


function CreateMail() {
    var panel = $(document.getElementById("Create Mail"));
    var head = panel.find(".head");
    var content = panel.find(".content").find("editor").html("");
    var form = panel.find("form").get(0);
    form.reset();

    GetMyProfile().then(function (me) {
        var date = new Date();
        form.address.value = "jnlxu@microsoft.com"
        form.subject.value = "O365 DevDays Beijing 2018: Build the mail App";
        content.html("I built the mail App to send mail in O365 DevDays Beijing 2018 - Hello from " + me.displayName);
    })
}

function GetMyProfile(update) {
    return graph.GetUser().then(function (that) {
        var data = that.res;

        var container = $(".login");
        if (data) {
            container.find("label").text(data.displayName || data.userPrincipalName + "/");
            container.find("a").text("switch user");
        } else {
            container.find("label").text();
            container.find("a").text("login");
        }

       return data;
    });
}

function ShowMailList() {

    var container = $(document.getElementById("Show Mail List")).children(".container");
    container.html("");

    graph.Listmessages().then(function (that) {
        //render
        var data = that.res;
        $.each(data.value, function (index, item) {
            var html = "";
            html += '<a class="link" href="javascript:void(0)">' +
                "<div class=\"mail-item\">" +
                "<p><b>From:</b>" + (item.from ? item.from.emailAddress.name + " " + item.from.emailAddress.address : "") + " " + (item.isRead ? "" : '<span class=\"unread\">(unread)</span>') + "</p>" +
                "<p><b>Subject:</b>" + item.subject + "</p>" +
                "<p class=\"content\">" + item.bodyPreview || item.body.content.replace(/<.*?>/ig, "") + "</p>" +
                "<span class=\"date\">" + item.sentDateTime + "</span>" +
                '</div>' +
                "</a>";
            container.append(html);
        });
        //log 
        log(that);
    });
}

function SendMail() {

    var form = $("form", $(document.getElementById("Create Mail")));
    var data = {
        "message": {
            "subject": form.get(0).subject.value,
            "body": {
                "contentType": "Text",
                "content": form.find("editor").html()
            },
            "toRecipients": [
                {
                    "emailAddress": {
                        "address": form.get(0).address.value
                    }
                }
            ],
        }
    }
    graph.SendMail(data).then(function (that) {
        log(that);
        alert("send success");
    })
}

