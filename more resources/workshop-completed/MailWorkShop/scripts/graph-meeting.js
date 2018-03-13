/*
  Meeting Scenario
*/
onPanelLoad["Show Meeting List"] = ShowMeetingList;

$.graph.prototype.ListEvent = function () {
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_events
    return $.get.call(this, "/me/events");
};



function ShowMeetingList() {

    var container = $(document.getElementById("Show Meeting List")).children(".container").html("");

    graph.ListEvent().then(function (that) {
        //render
        var data = that.res;
        $.each(data.value, function (index, item) {
            var html =
                '<a class="link" href="javascript:void(0)">' +
                "<div class=\"mail-item\">" +
                "<p><b>Sender:</b>" + item.organizer.emailAddress.name + " " + item.organizer.emailAddress.address + "</p>" +
                "<p><b>Subject:</b>" + item.subject + "</p>" +
                "<p class=\"content\">" + (item.bodyPreview || item.body.content.replace(/<.*?>/ig, "")) + "</p>" +
                "<span class=\"date\">" + item.start.dateTime.substring(0, 19) + "</span>" +
                '</div>' +
                "</a>";
            container.append(html);
        });

        log(that);
    })
}