"use strict";
var errmsg = "Bu işlem bakım dolayısı ile şuanda kullanılamamaktadır.";
$(document).ready(function () {
    var UserId = $("#UserId").val();
    var QueryType = $(".profilTabs").first().find("a").data("href");

    /*Functions*/

    GetData(UserId, QueryType);

    //On Click Event
    /*GetData çağrılıyor*/
    $(".commenttabs").click(function () {
        var UserId = $("#UserId").val();
        var QueryType = $(this).data("href");
        GetData(UserId, QueryType);
    });
});

/*Kullanıcı profilindeki yoruları geririr*/
function GetData(userId, queryType) {
    $.ajax({
        type: 'POST',
        url: '/Profile/UserPageComments',
        data: {
            'userId': userId,
            'queryType': queryType
        },
        success: function (msg) {

            switch (queryType) {

                case "Tumu":
                    if (msg.data) {
                        $("#tumu").html(msg.data);
                    } else { $("#tumu").html("Yorumu bulunmuyor."); }
                break;

                case "Begenilen":
                    if (msg.data) {
                        $("#begenilen").html(msg.data);
                    } else { $("#begenilen").html("Beğenilen yorumu bulunmuyor."); }
                break;
                case "Grafik":
                    if (msg.data) {
                        $("#grafik").html(msg.data);
                    } else { $("#grafik").html("Grafik içeren yorumu bulunmuyor."); }
                break;
                case "Anket":
                    if (msg.data) {
                        $("#anket").html(msg.data);
                    } else { $("#anket").html("Anketi bulunmuyor."); }
                break;
        }

        },
        error: function () {
            alert(errmsg);
        }
    });
}

function UnBlock(element, targetUserId, type) {

    $.ajax({
        type: 'GET',
        url: '/User/UnBlock',
        data: {
            'targetUserId': targetUserId
        },
        success: function (msg) {
            if (!msg.status) {
                alert(msg.message);
            }
            if (type === "profile") {
                $(element).switchClass("btn-warning", "btn-danger");
                $(element).removeAttr("onclick");
                $(element).attr("onclick", "AddBlock(this," + targetUserId + ",'profile')");
                $(element).text("Engelle");
            }
            else if(type === "setting") {
                setTimeout(function () {
                    window.location.reload(true);
                }, 1000);
            }
        },
        error: function () {
            alert(errmsg);
        }
    });
}