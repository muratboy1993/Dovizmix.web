"use strict";
var errmsg = "Bu işlem bakım dolayısı ile şuanda kullanılamamaktadır.";
$(document).ready(function () {

    if (!$(".market-open")[0]) {
        $("#hebele").height(25);
    }

    /**/
    setTimeout(function () {
        $('.usrp-fb-1').addClass('slide-in');
    }, 500);

    /**/
    setTimeout(function () {
        $('.usrp-fb-1').removeClass('slide-in');
    }, 1000);

    /*GetMostLikedUsers, GetOpenMarkets, GetEconomicCalendar cağrılıyor*/
    setTimeout(function () {
        GetMostLikedUsers();
        GetOpenMarkets();
        GetEconomicCalendar();
    }, 1500);

    /* Slide the feedback button in and out - we suggest doing this once per session only */
    $('#feedback_result').html();

    /*Kullanıcı arama*/
    $("#txtusername").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/User/SearchUsername",
                dataType: "json",
                data:
                {
                    username: request.term
                },
                success: function (data) {
                    response($.map(data, function (item) {

                        return {
                            label: item.username,
                            value: item.username,
                            avatar: item.avatarPath,
                        };
                    }));
                }, error: function (err) {
                    alert(errmsg);
                }
            });
        },
        minLength: 3,
        select: function (event, ui) {
            window.location.href = "/Profil/" + ui.item.value;
        }
    }).data("ui-autocomplete")._renderItem = function (ul, item) {
        var inner_html = "<div class='media media-single'><a href='/Profil/" + item.label + "'><img class='avatar' src='/assets/images/avatar/" + item.avatar + "' alt='...'></a><div class='media-body'><h6><a href='/Profil/" + item.label + "'>" + item.label + "</a></h6></div></div>";
        return $("<div class='media-list media-list-hover media-list-divided inner-user-div'></div>")
            .data("ui-autocomplete-item", item)
            .append(inner_html)
            .appendTo(ul);
    };

    //Kullanıcı authenticate ise çalışmalı countlar

    GetNotificationCount();
    
    setInterval(function () {
        GetNotificationCount();
    }, 3000);
});

//Notification butonuna tıklandığında yapılacak işlemler için JS Promise yapısı. 
function CommentNotificationPromise() {

    //GetCommentNotification
    var firstFunction = function () {
        return new Promise(function (resolve) {
            GetCommentNotification();
            console.log("İlk then çalıştı. (GetCommentNotification)");
            resolve();
        });
    };

    //NotificationUpdateIsShown
    var secondFunction = function () {
        return new Promise(function (resolve) {
            NotificationUpdateIsShown();
            console.log("İkinci then çalıştı. (NotificationUpdateIsShown)");
            resolve();
        });
    };

    //GetNotificationCount
    var thirdFunction = function () {
        return new Promise(function (resolve) {
            GetNotificationCount();
            console.log("Üçüncü then çalıştı. (GetNotificationCount)");
            resolve();
        });
    };

    //Promise Zinciri başladı.
    firstFunction().then(secondFunction).then(thirdFunction);
}

function CommentNotificationRefresh() {
    GetCommentNotification();
}

function GetCommentNotification() {
    $.ajax({
        type: 'GET',
        url: '/Common/CommentNotification',
        success: function (msg) {
            if (msg) {
                /*Slim Scroll*/
                $('.slimScrollAdd').slimScroll({
                    height: '100%'
                });
                if (msg.includes("Yeni bildiriminiz bulunmuyor."))
                {
                    $("#commentnotification").html(msg);
                    $("#btnAllNotificationsDelete").attr("disabled", true);
                }
                else {
                    $("#commentnotification").html(msg);
                    $("#btnAllNotificationsDelete").attr("disabled", false);
                }
            }
            else {
                $("#commentnotification").html("<div style='text-align:center'>Bildiriminiz bulunmuyor.</div>");

            }
        },
        error: function () {
            $("#commentnotification").html("<div style='text-align:center'>Hata.</div>");
        },
        beforeSend: function () {
            //todo: serkan  - çalışmıyor
            $("#commentnotification").html("<div style='text-align:center'><img src='/assets/vendor_components/x-editable/dist/bootstrap3-editable/img/loading.gif' /></div>");
        }
    });
}

