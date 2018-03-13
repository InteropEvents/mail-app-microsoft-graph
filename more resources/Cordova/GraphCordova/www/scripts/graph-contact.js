/*
  Mail Scenario
*/

$.graph.prototype.ListContacts = function () {
    //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/user_list_messages
    return $.get.call(this, "/me/contacts");
},
    $.graph.prototype.GetContact = function (id) {
        //https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/api/contact_get
        return $.get.call(this, "/me/contacts/" + id);
    };

function ShowContactList() {
    graph.ListContacts().then(function (that) {
        render.GetContactList(that);
    });
}

function ShowSingleContact() {
    var id = params.id;
    graph.GetContact(id).then(function (that) {
        render.GetOneContact(that);
    });
}