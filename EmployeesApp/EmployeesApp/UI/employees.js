$(window).load(function () {
    $("#admin button").click(doSave);
    $(".navbar a").click(navClick);
    $("#btnAddEmployee").click(addEmployee);
    $("#btnDelEmployee").click(delEmployee);
    $("#btnDependentPopover").click(showDependentPopover);
    loadEmployees();
});

function addEmployee() {
    $("#loading").show();
    $.ajax({
        type: "POST",
        url: "/api/Employees",
        data: $("#addEmployee").serialize(),
        success: employeeChange,
        error: errorFunc,
    });
}

function delEmployee(e) {
    $("#loading").show();
    var id = $("#btnDelEmployee").data("id");
    $.ajax({
        type: "DELETE",
        url: "/api/Employees/?id=" + id,
        success: employeeChange,
        error: errorFunc,
    });
}

function addDependent() {
    $("#loading").show();
    var id = $("#btnDependentPopover").data("id");
    var depData = $("#addDependent #Name").val() + ", Age = " + $("#addDependent #Age").val()
    $.ajax({
        type: "POST",
        url: "/api/Dependents/?empid=" + id,
        data: $("#addDependent").serialize(),
        success: function () {
            $("#loading").hide();
            $('#btnDependentPopover').popover('hide');
            $("#employeeModal #employeeDependents").append(
                "<div>&nbsp;&nbsp;&nbsp;" + depData +"</div>"
            )
        },
        error: errorFunc,
    });
}

function delDependent(id) {
    $("#loading").show();
    $("#dependent_" + id).hide();
    $.ajax({
        type: "DELETE",
        url: "/api/Dependents/?id=" + id,
        success: function () {
            $("#loading").hide();
        },
        error: errorFunc,
    });
}

function showEmployee(id) {
    $("#loading").show();
    $.ajax({
        type: "GET",
        url: "/api/Employees/?id=" + id,
        dataType: "json",
        success: employeeShow,
        error: errorFunc,
    });
} 

function loadEmployees() {
    $("#loading").show();
    $("#divEmployeesTable").hide()
    $.ajax({
        type: "GET",
        url: "/api/Employees",
        dataType: "json",
        cache: false,
        success: createEmployeesTable,
        error: errorFunc,
    });
}

function doSave(e) {
    $("#loading").show();    
    var target = e.currentTarget.dataset.target;
    $.ajax({
        type: "POST",
        url: "/api/" + target,
        data: $("#" + target).serialize(),
        success: successFunc,
        error: errorFunc,
    });
}

function showDependentPopover() {
    var options = {
        title: "Add Dependent",
        template: $("#dependentForm").html(),
        placement: "left",
        //trigger: "focus"
    };
    $('#btnDependentPopover').popover(options);
    $('#btnDependentPopover').popover('show');
}

function employeeShow(employee) {
    var delIco = "<span class='glyphicon glyphicon-trash' style='color: red;'></span>";  
    $("#employeeModal #Name").val(employee.Name);
    $("#employeeModal #Email").val(employee.Email);
    $("#employeeModal #Age").val(employee.Age);
    $("#employeeModal #PaycheckAmount").val(employee.PaycheckAmount);
    $("#employeeModal #PaychecksPerYear").val(employee.PaychecksPerYear);
    $("#employeeModal #HireDate").val(employee.HireDate.substring(0, 10));
    $("#btnDelEmployee").data("id", employee.Id);
    $("#btnDependentPopover").data("id", employee.Id);
    $("#employeeModal #employeeDependents").empty();
    for (var i = 0; i < employee.Dependents.length; i++) {
        var dep = employee.Dependents[i];
        var depData = "<div id='dependent_" + dep.Id + "'>";
        depData += "<a href=# onclick='delDependent(" + dep.Id + ")'>" + delIco + "</a>";
        depData += "&nbsp;&nbsp;&nbsp;" + dep.Name;
        if (dep.Age != null)
            depData += ", Age = " + dep.Age;
        
        depData += "</div>";
        $("#employeeModal #employeeDependents").append(depData);
    }
    $("#employeeModal").modal("show");
    $("#loading").hide();
}

function employeeChange() {    
    $("*").modal("hide");
    $("input").val("");
    loadEmployees();
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

function createEmployeesTable(employees) {
    if ($("#employeesTable tr").length > 0) {        
        $("#employeesTable").DataTable().destroy();
    }
    $("#employeesTable").empty();
    var row = "<tr><th>Name</th><th>Email</th><th>Age</th><th>Dependents</th><th>Paycheck Amount</th><th>Paychecks PerYear</th><th>HireDate</th></tr>";
    $("#employeesTable").append("<thead>" + row + "</thead>");
    $("#employeesTable").append("<tfoot>" + row + "</tfoot>");
    for (var i = 0; i < employees.length; i++) {
        var row = "<tr><td><a href='#' onclick='showEmployee(" + employees[i].Id + ")'>" + employees[i].Name + "</a></td>";
        row += "<td>" + employees[i].Email + "</td>";
        row += "<td>" + employees[i].Age + "</td>";
        row += "<td>" + employees[i].Dependents.length + "</td>";
        row += "<td>" + employees[i].PaycheckAmount + "</td>";
        row += "<td>" + employees[i].PaychecksPerYear + "</td>";
        row += "<td>" + employees[i].HireDate.substring(0, 10) + "</td></tr>";
        $("#employeesTable").append(row);
    }
    $("#loading").hide();
    $("#divEmployeesTable").show();
    $("#employeesTable").DataTable();
    $('#employeesTable tbody').on('click', 'tr', function () {
        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        } else {
            $('tr.selected').removeClass('selected');
            $(this).addClass('selected');
        }
    });
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
