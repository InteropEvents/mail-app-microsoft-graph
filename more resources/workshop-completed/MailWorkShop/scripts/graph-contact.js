/*
  Contact Scenario
*/
onPanelLoad["Show Contact List"] = ShowContactList;

$.graph.prototype.ListContacts = function () {
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_contacts
    return $.get.call(this, "/me/contacts");
}

function ShowContactList() {

    var container = $(document.getElementById("Show Contact List")).children(".container");
    container.html("");

    graph.ListContacts().then(function (that) {
        var data = that.res;
        $.each(data.value, function (index, item) {
            var html =
                '<a class="link" href="javascript:void(0)">' +
                "<div class=\"mail-item\">" +
                "<p><b>DisplayName:</b>" + item.displayName + "</p>" +
                "<p><b>EmailAddresses:</b>" + (item.emailAddresses[0] ? item.emailAddresses[0].address : "-") + "</p>" +
                '</div>' +
                "</a>";
            container.append(html);
        });

        log(that);
    });
}