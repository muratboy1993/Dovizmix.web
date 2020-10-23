"use strict";
$(document).ready(function () {

    /*Query Type Set Active*/

    var pathArray = window.location.pathname.split('/');
    var queryType = pathArray[2];

    //Yorum eklendikten sonra eğer sayfa 1.sayfa değilse ve queryType Tumu değilse data eklendikten sonraki veri getirilmeyecek. Onun için.
    $("#QueryType").val(queryType);
    $("#PageCount").val(pathArray[4]);

    switch (queryType) {

        case "Tumu":
            $("#rdAll").attr('checked', true);
            break;
        case "TakipEdilen":
            $("#rdSubscribe").attr('checked', true);
            break;
        case "Grafik":
            $("#rdGraphics").attr('checked', true);
            break;
        case "Anket":
            $("#rdPoll").attr('checked', true);
            break;
        case "Yildizli":
            $("#rdStarreds").attr('checked', true);
            break;
    }


    //Açık Kapalı Piyasalar
    $(".market-close").hide();

    /*Functions*/

    /*AddComment*/
    $("#FrmAddComment").validate({
        rules:
        {
            Message:
            {
                required: true,
                minlength: 3,
                maxlength: 5000
            }
        },
        messages: {

            Message: {
                required: "Lütfen yorum yazınız",
                minlength: "En az 3 karakter giriniz",
                maxlength: "En fazla 5 karakter giriniz"
            }
        }, submitHandler: function () {
            $("#btnCommentSend").html("Yorum Gönderiliyor...");
            $("#btnCommentSend").prop('disabled', true);
            var lastViewedCommentId = 0;

            if ($(".comment-list").length > 0) {
                lastViewedCommentId = $(".comment-list").first().attr("id").split("-")[1];
            }

            $("#LastViewedCommentId").val(lastViewedCommentId);
            

            $.ajax({
                type: 'POST',
                url: '/Comment/AddComment',
                data: new FormData($("#FrmAddComment")[0]),
                processData: false,
                contentType: false,
                success: function (msg) {
                    if (msg.status === true) {
                        $("#lblGraphicEkle").html('<i class="fa fa-plus-square"></i> \xa0 Grafik Ekle');
                        $(".no-comment-msg").remove();
                        $(".comment-header").after(msg.data);
                        $("#textMainComment").val("");
                        $("#GraphicPath").val("");
                        $("#btnCommentSend").html("Gönder");
                        $("#btnCommentSend").prop('disabled', false);
                        $("#LastViewedCommentId").val($(".comment-list").first().attr("id").split("-")[1]);
                        
                        if (msg.data !== null) {
                            var totalComment = $(".box-title").find("span").html();
                            totalComment = parseInt(totalComment) + 1;
                        } 
                        $(".box-title").find("span").html(totalComment);
                        //Grafikli yorum eklendikten sonra resmin üzerine tıklandığında popup açılması için kullanılıyor.
                        magnificPopup();
                    }
                    else {
                        alert(msg.message);
                        $("#btnCommentSend").html("Gönder");
                        $("#btnCommentSend").prop('disabled', false);
                    }

                },
                //todo: Aykut-Kaan-Moboy Tüm ajax isteklerinin cevapları sunucudan gelecek, error ksımı ise aşağıdaki gibi olacxak.
                error: function (error) {
                    $("#btnCommentSend").html("Gönder");
                    $("#btnCommentSend").prop('disabled', false);
                    alert(error.statusText);
                }
            });

            return false;
            //Todo :  serkan - Son Yorumlar eklenecek
        }

    });

    /*Yorum Tipi Seçimi*/

    $('input[name=QueryType]').change(function () {
        var pathArray = window.location.pathname.split('/');

        var queryType = $(this).val();

        var returmUrl = "/" + pathArray[1] + "/" + queryType + "/" + pathArray[3] + "/" + pathArray[4];

        window.location.href = returmUrl;
    });




    /*Oy verme AddPollVote çağrılıyor*/
    //$('input[name=poolOptionRadio]').change(function () {
    //    var option = $(this);
    //    var optionid = $(option).data("optionid");
    //    var pollid = $(option).data("pollid");

    //    var model = {
    //        PollOptionId: optionid,
    //        PollId: pollid
    //    };

    //    AddPollVote(model, option);

    //});


    /*Anket ekleme*/
    $('#btnPoolAdd').on("click", function () {
        //Tüm alert'ler siliniyor
        $(".voteAlert").remove();
        $("#poll_result").html("");
        var message = $("#PollMessage").val();
        var opt = [];

        var requiredVote = true;
        var requiredMessage = true;

        //Mesaj boş mu dolu mu?
        if (message === "") {
            requiredMessage = false;
            $("#PollMessage").parent().append('<div class="alert alert-danger voteAlert">Boş geçilemez.</div>');
        }
        else {
            //maksimum ve minimum durum
            if (message.length < 3) {
                requiredMessage = false;
                $("#PollMessage").parent().append('<div class="alert alert-danger voteAlert">Minimum 3 karakter girmelisiniz.</div>');
            }
            if (message.length > 50) {
                requiredMessage = false;
                $("#PollMessage").parent().append('<div class="alert alert-danger voteAlert">Maksimum 50 karakter girmelisiniz.</div>');
            }
        }

        $(".vote").each(function () {
            if ($(this).val() === "") {
                $(this).parent().append('<div class="alert alert-danger voteAlert">Boş geçilemez</div>');
                requiredVote = false;
            } else {
                if ($(this).val().length < 3) {
                    requiredVote = false;
                    $(this).parent().append('<div class="alert alert-danger voteAlert">Minimum 3 karakter girmelisiniz.</div>');
                }
                if ($(this).val().length > 50) {
                    requiredVote = false;
                    $(this).parent().append('<div class="alert alert-danger voteAlert">Maksimum 50 karakter girmelisiniz.</div>');
                }
            }
        });

        if (requiredMessage && requiredVote) {
            $("#frmAddPoll").find(":button").prop('disabled', true);
            $("#frmAddPoll").find(":button").html("Anketiniz oluşturuluyor..");

            var x = 0;
            $(".vote").each(function () {
                opt.push($(this).val());
                x++;
            });

            $.ajax({
                type: 'POST',
                url: '/Comment/AddPoll',
                data: new FormData($("#frmAddPoll")[0]),
                processData: false,  // JQuery'ye veriyi process etmemesini söyle
                contentType: false,   // JQuery'ye içerik tipini set etmemesini söyle,
                enctype: 'multipart/form-data',
                success: function (msgg) {
                    if (msgg.status === true) {
                        $("#lblGrafikEkle").html('<i class="fa fa-plus-square"></i> \xa0 Grafik Ekle');
                        $("#poll_result").append("<div class='alert alert-success'> " + msgg.message + " </div>");
                        setTimeout(function () {
                            window.location.reload(true);
                        }, 1000);
                    }
                    else {
                        $("#poll_result").append("<div class='alert alert-danger'> " + msgg.message + " </div>");
                    }
                    $("#frmAddPoll").find(":button").prop('disabled', false);
                    $("#frmAddPoll").find(":button").html("Anket Oluştur");
                },
                error: function () {
                    $("#poll_result").append("<div class='alert alert-danger'> İşlem sırasında istenmeyen hata meydana geldi. </div>");
                    $("#frmAddPoll").find(":button").prop('disabled', false);
                    $("#frmAddPoll").find(":button").html("Anket Oluştur");
                }
            });
        }
    });

    /*Seçenek ekleme*/
    $("#btnOptionAdd").click(function () {

        var countVote = $(".vote").length;
        if (countVote >= 5) {
            alert("En fazla 5 seçenek olabilir");
        } else {
            $("div#addOptions").append('<div class="form-group"><div class="input-group input-group-sm"><input type="text" class= "form-control vote" id="Options" name="Options" placeholder="Seçenek"><span class="input-group-btn"><a class="btn btn-info btn-flat" href="#" onclick="RemovePool(this)"><i class="fa fa-remove"></i></a></span></div></div>');
        }
    });

    /*Son Yapılan yorumlar GetLastComments cağrılıyor*/
    setInterval(function () {
        //Sayfa 1 ise ve tüm yorumlar sayfası ise
        if (window.location.href.split("/")[4].toLowerCase() === "tumu" && window.location.href.split("/")[6] === "1") {
            GetLastComments();
        }
    }, 3000);

    /*Oto sayfa yenilemesi*/
    setInterval(function () {
        window.location.reload(true);
    }, 5550000);
});