function GetNotificationCount() {
    $.ajax({
        type: 'GET',
        url: '/Common/GetNotificationCount',
        success: function (msg) {
            if (msg === 0) {
                $("#notificationCount").text("");
            } else {
                $("#notificationCount").text(msg);
            }
        },
        error: function () {

        }
    });
}

function NotificationUpdateIsDelete(element) {
    var commentId = $(element).data("commentid");
    $.ajax({
        type: 'POST',
        url: '/Common/UpdateIsDelete',
        data: {
            'commentId': commentId
        },
        success: function () {
            $(element).parent().remove();

            if ($(".subDiv").length === 0)
            {
                $("#commentnotification").html("<style>.mainDiv: hover {background-color: cornsilk;}.subDiv: hover {background-color: lightyellow;}</style ><p>Yeni bildiriminiz bulunmuyor.</p>");
                $("#btnAllNotificationsDelete").attr("disabled", true);

            }
        },
        error: function () {
            
        }
    });
}

function AllNotificationDeletePromise() {

    //GetCommentNotification
    var firstFunction = function () {
        return new Promise(function (resolve) {
            NotificationAllUpdateIsDelete();
            //console.log("İlk then çalıştı. (NotificationAllUpdateIsDelete)");
            resolve();
        });
    };

    //NotificationUpdateIsShown
    var secondFunction = function () {
        return new Promise(function (resolve) {
            GetCommentNotification();
            //console.log("İkinci then çalıştı. (GetCommentNotification)");
            resolve();
        });
    };

    firstFunction().then(setTimeout(function () { secondFunction(); }, 500));
}

function NotificationAllUpdateIsDelete() {
    var r = confirm("Bildirimlerin hepsini silmek istediğinize eminmisiniz ?");
    if (r === true) {
        $.ajax({
            type: 'POST',
            url: '/Common/UpdateAllIsDelete',
            success: function ()
            {
                $("#commentnotification").html();

                //setTimeout(function ()
                //{
                //    GetCommentNotification();
                //}, 1000);
            },
            error: function () {

            }
        });
    } else {
        console.log("Bildirimlerin tümünü silmekten vazgeçildi.");
    }

    
}

function NotificationUpdateIsShown() {
    $.ajax({
        type: 'POST',
        url: '/Common/UpdateIsShown',
        success: function (msg) {

        },
        error: function () {

        }
    });
}

/*En çok beğeniye sahip olan kullanıcıları getirir*/
function GetMostLikedUsers() {
    $.ajax({
        type: 'GET',
        url: '/Common/GetLikedUserList',
        success: function (msg) {
            if (msg) {
                $("#MostLikedUsers").html(msg);

                /*Slim Scroll*/
                $('.slimScrollAdd').slimScroll({
                    height: '350px'
                });

            }
            else {
                $("#MostLikedUsers").html("<div style='text-align:center'>Günün en çok beğeni alan kullanıcıları getirilemedi.</div>");

            }
        },
        error: function () {
            $("#MostLikedUsers").html("<div style='text-align:center'>Günün en çok beğeni alan kullanıcıları getirilemedi.</div>");
        },
        beforeSend: function () {
            //todo: serkan  - çalışmıyor
            $("#MostLikedUsers").html("<div style='text-align:center'><img src='/assets/vendor_components/x-editable/dist/bootstrap3-editable/img/loading.gif' /></div>");
        }
    });
}

