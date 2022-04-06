$(document).ready(function() {

    $("#offcanvas-btn").click(function() {
        $("#p-offcanvas").show();
        $("body").css("overflow", "hidden");
    });

    $("#offcanvas-close").click(function() {
        $("#p-offcanvas").hide();
        $("body").css("overflow", "auto");
    });

    $("#offcanvas-btn2").click(function() {
        $("#p-offcanvas").show();
        $("body").css("overflow", "hidden");
    });

    //modiriat
    $("#modiriatDDB").mouseenter(function() {
        $("#modiriatDDM").show();
        $("#amoozeshDDM").hide();
        $("#pajooheshDDM").hide();
        $("#daneshjooeeDDM").hide();
        $("#edariDDM").hide();
        hover();
    });

    $("#modiriatDDM").mouseenter(function() {
        $("#modiriatDDM").show();
        hover();
    });

    $("#modiriatDDM").mouseleave(function() {
        $("#modiriatDDM").hide();
        hover();
    });

    //amoozesh
    $("#amoozeshDDB").mouseenter(function() {
        $("#modiriatDDM").hide();
        $("#amoozeshDDM").show();
        $("#pajooheshDDM").hide();
        $("#daneshjooeeDDM").hide();
        $("#edariDDM").hide();
        hover();
    });

    $("#amoozeshDDM").mouseenter(function() {
        $("#amoozeshDDM").show();
        hover();
    });

    $("#amoozeshDDM").mouseleave(function() {
        $("#amoozeshDDM").hide();
        hover();
    });


    //pajoohesh
    $("#pajooheshDDB").mouseenter(function() {
        $("#modiriatDDM").hide();
        $("#amoozeshDDM").hide();
        $("#pajooheshDDM").show();
        $("#daneshjooeeDDM").hide();
        $("#edariDDM").hide();
        hover();
    });

    $("#pajooheshDDM").mouseenter(function() {
        $("#pajooheshDDM").show();
        hover();
    });

    $("#pajooheshDDM").mouseleave(function() {
        $("#pajooheshDDM").hide();
        hover();
    });


    //daneshjooee
    $("#daneshjooeeDDB").mouseenter(function() {
        $("#modiriatDDM").hide();
        $("#amoozeshDDM").hide();
        $("#pajooheshDDM").hide();
        $("#daneshjooeeDDM").show();
        $("#edariDDM").hide();
        hover();
    });

    $("#daneshjooeeDDM").mouseenter(function() {
        $("#daneshjooeeDDM").show();
        hover();
    });

    $("#daneshjooeeDDM").mouseleave(function() {
        $("#daneshjooeeDDM").hide();
        hover();
    });


    //edari
    $("#edariDDB").mouseenter(function() {
        $("#modiriatDDM").hide();
        $("#amoozeshDDM").hide();
        $("#pajooheshDDM").hide();
        $("#daneshjooeeDDM").hide();
        $("#edariDDM").show();
        hover();
    });

    $("#edariDDM").mouseenter(function() {
        $("#edariDDM").show();
        hover();
    });

    $("#edariDDM").mouseleave(function() {
        $("#edariDDM").hide();
        hover();
    });


    /////////////////DROPDOWNMENU2///////////////////
    //modiriat
    $("#modiriatDDB2").mouseenter(function() {
        $("#modiriatDDM2").show();
        $("#amoozeshDDM2").hide();
        $("#pajooheshDDM2").hide();
        $("#daneshjooeeDDM2").hide();
        $("#edariDDM2").hide();
        hover2();
    });

    $("#modiriatDDM2").mouseenter(function() {
        $("#modiriatDDM2").show();
        hover2();
    });

    $("#modiriatDDM2").mouseleave(function() {
        $("#modiriatDDM2").hide();
        hover2();
    });

    //amoozesh
    $("#amoozeshDDB2").mouseenter(function() {
        $("#modiriatDDM2").hide();
        $("#amoozeshDDM2").show();
        $("#pajooheshDDM2").hide();
        $("#daneshjooeeDDM2").hide();
        $("#edariDDM2").hide();
        hover2();
    });

    $("#amoozeshDDM2").mouseenter(function() {
        $("#amoozeshDDM2").show();
        hover2();
    });

    $("#amoozeshDDM2").mouseleave(function() {
        $("#amoozeshDDM2").hide();
        hover2();
    });


    //pajoohesh
    $("#pajooheshDDB2").mouseenter(function() {
        $("#modiriatDDM2").hide();
        $("#amoozeshDDM2").hide();
        $("#pajooheshDDM2").show();
        $("#daneshjooeeDDM2").hide();
        $("#edariDDM2").hide();
        hover2();
    });

    $("#pajooheshDDM2").mouseenter(function() {
        $("#pajooheshDDM2").show();
        hover2();
    });

    $("#pajooheshDDM2").mouseleave(function() {
        $("#pajooheshDDM2").hide();
        hover2();
    });


    //daneshjooee
    $("#daneshjooeeDDB2").mouseenter(function() {
        $("#modiriatDDM2").hide();
        $("#amoozeshDDM2").hide();
        $("#pajooheshDDM2").hide();
        $("#daneshjooeeDDM2").show();
        $("#edariDDM2").hide();
        hover2();
    });

    $("#daneshjooeeDDM2").mouseenter(function() {
        $("#daneshjooeeDDM2").show();
        hover2();
    });

    $("#daneshjooeeDDM2").mouseleave(function() {
        $("#daneshjooeeDDM2").hide();
        hover2();
    });


    //edari
    $("#edariDDB2").mouseenter(function() {
        $("#modiriatDDM2").hide();
        $("#amoozeshDDM2").hide();
        $("#pajooheshDDM2").hide();
        $("#daneshjooeeDDM2").hide();
        $("#edariDDM2").show();
        hover2();
    });

    $("#edariDDM2").mouseenter(function() {
        $("#edariDDM2").show();
        hover2();
    });

    $("#edariDDM2").mouseleave(function() {
        $("#edariDDM2").hide();
        hover2();
    });

});