function PollOptionChange(element) {
    var optionid = $(element).data("optionid");
    var pollid = $(element).data("pollid");

    var model = {
        PollOptionId: optionid,
        PollId: pollid
    };

    AddPollVote(model, element);
}

/*Oy verme*/
function AddPollVote(model, opt) {
    $.ajax({
        type: 'POST',
        url: '/Comment/AddPollVote',
        data: {
            'model': model
        },
        success: function (msg) {
            if (msg.status) {

                $(opt).parent().parent().find("span").show();
                $(opt).attr("checked", "");

                $(opt).parent().parent().find("input").each(function () {

                    if ($(this).data("optionid") !== $(opt).data("optionid")) {
                        $(this).attr("disabled", "true");
                    }
                });

                var voteCount = 0;
                //Ekleme işleminden sonra dönen data üzerinde işlem yapılıyor.

                for (var i = 0; i < msg.data.length; i++) {
                    voteCount += msg.data[i].vote;
                }
                $("#poolid-" + $(opt).data("pollid")).text(voteCount);

                for (var j = 0; j < msg.data.length; j++) {
                    var option = msg.data[j];
                    var oran = option.vote / voteCount * 100;
                    var li = $("#answer-" + option.optionId + "").parent();
                    $(li).find(".perc-back").show().css("width", oran + "%");
                    $(li).find(".perc-number").show().html(oran + "%");
                }
            }
            else {

                setTimeout(function () {
                    alert(msg.message);
                }, 200);
            }

        },
        error: function (error) {
            if (error.status === 401) {
                setTimeout(function () {
                    alert("Bu işlem için kullanıcı girişi yapınız.");
                }, 200);
            }
            else {
                alert("İşlem sırasında istenmeyen hata.");
            }
        }
    });
}

