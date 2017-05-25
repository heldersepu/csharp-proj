var Map = (function () {
    var interval;
    var count = 0;
    var images = [];
    var cdn = "http://nhc0.azureedge.net";

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
        var intCount = 100;
        if ($.isNumeric(strCount)) {
            history.pushState(null, null, "#" + strCount);
            intCount = parseInt(strCount);
        } else {
            $("#count").val(intCount);
        }
        getImages(intCount);
    }

    function getImages(intCount) {
        loading();
        $.ajax({
            type: "GET",
            url: cdn + "/api/Images/EastAtlantic?count=" + intCount,
            cache: false,
            success: successFunc,
            error: errorFunc
        });
    }

    function imgSrc(image, id) {
        return cdn.replace("0", (id%10)) + "/goes_east_tatl_img/" + image;
    }

    function sprite(image, id) {
        var imgTag = "<img class='sprite' style='background:url(" +
                        imgSrc(image, id) + ") 0 -465px'>";
        $("#data").append(imgTag);
    }

    function successFunc(data) {
        images = data;
        images.reverse();
        $("#data").empty();
        clearInterval(interval);
        sprite(images[0], 0);
        sprite(images[images.length - 1], images.length - 1);
        addAllImages();
        count = 0;
    }

    function errorFunc(err) {
        if (err.responseText === "")
            alert("Sorry the communication failed.");
        else
            alert(err.responseText);
    }

    function changePos(pos) {
        count += pos;
        clearInterval(interval);
        showImage();
    }

    function showImage() {
        if (count < 0) count = images.length - 1;
        if (count >= images.length) count = 0;
        $("#map").attr("src", imgSrc(images[count], count));
        $(".active").removeClass("active");
        $("#img" + (count + 1000)).addClass("active");
    }

    function changeImage() {
        if (images.length > 1) {
            showImage();
            count += 1;
        }
    }

    function setImage(x) {
        clearInterval(interval);
        count = x;
        showImage();
    }

    function appendImage(i) {
        var imageTag = "<img id='img" + (i + 1000) + "' onclick='Map.setImage(" + i + ")'>";
        $("#images").append(imageTag);
    }

    function updateImage(i) {
        var image = $("#img" + (i + 1000));
        image.attr("src", imgSrc(images[i], i));
        image.attr("title", images[i]);
        if (i + 1 === images.length) {
            changeSpeed();
            loaded()
        }
    }

    function isCached(src, i) {
        var image = new Image();
        image.src = imgSrc(src, i);
        return image.complete;
    }

    function getTitles(x, y) {
        return y.attributes.title.value;
    }

    function addAllImages() {
        var imgs = $("#images img").map(getTitles);
        $("#images").empty();
        for (var i = 0; i < images.length; i++) {
            appendImage(i);
            var delay = i * 25;
            if (($.inArray(images[i], imgs) > 0) || (isCached(images[i], i)))
                delay = i * 8;
            setTimeout(updateImage.bind(null, i), delay);
        }
    }

    function changeSpeed() {
        clearInterval(interval);
        interval = setInterval(changeImage, $("#speed").val());
    }

    function init() {
        interval = setInterval(changeImage, 100);
        changeCount();
    }

    return {
        changeCount: changeCount,
        changeSpeed: changeSpeed,
        changePos: changePos,
        setImage: setImage,
        init: init
    };
})();


$(window).load(function () {
    var hash = window.location.hash.replace("#", "");
	if ($.isNumeric(hash)) $("#count").val(hash);
	$("#back").click(function () { Map.changePos(-1); });
	$("#forw").click(function () { Map.changePos(1); });
	$("#speed").change(Map.changeSpeed);
	$("#count").change(Map.changeCount);
    Map.init();
});
