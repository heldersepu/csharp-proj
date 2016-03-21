$(window).load(function () {
    $("#reportsMenu a").click(reportClick);    
});

function reportClick(e) {
    $("#loading").show();
    $("#liReports").addClass("active");
    getReport(e.currentTarget);
}

function getReport(cTarget) {
    $.ajax({
        type: "GET",
        url: "/api/Reports/?id=" + cTarget.hash.substring(1),
        dataType: "json",
        success: function (json) {
            $("#rptHeader").empty();
            $("#rptContent").empty();
            $("#rptTitle").html(cTarget.innerHTML);
            if (cTarget.innerHTML.endsWith("Chart")) {
                $("#rptContent").addClass("chart");
                showChart(json)
            } else {
                $("#rptContent").removeClass("chart");
                showReport(json, !cTarget.innerHTML.startsWith("Cumulative"))
            }
            $("#loading").hide();
        },
        error: errorFunc,
    });
}

function showReport(json, showTotals) {    
    if (json.length > 0) {
        var totals = {};
        var table = "<div><table id='reportTable' class='display' cellspacing='0' width='95%'>";
        var head = Object.keys(json[0]);
        var tableHead = "<tr>";
        for (var i = 0; i < head.length; i++) {
            tableHead += "<th>" + head[i] + "</th>";
            totals[head[i]] = 0;
        }
        tableHead += "</tr>";
        table += "<thead>" + tableHead + "</thead>";
        table += "<tfoot>" + tableHead + "</tfoot>";

        for (var i = 0; i < json.length; i++) {
            table += "<tr>";
            for (var j = 0; j < head.length; j++) {
                var value = json[i][head[j]];
                if (!isNaN(value)) totals[head[j]] += value;
                table += "<td>" + value + "</td>";
            }
            table += "</tr>";
        }
        table += "</table></div>";

        if (showTotals) {
            var header = "";
            for (var i = 0; i < head.length; i++) {
                if (totals[head[i]] > 0) {
                    header += head[i] + " = $" + totals[head[i]] + " &nbsp;&nbsp;";
                }
            }
            $("#rptHeader").append(header);
        }
        $("#rptContent").append(table);
        $("#reportTable").DataTable({
            "iDisplayLength": 100, "bSort": false
        });
    }
}

function showChart(json) {    
    var options = {
        lines: {show: true},
        points: {show: true},
        xaxis: {tickDecimals: 0, tickSize: 1}
    };
    $.plot("#rptContent", [json.data], options);
}