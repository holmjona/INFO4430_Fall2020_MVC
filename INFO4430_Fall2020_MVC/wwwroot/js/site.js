// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$("#btnSearch").click(function () {
    var srcBox = $("#txtSearch");
    var srcText = srcBox.val();
    $.ajax({
        url: "Student/Search"
        , data: { searchText: srcText }
        , method: "post"
        , success: function (data) {
            var ul = $("<ul>");
            for (var i = 0; i < data.length; i++) {
                var obj = data[i];
                var a = $("<a>");
                a.attr("href", "Student/Details/" + obj.id);
                a.text(obj.name);
                li = $("<li>");
                li.append(a);
                var aView = $("<button>");
                aView.text("View")
                aView.data("id", obj.id);
                aView.click(showCard)
                li.append(aView)
                ul.append(li);
            }
            $("#output").append(ul);
        }
        , error: function () {
            alert("oops");
        }
    });
    $.ajax({
        url: "Course/Search"
        , data: { searchText: srcText }
        , method: "post"
        , success: function (data) {
            var ul = $("<ul>");
            for (var i = 0; i < data.length; i++) {
                var obj = data[i];
                var a = $("<a>");
                a.attr("href", "Course/Details/" + obj.id);
                a.text(obj.name);
                ul.append($("<li>").append(a));
            }
            $("#output").append(ul);
        }
        , error: function () {
            alert("oops");
        }
    });
});

function showCard() {
    var id = $(this).data("id");
    $.ajax({
        url: "Student/Card"
        , data: { id: id }
        , method: "post"
        , success: function (data) {
            alert(data);
            $("#output").append(data);
        }
        , error: function () {
            alert("oops");
        }
    });
}