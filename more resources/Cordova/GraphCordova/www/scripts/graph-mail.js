/*
  Mail Scenario
*/
$.graph.prototype.CreateMessage = function (data) {
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_messages
    return $.post.call(this, "/me/messages", data);
},
    $.graph.prototype.SendMail = function (data) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_sendmail
        return $.post.call(this, "/me/sendMail", data);
    },
    $.graph.prototype.DeleteMessage = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_delete
        return $.del.call(this, "/me/messages/" + id);
    },
    $.graph.prototype.Listmessages = function (folderId, keyword) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_messages
        var data;
        if (keyword) {
            data = {
                "$search": '"' + keyword + '"'
            };
        }
        if (folderId)
            return $.get.call(this, "/me/mailFolders/" + folderId + "/messages", data);
        else
            return $.get.call(this, "/me/mailFolders/Inbox/messages", data);
    },
    $.graph.prototype.Getmessage = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_get
        return $.get.call(this, "/me/messages/" + id);
    },
    $.graph.prototype.Updatemessage = function (id, data) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_update
        return $.patch.call(this, "/me/messages/" + id, data)
    },
    $.graph.prototype.CreateMailFolder = function (foldername) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_mailfolders
        return $.post.call(this, "/me/mailFolders", { displayName: foldername })
    },
    $.graph.prototype.DeletemailFolder = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/mailfolder_delete
        return $.del.call(this, "/me/mailFolders/" + id);
    },
    $.graph.prototype.Movemessage = function (id, DestinationId) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_move
        return $.post.call(this, "/me/messages/" + id + "/move", { DestinationId: DestinationId })
    },
    $.graph.prototype.Copymessage = function (id, DestinationId) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/message_copy
        return $.post.call(this, "/me/messages/" + id + "/copy", { DestinationId: DestinationId });
    },
    $.graph.prototype.ListmailFolders = function () {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_mailfolders
        return $.get.call(this, "/me/mailFolders");
    };

function SendMail() {
    var date = new Date();
    var form = $("form", $(document.getElementById("Send Mail")));

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
        render.log(that);
        alert("send success");
    })
}

function DeleteMail() {
    var id = params.id;
    graph.DeleteMessage(id).then(function (that) {
        render.log(that);
        history.go(-1);
    })
}

function ShowMailList() {
    var id = params.id;
    var keyword = params.keyword;

    graph.Listmessages(id, keyword).then(function (that) {
        render.Listmessages(that);
    });
}
//疑问 只找到一个邮件吗？
function Findamailwithspecifiedkeywords(keyword) {
    var id = params.id;
    graph.Listmessages(id, keyword).then(function (that) {
        render.Listmessages(that);
    });
}

function MarkMailAsRead() {
    var id = params.id;
    graph.Updatemessage(id, { isRead: true }).then(function (that) {
        render.log(that);
        alert("success");
    })
}

function ShowSingleMail() {
    var id = params.id;
    graph.Getmessage(id).then(function (that) {
        that.res.sentDateTime = new Date(that.res.sentDateTime).toUTCString();
        render.ShowSingleMail(that);
    });
}

function CreateFolderUnderInbox() {
    var name = "example folder " + new Date().toUTCString().substr(11);
    graph.CreateMailFolder(name).then(function (that) {
        render.CreateFolderUnderInbox(that);
        ListmailFolders();//refresh mail box
    });
}

function DeleteFolderUnderInbox(id) {
    event.preventDefault();
    var obj = event.target;
    if (confirm("Confirm to Delete")) {
        graph.DeletemailFolder(id).then(function (that) {
            render.log(that);
            $(obj).parent().remove();
            ListmailFolders();
        })
    }
}

function MoveMailintoFolder(folderId) {
    var id = params.id;
    graph.Movemessage(id, folderId).then(function (that) {
        history.back();
    })
}

function CopyMailintoFolder(folderId) {
    var id = params.id;
    graph.Copymessage(id, folderId).then(function (that) {
        history.back();
    })
}

function ListmailFolders() {
    return graph.ListmailFolders().then(function (that) {
        params.storge.mailFolders = JSON.stringify(that);
        render.ListmailFolders(that);
        return that;
    })
}
/**
 * other operation
 */
function chooseFolder(folderId) {
    var mothed = params.mothed;
    switch (mothed) {
        case "Copy": CopyMailintoFolder(folderId); break;
        case "Move": MoveMailintoFolder(folderId); break;
        default:
    }
}