/*Takip etme*/
function AddScribe(element, targetUserId, type) {

    $.ajax({
        type: 'GET',
        url: '/User/AddScribe',
        data: {
            'targetUserId': targetUserId

        },
        success: function (msg) {
            if (msg.status) {
                if (type === "toplikes") {
                    $(element).switchClass("btn-success", "btn-danger");
                    $(element).removeAttr("onclick");
                    $(element).attr("onclick", "UnScribe(this," + targetUserId + ",'toplikes')");
                    $(element).text("Takibi Bırak");
                }
                else if (type === "profile") {
                    $(element).switchClass("btn-success", "btn-danger");
                    $(element).removeAttr("onclick");
                    $(element).attr("onclick", "UnScribe(this," + targetUserId + ",'profile')");
                    $(element).text("Takibi Bırak");
                }
                else {
                    $(element).removeAttr("onclick");
                    $(element).attr("onclick", "UnScribe(this," + targetUserId + ",'comment')");
                    $(element).html('<i class="fa fa-user-times"></i>Takibi Bırak');
                }
            }
            else {
                alert(msg.message);
            }
        },
        error: function () {
            alert(errmsg);
        }
    });
}

/*Takip etmeyi kaldırma*/
function UnScribe(element, targetUserId, type) {

    $.ajax({
        type: 'GET',
        url: '/User/UnScribe',
        data: {
            'targetUserId': targetUserId
        },
        success: function (msg) {
            if (msg.status) {
                if (type === "toplikes") {
                    $(element).switchClass("btn-danger", "btn-success");
                    $(element).removeAttr("onclick");
                    $(element).attr("onclick", "AddScribe(this," + targetUserId + ",'toplikes')");
                    $(element).text("Takip Et");
                }
                else if (type === "profile") {
                    $(element).switchClass("btn-danger", "btn-success");
                    $(element).removeAttr("onclick");
                    $(element).attr("onclick", "AddScribe(this," + targetUserId + ",'profile')");
                    $(element).text("Takip Et");
                }
                else {
                    $(element).removeAttr("onclick");
                    $(element).attr("onclick", "AddScribe(this," + targetUserId + ",'comment')");
                    $(element).html('<i class="fa fa-user-plus"></i>Takip Et');
                }
            }
            else {
                alert(msg.message);
            }
        },
        error: function () {
            alert(errmsg);
        }
    });
};

/*Açık piyasalar widget*/
function GetOpenMarkets() {
    $.ajax({
        type: 'GET',
        url: '/Common/OpenMarket',
        success: function (msg) {
            if (msg) {
                $("#openMarkets").html(msg);
                /*Slim Scroll*/
                $('.slimScrollAdd').slimScroll({
                    height: '350px'
                });
                /*Open Market*/
                $(".market-close").hide();


                /*Open Market*/
                $(".widget-markets > div > a").on("click", function () {

                    var title = $(this).html();

                    if (title === "Açık Piyasalar") {
                        $(this).html("Tümünü Göster");
                        $(".market-close").hide();
                        $(".market-open").show();
                    }
                    else {
                        $(this).html("Açık Piyasalar");
                        $(".market-close").show();
                        $(".market-open").show();
                    }

                });

            }
            else {
                $("#openMarkets").html("<div class='alert alert-danger' style='text-align:center'>Piyasalar getirilemedi.</div>");
            }

        },
        error: function () {
            $("#openMarkets").html("<div class='alert alert-danger' style='text-align:center'>Piyasalar getirilemedi.</div>");
            //alert("İşlem sırasında istenmeyen hata");
        },
        beforeSend: function () {
            //todo: serkan  - çalışmıyor
            $("#openMarkets").html("<div style='text-align:center'><img src='/assets/vendor_components/x-editable/dist/bootstrap3-editable/img/loading.gif' /></div>");
        }
    });
}

