$(document).ready(function() {
    window.addEventListener("pageshow", function (event) {
        var historyTraversal = event.persisted ||
            (typeof window.performance != "undefined" &&
                window.performance.navigation.type === 2);
        if (historyTraversal) {
            window.location.reload();
        }
    });

    $(window).on('resize scroll', function() {
        if ($('#circle-stats').isInViewport()) {
            circle_stats();
        }
    });

    $(document).scroll(function() {
        var y = $(this).scrollTop();
        if (y > $(window).height() - 10) {
            $('.mynav').fadeIn();
        } else {
            $('.mynav').fadeOut();
        }
    });

    $('.carousel').carousel()

    $('.carousel').on('touchstart', function(event) {
        const xClick = event.originalEvent.touches[0].pageX;
        $(this).one('touchmove', function(event) {
            const xMove = event.originalEvent.touches[0].pageX;
            const sensitivityInPx = 5;

            if (Math.floor(xClick - xMove) > sensitivityInPx) {
                $(this).carousel('next');
            } else if (Math.floor(xClick - xMove) < -sensitivityInPx) {
                $(this).carousel('prev');
            }
        });
        $(this).on('touchend', function() {
            $(this).off('touchmove');
        });
    });


    $('.post-module').hover(function() {
        $(this).find('.description').stop().animate({
            height: "toggle",
            opacity: "toggle"
        }, 300);
    });


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

    $('.owl-carousel').owlCarousel({
        rtl: true,
        loop: false,
        nav: false,
        dots: false,
        margin: 10,
        responsiveClass: true,
        autoplay: true,
        autoplayTimeout: 5000,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 2
            },
            450: {
                items: 3
            },
            700: {
                items: 4
            },
            1000: {
                items: 4
            }
        }
    });


    $("#spdown").click(function() {
        $('html, body').animate({
            scrollTop: $("#NewsSection").offset().top
        }, 800);
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

var flag_circle_stats = true;

function circle_stats() {
    if (flag_circle_stats) {
        $('.count').each(function() {
            $(this).prop('Counter', 0).animate({
                Counter: $(this).text()
            }, {
                duration: 1500,
                easing: 'linear',
                step: function(now) {
                    $(this).text(Math.ceil(now));
                }
            });
        });
        flag_circle_stats = false;
    }
}

$.fn.isInViewport = function() {
    var elementTop = $(this).offset().top;
    var elementBottom = elementTop + $(this).outerHeight();

    var viewportTop = $(window).scrollTop();
    var viewportBottom = viewportTop + $(window).height();

    return elementBottom > viewportTop && elementTop < viewportBottom;
};