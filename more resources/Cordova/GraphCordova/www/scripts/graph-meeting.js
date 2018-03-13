/*
  Meeting Scenario
*/
$.graph.prototype.CreateEvent = function (data) {
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_events
    return $.post.call(this, "/me/events", data)
},
    $.graph.prototype.ListEvent = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_events
        if (id)
            return $.get.call(this, "/me/calendars/" + id + "/events");
        else
            return $.get.call(this, "/me/events");
    },
    $.graph.prototype.GetEvent = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_get
        return $.get.call(this, "/me/events/" + id);
    },
    $.graph.prototype.UpdateEvent = function (id, data) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_update
        return $.patch.call(this, "/me/events/" + id, data)
    },
    $.graph.prototype.AcceptEvent = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_accept
        return $.post.call(this, "/me/events/" + id + "/accept");
    },
    $.graph.prototype.TentativelyAcceptEvent = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_tentativelyaccept
        return $.post.call(this, "/me/events/" + id + "/tentativelyAccept");
    },
    $.graph.prototype.DeclineEvent = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_decline
        return $.post.call(this, "/me/events/" + id + "/decline");
    },
    $.graph.prototype.DeleteEvent = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_delete
        return $.del.call(this, "/me/events/" + id);
    },
    $.graph.prototype.ReminderView = function (start, end) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_reminderview
        return $.get.call(this, "/me/reminderView(startDateTime='" + start + "',endDateTime='" + end + "')");
    },
    $.graph.prototype.DismissReminderEvent = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_dismissreminder
        return $.post.call(this, "/me/events/" + id + "/dismissReminder");
    },
    $.graph.prototype.SnoozeReminderEvent = function (id, data) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/event_snoozereminder
        return $.post.call(this, "/me/events/" + id + "/snoozeReminder", data);
    };

function CreateMeeting() {
    var form = $(document.getElementById("Create Meeting")).find("form");
    var data =
        {
            "subject": form.get(0).subject.value,
            "body": {
                "contentType": "HTML",
                "content": form.find("editor").html()
            },
            "start": {
                "dateTime": form.get(0).start.value,
                "timeZone": Date.timeZone
            },
            "end": {
                "dateTime": form.get(0).end.value,
                "timeZone": Date.timeZone
            },
            "location": {
                "displayName": form.get(0).location.value
            },
            "attendees": [
                {
                    "emailAddress": {
                        "address": form.get(0).attendees.value,
                    }
                }
            ]
        }
    graph.CreateEvent(data).then(function (that) {
        render.log(that);
        alert("Create Successful");
    })
}

function GetInMeetingList() {
    GetMeetingList().then(function (that) {
        var _that = $.extend(true, {}, that);
        _that.res.value = [].filter.call(_that.res.value, function (item) {
            return !item.isOrganizer;
        })
        render.GetMeetingList(_that);
    })
}

function GetReminderMeetingList() {

    var date = new Date();
    // date.setMinutes(date.getMinutes() - 600);
    var start = date.toUTCString();
    date.setMinutes(date.getMinutes() + 600);
    var end = date.toUTCString();

    graph.ReminderView("2015-11-08T19:00:00.0000000", end).then(function (that) {
        render.GetMeetingList(that);
    })
}

function GetOutMeetingList() {
    GetMeetingList().then(function (that) {
        var _that = $.extend(true, {}, that);
        _that.res.value = [].filter.call(_that.res.value, function (item) {
            return item.isOrganizer;
        })
        render.GetMeetingList(_that);
    })
}

function GetOneMeeting() {
    var id = params.id;
    graph.GetEvent(id).then(function (that) {
        render.GetOneMeeting(that)
    })
}

function UpdateMeeting() {
    var id = params.id;
    var form = document.getElementById("Get One Meeting").getElementsByTagName("form")[0];
    var data = {
        "subject": form.subject.value,
        "start": {
            "dateTime": form.start.value,
            "timeZone": Date.timeZone
        },
        "end": {
            "dateTime": form.end.value,
            "timeZone": Date.timeZone
        },
        "location": { "displayName": form.location.value },
        "body": {
            "contentType": "html",
            "content": form.getElementsByTagName("editor")[0].innerHTML
        }
    };
    return graph.UpdateEvent(id, data).then(function (that) {
        render.log(that);
        alert("update success")
    })
}

function AcceptMeeting() {
    var id = params.id;
    var data = {
        "comment": "accept the meeting",
        "sendResponse": true
    }
    graph.AcceptEvent(id).then(function (that) {
        alert("accept success")
    })
}

function TentativelyAcceptMeeting() {
    var id = params.id;
    var data = {
        "comment": "accept the meeting tentatively",
        "sendResponse": true
    }
    graph.TentativelyAcceptEvent(id).then(function (that) {
        alert("Tentatively accept the meeting event success")
    })
}

function DeclineMeeting() {
    var id = params.id;
    var data = {
        "comment": "decline the meeting",
        "sendResponse": true
    }
    graph.DeclineEvent(id).then(function (that) {
        alert("Decline the meeting event success")
        history.back();
    })
}

function DeleteMeeting() {
    var id = params.id;
    graph.DeleteEvent(id).then(function (that) {
        alert("delete success");
        history.back();
    })
}

function DismissMeeting() {
    var id = params.id;
    graph.DismissReminderEvent(id).then(function (that) {
        render.log(that);
        alert("dismiss success")
    })
}

function SnoozeMeeting() {
    var id = params.id;
    var date = new Date();
    date.setMinutes(date.getMinutes() + 2);
    var data = {
        "newReminderTime": {
            "dateTime": date.toUTCString(),
            "timeZone": Date.timeZone
        }
    }
    graph.SnoozeReminderEvent(id, data).then(function (that) {
        render.log(that);
        alert("snooze success until " + data.newReminderTime.dateTime)
    })
}

function GetMeetingList() {
    var id = params.id;
    return new Promise(function (resolve, reject) {
        graph.ListEvent(id).then(function (that) {
            params.meeting = that;
            render.log(that);
            resolve(that);
        }).catch(function (err) {
            reject(err)
        });
    })
}