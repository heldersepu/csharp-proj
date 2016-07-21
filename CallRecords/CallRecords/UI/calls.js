var commonFilters;
var activeView;

$(window).load(function () {
    $(".navbar a").click(navClick);
    $("#btnApplyFilters").click(applyFilters);
    $("#addFilters").validate();
    loadCommonFilters();
    loadCalls(1);    
});

function loadCommonFilters() {
    $.ajax({
        type: "GET",
        url: "/api/CommonFilters",
        dataType: "json",
        cache: false,
        success: createCommonFiltersModal,
        error: errorFunc,
    });
}

function createCommonFiltersModal(json) {
    commonFilters = json;    
    $.each(json, function (index, filter) {
        var strFilter = "<a href='#' onclick='AddFilter(" + index + ")'>" + filter.Description + "</a><br>"
        $("#filtersModal #CommonFilters").append(strFilter);
    });
}

function AddFilter(index) {
    var filter = commonFilters[index];
    var strFilter = "<div>";
    strFilter += filter.Field + " " + filter.Operation.replace('{0}', '') + " ";
    strFilter += "<input required maxlength='64' id='" + index + "' type='" + filter.Type + "' class='" + filter.Type + "'>";
    strFilter += "<a href='#' onclick='DelFilter()'><i class='glyphicon glyphicon-trash'></i></a>";
    strFilter += "</div>";
    $("#filtersModal #addFilters").append(strFilter);
}

function DelFilter() {
    $(event.target.parentNode.parentNode).remove();
}

function loadCalls(id) {
    $("#loading").show();
    $("#divCallRecordsTable").hide()
    $.ajax({
        type: "GET",
        url: "/api/CallsView?ID=" + id,
        dataType: "json",
        cache: false,
        success: createCallsTable,
        error: errorFunc,
    });
}

function createCallsTable(json) {
    activeView = json.ListView;
    if ($("#CallRecordsTable tr").length > 0) {
        $("#CallRecordsTable").DataTable().destroy();
    }
    $("#CallRecordsTable").empty();
    var row = "<tr><th>Id</th><th>Duration</th><th>PhoneNumber</th><th>StartTime</th><th>Name</th></tr>";
    $("#CallRecordsTable").append("<thead>" + row + "</thead>");
    $("#CallRecordsTable").append("<tfoot>" + row + "</tfoot>");
    for (var i = 0; i < json.Calls.length; i++) {
        var call = json.Calls[i]
        var row = "<tr><td>" + call.Id + "</td>";
        row += "<td>" + call.Duration + "</td>";
        row += "<td>" + call.PhoneNumber + "</td>";
        row += "<td>" + call.StartTime.substring(0, 16) + "</td>";
        row += "<td>" + call.Name + "</td></tr>";
        $("#CallRecordsTable").append(row);
    }
    $("#loading").hide();
    $("#divCallRecordsTable").show();
    $("#CallRecordsTable").DataTable();
    $('#CallRecordsTable tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            $('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
}

function applyFilters() {
    if ($("#addFilters").valid()) {
        $("#loading").show();
        $.ajax({
            type: "POST",
            url: "/api/Employees",
            data: $("#addEmployee").serialize(),
            success: employeeChange,
            error: errorFunc,
        });
    }
}

function navClick(e) {
    $(".navbar li").removeClass("active");
    e.currentTarget.parentNode.className = "active";
    var target = e.currentTarget.dataset.target;
    if (typeof target !== "undefined") {
        $(".well").hide();
        $("#" + target).show();
    }
}

function successFunc(employees) {
    $("input").val("");
    alert("Good to Go!");
    $("#loading").hide();
}

function errorFunc(err) {
    if (err.responseText == "")
        alert("Sorry the communication failed.");
    else
        alert(err.responseText);
}