/*Yorum beğenme yada beğenmeme*/
function LikeOrDislike(element, puan) {
    var commentId = $(element).data("commentid");

    var likeModel = {

        CommentId: 0,
        LikeOrDislike: false
    };

    likeModel.CommentId = commentId;

    if (puan === 1) {
        likeModel.LikeOrDislike = true;
    }
    else {
        likeModel.LikeOrDislike = false;
    }


    $.ajax({
        type: 'POST',
        url: '/Comment/LikeOrDislikeComment',
        data: {
            'model': likeModel

        },
        success: function (msg) {
            if (msg.status) {
                var likeSpan = $(element).find("span");

                if (likeModel.LikeOrDislike) {
                    //Like Count Change
                    $(likeSpan).html(msg.data.likeCount);

                    //UnLike Count Change
                    var navdot = $(element).parent().parent();
                    var ele = $(navdot).children(2)[1];
                    $(ele).find("span").html(msg.data.dislikeCount);
                }
                else {
                    //Like Count Change
                    $(likeSpan).html(msg.data.dislikeCount);

                    //UnLike Count Change
                    navdot = $(element).parent().parent();
                    ele = $(navdot).children(1)[0];
                    $(ele).find("span").html(msg.data.likeCount);
                }
            }
            else {
                alert(msg.message);
            }
        },
        error: function (error) {

            if (error.status === 401) {
                alert("Bu işlem için kullanıcı girişi yapınız.");
            }
            else {
                alert(errmsg);
            }

        }
    });
}

/*Yoruma cevap verme*/
function Reply(element) {
    removeReplyElement();

    var commentId = $(element).data("commentid");
    var marketid = $(element).data("marketid");


    var div = $(element).parent().parent().parent().parent().parent();

    $(div).append("<form role='form' action='/Comment/AddComment' method='post' id='FrmSubAddComment' class='ReplyForm'><div class='form-group'><input type='hidden' name='MarketId' value='" + marketid + "'><input type='hidden' name='CommentParentId' value='" + commentId + "' /><textarea id='txtSubComment' name='Message' class='form-control' rows='3' placeholder='Yorumunuzu buraya yazınız...' onkeyup='MessageControl(this)' onkeydown='MessageControl(this)'></textarea><div><label>Kalan : </label><label class='lblCommentCharacterCount'> 5000</label></div></div><div class='form-group'><button id='btnSubCommentSend' type='submit' class='btn btn-success'>Gönder </button><button type='submit' class='btn btn-danger' onclick='removeReplyElement()'>Kapat</button></div><input type='hidden' id='LastViewedCommentId' name='LastViewedCommentId' value='" + $(".comment-list").first().attr("id").split("-")[1] + "'></form>");

    $("#FrmSubAddComment").validate({
        rules:
        {
            Message:
            {
                required: true,
                minlength: 3,
                maxlength: 5000
            }
        },
        messages: {
            Message: {
                required: "Lütfen yorum yazınız",
                minlength: "En az 3 karakter giriniz",
                maxlength: "En fazla 5000 karakter giriniz"
            }
        }, submitHandler: function () {
            $("#btnSubCommentSend").html("Yorum Gönderiliyor...");
            $("#btnSubCommentSend").prop('disabled', true);

            var lastViewedCommentId = 0;

            if ($(".comment-list").length > 0) {
                lastViewedCommentId = $(".comment-list").first().attr("id").split("-")[1];
            }

            $("#LastViewedCommentId").val(lastViewedCommentId);

            $.ajax({
                type: 'POST',
                url: '/Comment/AddComment',
                data: new FormData($("#FrmSubAddComment")[0]),
                processData: false,
                contentType: false,
                success: function (msg) {
                    if (msg.status === true) {
                        $(".no-comment-msg").remove();
                        $(".comment-header").after(msg.data);
                        removeReplyElement();
                        $("#txtSubComment").val("");

                        $("#btnSubCommentSend").html("Gönder");
                        $("#btnSubCommentSend").prop('disabled', false);
                        $("#LastViewedCommentId").val($(".comment-list").first().attr("id").split("-")[1]);
                    }
                    else {
                        alert("Yorum Eklenemedi");
                        $("#btnSubCommentSend").html("Gönder");
                        $("#btnSubCommentSend").prop('disabled', false);
                    }

                },
                error: function () {
                    $("#btnSubCommentSend").html("Gönder");
                    $("#btnSubCommentSend").prop('disabled', false);
                    alert(errmsg);
                }
            });

            return false;


            //Todo :  serkan - Son Yorumlar eklenecek
        }
    });
}

