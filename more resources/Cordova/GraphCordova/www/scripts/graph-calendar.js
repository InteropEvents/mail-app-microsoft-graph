/*
  Calendar Scenario
*/
$.graph.prototype.CreateCalendar = function (id, data) {
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_calendars
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendargroup_post_calendars
    if (id)
        return $.post.call(this, "/me/calendarGroups/" + id + "/calendars", data);
    else
        return $.post.call(this, "/me/calendars", data);
},
    $.graph.prototype.ListCalendars = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_calendars
        if (id)
            return $.get.call(this, "/me/calendargroups/" + id + "/calendars");
        else
            return $.get.call(this, "/me/calendars");
    },
    $.graph.prototype.UpdateCalendars = function (id, data) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendar_update
        return $.patch.call(this, "/me/calendars/" + id, data);
    },
    $.graph.prototype.DeleteCalendars = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendar_delete
        return $.del.call(this, "/me/calendars/" + id);
    },
    $.graph.prototype.GetCalendar = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendar_get
        return $.get.call(this, "/me/calendars/" + id);
    },
    $.graph.prototype.CreateCalendarGroup = function (data) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_post_calendargroups
        return $.post.call(this, "/me/calendarGroups", data);
    },
    $.graph.prototype.ListCalendarGroups = function () {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_calendargroups
        return $.get.call(this, "/me/calendarGroups");
    },
    $.graph.prototype.GetCalendarGroup = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendargroup_get
        return $.get.call(this, "/me/calendarGroups/" + id);
    },
    $.graph.prototype.DeleteCalendarGroup = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/calendargroup_delete
        return $.del.call(this, "/me/calendarGroups/" + id);
    };

function CreateCalendar() {
    var id = params.id;
    var name = "example calendar " + new Date().toUTCString().substr(11);
    var data = {
        "name": name
    }
    graph.CreateCalendar(id, data).then(function (that) {
        GetCalendarList().then(function () {
            graph.log(that);
        });
    })
}
function UpdateCalendar() {
    var id = params.id;
    var name = "example calendar " + new Date().toUTCString().substr(11);
    var data = {
        "name": name
    }
    graph.UpdateCalendars(id, data).then(function (that) {
        GetOneCalendar().then(render.log);
    })

}
function GetCalendarList() {
    var id = params.id;
    return new Promise(function (resolve, reject) {
        graph.ListCalendars(id).then(function (that) {
            render.GetCalendarList(that);
            resolve(that);
        })
    })
}
function GetOneCalendar() {
    var id = params.id;
    return new Promise(function (resolve, reject) {
        if (id) {
            graph.GetCalendar(id).then(function (that) {
                render.GetOneCalendar(that);
                resolve(that);
            })
        } else {
            render.GetOneCalendar();
            resolve();
        }
    })
}
function DeleteCalendar(id) {
    event.preventDefault();
    var obj = event.target;
    if (confirm("sure to delete this calendar?")) {
        graph.DeleteCalendars(id).then(function (that) {
            render.log(that);
            $(obj).parent().remove();
        })
    }
}
function CreateCalendarGroup() {
    var name = "example calendar group " + new Date().toUTCString().substr(11);
    var data = {
        "name": name,
    }
    graph.CreateCalendarGroup(data).then(function (that) {
        GetCalendarGroupList();
    })

}
function GetCalendarGroupList() {
    graph.ListCalendarGroups().then(function (that) {
        render.GetCalendarGroupList(that);
    })
}
function GetOneCalendarGroup() {
    var id = params.id;
    if (id) {
        graph.GetCalendarGroup(id).then(function (that) {
            render.GetOneCalendarGroup(that);
        })
    } else {
        render.GetOneCalendarGroup({
            res: {
                "name": "Default Calender"
            }
        });
    }
}
function DeleteCalendarGroup(id) {
    event.preventDefault();
    var obj = event.target;
    if (confirm("sure to delete this calendar group?")) {
        graph.DeleteCalendarGroup(id).then(function (that) {
            render.log(that);
            $(obj).parent().remove();
        })
    }
}