/*Ekonomik takvim widget*/
function GetEconomicCalendar() {

    $.ajax({
        type: 'GET',
        url: '/Common/EconomicCalendarWidget',
        success: function (msg) {
            if (msg) {
                $("#EconomicCalendar").html(msg);
                /*Slim Scroll*/
                $('.slimScrollAdd').slimScroll({
                    height: '350px'
                });
            }
            else {
                $("#EconomicCalendar").html("<div class='alert alert-danger ' style='text-align:center'>Ekonomik Takvim getirilemedi.</div>");
            }

        },
        beforeSend: function () {
            //todo: serkan  - çalışmıyor
            $("#EconomicCalendar").html("<div style='text-align:center'><img src='/assets/vendor_components/x-editable/dist/bootstrap3-editable/img/loading.gif' /></div>");
        },
        error: function () {
            $("#EconomicCalendar").html("<div class='alert alert-danger ' style='text-align:center'>Ekonomik Takvim getirilemedi.</div>");
            //alert("İşlem sırasında istenmeyen hata");
        }
    });
}

//Feedback formu email gönderim scripti
$("#frmFeedback").validate({
    rules:
    {
        Email:
        {
            required: true,
            maxlength: 30,
            email: true
        },
        Message:
        {
            required: true,
            minlength: 3,
            maxlength: 50,
        }
    },
    messages: {
        Email: {
            required: "Boş geçilemez",
            maxlength: "En fazla 40 karakter giriniz",
            email: "Geçerli bir E-posta giriniz"
        },
        Message: {
            required: "Boş geçilemez",
            maxlength: "En fazla 50 karakter giriniz",
            minlength: "En az 3 karakter giriniz",
        }
    },

    //Todo: Aykut element id leri benzersiz olmalı - Serkan diğerleri de sende
    submitHandler: function () {
        var eml = $('#Email').val();
        var msg = $('#Message').val();
        $("#frmFeedback").find(":submit").prop('disabled', true);
        $("#frmFeedback").find(":submit").html("Bildiriminiz gönderiliyor.");

        var model = {
            Email: eml,
            Message: msg
        };

        $.ajax({
            type: 'POST',
            url: '/Common/SendFeedback',
            data: {
                'model': model
            },
            success: function (msgg) {
                if (msgg.status === true) {
                    $("#feedback_result").append("<div class='alert alert-success'> " + msgg.message + " </div>");
                    $('#Message').val('');
                }
                else {
                    $("#feedback_result").append("<div class='alert alert-danger'> " + msgg.message + " </div>");
                    $('#Message').val('');
                }
                $("#frmFeedback").find(":submit").prop('disabled', false);
                $("#frmFeedback").find(":submit").html("Gönder");
            },
            error: function () {
                $("#feedback_result").append("<div class='alert alert-danger'> " + errmsg + " </div>");
                $("#frmFeedback").find(":submit").prop('disabled', false);
                $("#frmFeedback").find(":submit").html("Gönder");
            }
        });
    }
});

//Cookie uyarısı
window.addEventListener("load", function () {
    window.cookieconsent.initialise({
        "palette": {
            "popup": {
                "background": "#646478", // şerit arkaplan rengi
                "text": "#ffffff" // şerit üzerindeki yazı rengi
            },
            "button": {
                "background": "#8ec760", // buton arkaplan rengi - "transparent" kullanıp border açabilirsiniz.
                //"border": "#14a7d0", arkaplan rengini transparent yapıp çerçeve kullanabilirsini
                "text": "#ffffff" // buton yazı rengi
            }
        },
        "theme": "classic", // kullanabileceğiniz temalar block, edgeless, classic
        // "type": "opt-out", gizle uyarısını aktif etmek için
        // "position": "top", aktif ederseniz uyarı üst kısımda görünür
        // "position": "top", "static": true, aktif ederseniz uyarı üst kısımda sabit olarak görünür
        // "position": "bottom-left", aktif ederseniz uyarı solda görünür
        //"position": "bottom-right", aktif ederseniz uyarı sağda görünür

        "content": {
            "message": "Sitemizden en iyi şekilde faydalanabilmeniz için çerezler kullanılmaktadır. Bu siteye giriş yaparak çerez kullanımını kabul etmiş sayılıyorsunuz.",
            "dismiss": "Tamam",
            "link": "Daha fazla bilgi",
            "href": "/cerez-politikasi"
        }
    })
});