function hover() {
    if ($('#modiriatDDM').css('display') == 'block') {
        $("#modiriatDDB").addClass("myhover");
    } else {
        $("#modiriatDDB").removeClass("myhover");
    }

    if ($('#amoozeshDDM').css('display') == 'block') {
        $("#amoozeshDDB").addClass("myhover");
    } else {
        $("#amoozeshDDB").removeClass("myhover");
    }

    if ($('#pajooheshDDM').css('display') == 'block') {
        $("#pajooheshDDB").addClass("myhover");
    } else {
        $("#pajooheshDDB").removeClass("myhover");
    }

    if ($('#daneshjooeeDDM').css('display') == 'block') {
        $("#daneshjooeeDDB").addClass("myhover");
    } else {
        $("#daneshjooeeDDB").removeClass("myhover");
    }

    if ($('#edariDDM').css('display') == 'block') {
        $("#edariDDB").addClass("myhover");
    } else {
        $("#edariDDB").removeClass("myhover");
    }
}

function hover2() {
    if ($('#modiriatDDM2').css('display') == 'block') {
        $("#modiriatDDB2").addClass("myhover");
    } else {
        $("#modiriatDDB2").removeClass("myhover");
    }

    if ($('#amoozeshDDM2').css('display') == 'block') {
        $("#amoozeshDDB2").addClass("myhover");
    } else {
        $("#amoozeshDDB2").removeClass("myhover");
    }

    if ($('#pajooheshDDM2').css('display') == 'block') {
        $("#pajooheshDDB2").addClass("myhover");
    } else {
        $("#pajooheshDDB2").removeClass("myhover");
    }

    if ($('#daneshjooeeDDM2').css('display') == 'block') {
        $("#daneshjooeeDDB2").addClass("myhover");
    } else {
        $("#daneshjooeeDDB2").removeClass("myhover");
    }

    if ($('#edariDDM2').css('display') == 'block') {
        $("#edariDDB2").addClass("myhover");
    } else {
        $("#edariDDB2").removeClass("myhover");
    }
}

function printDiv(divName) {
    var printContents = document.getElementsByClassName(divName)[0].innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}