/*cevap elementini silme*/
function removeReplyElement() {
    $(".ReplyForm").remove();

}

/*Yorum getirme(parent)*/
function GetComment(parentId, mediaId, removeElement) {


    var paddingMedia = "#media-" + mediaId;
    //var parentCommentDiv = "#" + mediaId + "-parentCommentDiv";

    $.ajax({
        type: 'GET',
        url: '/Comment/GetComment',
        data:
        {
            'commentId': parentId
        },
        success: function (msg) {
            if (msg !== "") {
                $(paddingMedia).addClass("subCommentPadding");
                $(paddingMedia).before(msg);
            }
            $(removeElement).parent("div").remove();
        }
    });

}

/*Kullanıcı engelleme*/
function AddBlock(element, targetUserId, type) {

    $.ajax({
        type: 'GET',
        url: '/User/AddBlock',
        data: {
            'targetUserId': targetUserId
        },
        success: function (msg) {
            if (msg.status) {
                if (type === "profile") {
                    $(element).switchClass("btn-danger", "btn-warning");
                    $(element).removeAttr("onclick");
                    $(element).attr("onclick", "UnBlock(this," + targetUserId + ",'profile')");
                    $(element).text("Engeli Kaldır");
                }
                else {
                    $(element).remove();
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

/*Grafik yükleme*/
function UploadGraphics() {

    var img = $("#GraphicPath");
    var iy = img[0].files[0].name.toLowerCase();
    var l = iy.split(".");
    var uza = l[l.length - 1];
    if (uza === "gif" || uza === "bmp" || uza === "jpg" || uza === "jpeg" || uza === "png") {
        if (img[0].files[0].size <= 1048576) {
            $("#lblGraphicEkle").html('<i class="fa fa-plus-square"></i> \xa0' + iy);
            //$("#lblGraphicEkle").text(iy);
            return true;
        }
        else {
            alert("Maksimum 1MB olmalı.");
            $("#GraphicPath").val("");
        }

    } else {
        setTimeout(function () {
            alert("Gönderdiğiniz fotoğraf dosyası jpg, gif, png, bmp formatında olmalıdır.");
            $("#GraphicPath").val("");
        }, 10);
        return false;
    }

}

/*Son Yapılan yorumlar*/
function GetLastComments() {
    var MarketId = $("#MarketId").val();
    var LastViewedCommentId = $("#LastViewedCommentId").val();

    $.ajax({
        type: 'POST',
        url: '/Comment/GetNewComments',
        data: {
            'lastCommentId': LastViewedCommentId,
            'marketId': MarketId
        },
        success: function (msg) {
            if (msg.status) {
                if ($(".comments-body").length === 0) {
                    $(".no-comment-msg").remove();
                    $(".comment-header").next().remove();
                }

                var totalComment = $(".box-title").find("span").html();

                totalComment = parseInt(totalComment) + 1;
                $(".box-title").find("span").html(totalComment);

                $(".comment-header").after(msg.data);

            }

            $("#LastViewedCommentId").val(msg.message);
        },
        error: function () {
            //alert(errmsg);
        }
    });
    return false;
}

/*Yazılabilecek kalan karakter sayısını hesaplayıp kullanıcıya gösterme*/
function MessageControl(element) {
    //var comment = element.value;
    //var indexOf = comment.indexOf("@@");

    //console.log(indexOf);

    //var s = comment.substr(comment.length - indexOf, indexOf + 1);
    //console.log(s.split("@@")[1]);

    var characterLimit = 5000;
    var messageLength = element.value.length;
    if (characterLimit >= messageLength) {
        var remaining = characterLimit - messageLength;
        if ($(element).attr("id") === "description") {
            $(element).parent().parent().find(".lblCommentCharacterCount").html(" " + remaining);
        }
        else {
            $(element).parent().find(".lblCommentCharacterCount").html(" " + remaining);
        }
    } else {
        element.value = element.value.substr(0, characterLimit);
    }
    //var regex = "/\@@[a-z]+/g";
    //const regex = /\@@[a-z]+/g;

    //let m;

    //while ((m = regex.exec(element.value)) !== null)
    //{
    //    // This is necessary to avoid infinite loops with zero-width matches
    //    if (m.index === regex.lastIndex)
    //    {
    //        regex.lastIndex++;

    //    }

    //    // The result can be accessed through the `m`-variable.
    //    m.forEach((match, groupIndex) =>
    //    {
    //        //console.log(`Found match, group ${groupIndex}: ${match}`);
    //        console.log(match);
    //    });
    //}
    //}
    /*Kullanıcının yazdığı yorum localde tutuluyor.*/
    //localStorage.removeItem("localComment");
    //localStorage.setItem("localComment", element.value.substr(0, characterLimit));
}

/*Anket silme*/
function RemovePool(i) {
    $(i).parent().parent().remove();
}

/*Ankete grafik yükleme*/
function PollUploadGraphics() {
    var img = $("#PollGraphicPath");
    var iy = img[0].files[0].name.toLowerCase();
    var l = iy.split(".");
    var uza = l[l.length - 1];
    if (uza === "gif" || uza === "bmp" || uza === "jpg" || uza === "jpeg" || uza === "png") {
        if (img[0].files[0].size <= 1048576) {
            $("#lblGrafikEkle").html('<i class="fa fa-plus-square"></i> \xa0' + iy);
            //$("#lblGrafikEkle").text(iy);
            return true;
        }
        else {
            alert("Maksimum 1MB olmalı.");
            $("#PollGraphicPath").val("");
        }
    }
    else {
        setTimeout(function () {
            alert("Gönderdiğiniz fotoğraf dosyası jpg, gif, png, bmp formatında olmalıdır.");
            $("#PollGraphicPath").val("");
        }, 10);
        return false;
    }

}

//yorum yaparken kullanıcıları arama
function TextareaSearch(element) {
    var check = element.value.split(/\s+/).pop();
    if (check.indexOf("@") !== -1) {
        var split = check.split("@");
        $("#textMainComment").autocomplete({
            source: function (request, response) {
                if (split !== null) {
                    $.ajax({
                        url: "/User/SearchUsername",
                        dataType: "json",
                        data:
                        {
                            username: split[split.length - 1]
                        },
                        success: function (data) {
                            split = null;
                            response($.map(data, function (item) {

                                return {
                                    label: item.username,
                                    value: item.username,
                                    avatar: item.avatarPath,
                                };
                            }));
                        }, error: function (err) {
                            console.log(err);
                        }
                    });
                }
                else {
                    $("#textMainComment").autocomplete("close");
                }
            },
            minLength: 3,
            focus: function () {
                // prevent value inserted on focus
                return false;
            },
            select: function (event, ui) {
                var rest = this.value.substring(0, this.value.lastIndexOf("@"));
                this.value = rest + "@" + ui.item.value;
                return false;
            }
        }).data("ui-autocomplete")._renderItem = function (ul, item) {
            var inner_html = "<div class='media media-single'><a href='#'><img class='avatar' src='/assets/images/avatar/" + item.avatar + "' alt='...'></a><div class='media-body'><h6><a href='#'>" + item.label + "</a></h6></div></div>";
            return $("<div class='media-list media-list-hover media-list-divided inner-user-div'></div>")
                .data("ui-autocomplete-item", item)
                .append(inner_html)
                .appendTo(ul);
        };
    }
};