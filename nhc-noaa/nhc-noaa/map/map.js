var count = 1
var paused = false;
var images = ["2015302_0015rb.jpg"];
var cdn = "http://az843447.vo.msecnd.net";

$(window).load(function () {
    count = 0;
	var hash = window.location.hash.replace("#", "");
	if ($.isNumeric(hash)) $("#count").val(hash);
    $("#speed").click(function () { paused = false; changeImage(); });
    $("#back").click(function () { changePos(-3); });
    $("#forw").click(function () { changePos(1); });
    $("#count").change(changeCount);
    changeCount();
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
        history.pushState(null, null, '#' + strCount);
		intCount = parseInt(strCount);
    } else {
        $("#count").val(intCount);
    }
    getImages(intCount);
}

function getImages(count) {
    loading();
	paused = true;
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
    console.log(images[0]);
    console.log(images[images.length - 1]);
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
	{
        $("#map").attr("src", cdn + "/goes_east_tatl_img/" + images[count]);
		$(".active").removeClass("active");
		$("#img" + (count + 999)).addClass("active");
	}
    count += 1
    if (count >= images.length)
        count = 0
    if (!paused)
        setTimeout(changeImage, $("#speed").val() * 10);
}

function appendImage(i) {
	var imageTag = '<img id="img' + (i + 1000) + '" src="' +
					cdn + '/goes_east_tatl_img/' + images[i] +
					'" title="' + images[i] + '">';
	$("#images").append(imageTag);
	if (i+1 == images.length) {
		loaded();
		paused = false;
		setTimeout(changeImage, 500)
	}
}

function addAllImages() {
    $("#images").empty();
    for (i = 0; i < images.length; i++) {
        setTimeout(appendImage.bind(null, i), i * 50);
    }
}