    function activateMenuItem(name) {
        $("#Menu" + name).addClass("active");
        $('#Menu' + name).find('div.icon').css('background', "url('/Content/Images/Admin/ico-" + name.toLowerCase() + "-black.png') no-repeat");
    }


    $(function () {
        positionMenu();

        $(window).resize(function () {
            positionMenu();
        });

        $(".page-header .user").click(function () {
            if ($(".userContextMenu").is(":visible")) {
                $(".userContextMenu").slideUp({
                    duration: 200,
                    easing: 'linear',
                });
            }
            else {
                $(".userContextMenu").slideDown({
                    duration: 200,
                    easing: 'linear',
                });
            }
        });
    });

    function positionMenu() {
        var windowHeight = $(window).height();
        if ($(".page").height() < windowHeight) {
            $(".page").css("min-height", windowHeight);
        }

        $(".userContextMenu").css("left", $(".c2").position().left + 670);
        $(".c1").css("height", $(".page").height());

        $(".loading").css("top", ($(".page").height() / 2) - 30);
        $(".loading").css("left", $(".c1").position().left + 650);
    }

