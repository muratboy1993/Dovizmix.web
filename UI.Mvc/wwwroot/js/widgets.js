"use strict";
$(document).ready(function ()
{
    /*Ready Actions*/

   


    /*Scroll Events*/
    $(window).scroll(function (event)
    {
        /*Top Market Info*/
        var scroll = $(window).scrollTop();
        ScrollTopMarketInfo(scroll);

    });
    
    /*Click Events*/

  



    /*Functions*/

    /*CYRPTO TICKER*/
    GetCryptoTicker();
    /*CYRPTO TICKER*/

    
    
});

function GetCryptoTicker() {

    $.ajax({
        url: "https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd",
        dataType: "json",
        success: function (response) {
            $.each(response, function (index, val)
            {
                //$(".webticker-1").append('<li><img style="width:12px" src=' + val.image + '/><i class="cc ' + val.symbol.toUpperCase() + '"></i> ' + val.name + ' <span class="text-yellow"> $' + val.current_price + '</span></li>');
                $("#webticker-1").append('<li><img style="width:12px" src=' + val.image + '/><i class="cc"></i> ' + val.name + ' <span class="text-yellow"> $' + val.current_price + '</span></li>');
            });

            if ($('#webticker-1').length)
            {
                $("#webticker-1").webTicker({
                    height: 'auto',
                    duplicate: true,
                    startEmpty: false,
                    rssfrequency: 5
                });
            }
        },
        error: function (err) {
            alert("Cyrpto Ticker getirilemedi.");
        }
    });
}

function ScrollTopMarketInfo(scroll) {

    if (scroll >= 100) {

        $("#sabitMenuContainer").show();
    }
    else {
        $("#sabitMenuContainer").hide();
    }
}

function hide() {
    if ($(".market-close").attr("style") === "display: none;") {
        if (!$(".market-close")[0]) {
            $("#hebele").height(25);
        }
        else {
            $("#hebele").removeAttr("style");
        }
    }
    else {
        if (!$(".market-open")[0]) {
            $("#hebele").height(25);
        }
        else {
            $("#hebele").removeAttr("style");
        }
    }
}