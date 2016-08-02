var count = 1
var paused = false;
var images = ["2015302_0015rb.jpg"];
var cdn = "http://az843447.vo.msecnd.net";

$(window).ready(function () { setTimeout(changeImage, 500); });
$(window).load(function () {
    count = 0;
    changeCount();
    $("#speed").val(10);
    $("#speed").click(function () { paused = false; changeImage(); });
    $("#back").click(function () { changePos(-2); });
    $("#forw").click(function () { changePos(2); });
    $("#count").change(changeCount);
});

function loading() {
    $("#loader").show();
    $("#controls input").prop("disabled", true);
}

function loaded() {
    $("#loader").fadeOut("slow");
    $("#controls input").prop("disabled", false);
}

function changeCount() {
    var strCount = $("#count").val();
    var intCount = 100
    if ($.isNumeric(strCount)) {
        intCount = parseInt(strCount);
    } else {
        $("#count").val(intCount);
    }
    getImages(intCount);
}

function getImages(count) {
    loading();
    $.ajax({
        type: "GET",
        url: cdn + "/api/Images/EastAtlantic?count=" + count,
        cache: false,
        success: successFunc,
        error: errorFunc,
    });
}

function successFunc(data) {
    images = data;
    images.reverse();
    addAllImages();
}

function errorFunc(err) {
    if (err.responseText == "")
        alert("Sorry the communication failed.");
    else
        alert(err.responseText);
}

function changePos(pos) {
    count += pos;
    if (count < 0)
        count = images.length - 2;
    paused = true;
    $("#speed").val(50);
    changeImage();
}

function changeImage() {
    if (images.length > 1)
        $("#map").attr("src", cdn + "/goes_east_tatl_img/" + images[count]);
    count += 1
    if (count >= images.length)
        count = 0
    //while (!document.getElementById('map').complete) {
    //    if (!$("#loader").is(":visible"))
    //        loading();
    //}
    //loaded();
    if (!paused)
        setTimeout(changeImage, $("#speed").val() * 10);
}

function addAllImages() {
    $("#images").empty();
    for (i = 0; i < images.length; i++) {
        $("#images").append('<img id="img' + i + '" src="' + cdn + '/goes_east_tatl_img/' + images[i] + '">');
    }
    $('#img' + (images.length - 1)).on('load', function () {
        var wait = 0
        while (!document.getElementById('img' + (images.length - 1)).complete) {
            wait += 1;
        }
        loaded();
    });
}