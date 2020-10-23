$(document).ready(function () {
    
    $(function () {
        var selectedClass = "";
        $(".fil-cat").click(function () {
            selectedClass = $(this).attr("data-rel");
            $("#filter").fadeTo(100, 0.1);
            $("#filter div").not("." + selectedClass).fadeOut().removeClass('scale-anm');
            setTimeout(function () {
                $("." + selectedClass).fadeIn().addClass('scale-anm');
                $("#filter").fadeTo(300, 1);
            }, 300);
        });
    });
});

$(window).on('load', function () {
    $(".tile").each(function () {
        if ($(this).children().length < 2) {
            var text = $(this).find("h1").text();
            $(".fil-cat").each(function () {
                if ($(this).attr("data-rel") === text) {
                    $(this).addClass("disabled");
                }
            })
        }
    });
});