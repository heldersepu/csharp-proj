$(window).load(function () {    
    loadTest();
    $("#btnSubmit").click(doSubmit);
});

function loadTest() {
    $("#loading").show();
    $("#divTable").hide()
    $.ajax({
        type: "GET",
        url: "/api/Test",
        dataType: "json",
        cache: false,
        success: createTable,
        error: errorFunc,
    });
}

function doSubmit() {
    alert("Work in progress...")
}

function createTable(test) {
    if ($("#testTable tr").length > 0) {
        $("#testTable").DataTable().destroy();
    }
    $("#testTable").empty();
    var row = "<tr><th>Questions</th></tr>";
    $("#testTable").append("<thead>" + row + "</thead>");
    $("#testName").html(test.Name);
    for (var i = 0; i < test.Questions.length; i++) {
        var question = test.Questions[i];
        var row = "<tr><td>" + (i + 1) + ". " + question.Detail + "";
        var type = (question.SingleAnswer ? "radio" : "checkbox");
        for (var j = 0; j < question.Choices.length; j++) {
            var choice = question.Choices[j]
            row += "<br><input type=" + type + " name=Q" + question.Id + " value=" + choice.Id + ">"
            row += "<span >" + choice.Detail + "</span>"
        }
        row += "</td><tr>";
        $("#testTable").append(row);
    }
    $("#loading").hide();
    $("#divTable").show();
    $("#testTable").DataTable( {
        "paging": false,
        "searching": false,
        "ordering": false,
        "info": false
    });    
}

function errorFunc(err) {
    if (err.responseText == "")
        alert("Sorry the communication failed.");
    else
        alert(err.responseText);
}
