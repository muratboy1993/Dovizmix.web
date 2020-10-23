var characterLimit = 5000;
/*Sayfa ilk açıldığında kişisel görüşün karalter sayısına bakılıyor*/
var txtOpinionElement = window.document.getElementById("PersonalOpinion");
MessageControl(txtOpinionElement);

/*Yazılabilecek kalan karakter sayısını hesaplayıp kullanıcıya gösterme*/
function MessageControl(element) {
    var messageLength = element.value.length;
    if (characterLimit >= messageLength) {
        var remaining = characterLimit - messageLength;
        $(element).parent().find(".lblCommentCharacterCount").html(" " + remaining);

    } else {
        element.value = element.value.substr(0, characterLimit);
    }
}

/*Avatar silme işlemi */
function RemoveAvatar() {

    $.ajax({
        type: 'DELETE',
        url: '/Profile/RemoveAvatar',
        success: function (msg) {
            if (msg.status) {
                /*Silme işlemi başarılı ise*/
                $("#removeAvatarDiv").hide();
                $(".dropdown-toggle").find("img").attr("src", "/assets/images/avatar/empty.png");
                $("#profileSettingsAvatarImg").attr("src", "/assets/images/avatar/empty.png");
            }
            else {
                alert(errmsg);
            }

        },
        error: function () {
            alert(errmsg);
        }
    });
    $("#imgFile").val("");


}

/*Avatar değişirme işlemi */
function ChangeAvatar() {

    var img = $("#imgFile");
    var iy = img[0].files[0].name.toLowerCase();
    var l = iy.split(".");
    var uza = l[l.length - 1];
    if (uza === "gif" || uza === "bmp" || uza === "jpg" || uza === "jpeg" || uza === "png") {
        if (img[0].files[0].size <= 1048576) {
            $('#frmAvatarUpload').submit();
        }
        else {
            alert("Maksimum 1MB olmalı.");
        }

    } else {
        setTimeout(function () {
            alert("Gönderdiğiniz fotoğraf dosyası jpg, gif, png, bmp formatında olmalıdır.");
        }, 10);
        return false;
    }
}

//todo: Serkan - Mesajlar tek olabilir.
$(document).ready(function () {
    "use strict";

    /*Slim Scroll*/
    $('.bannedUserList').slimScroll({
        height: '232px'
    });

    $('#DateOfBirth').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        maxYear: parseInt(moment().format('YYYY'), 10),
        locale: {
            format: 'DD.MM.YYYY',
            "applyLabel": "Uygula",
            "cancelLabel": "Vazgeç",
            "daysOfWeek": [
                "Pt",
                "Sl",
                "Çr",
                "Pr",
                "Cm",
                "Ct",
                "Pz"
            ],
            "monthNames": [
                "Ocak",
                "Şubat",
                "Mart",
                "Nisan",
                "Mayıs",
                "Haziran",
                "Temmuz",
                "Ağustos",
                "Eylül",
                "Ekim",
                "Kasım",
                "Aralık"
            ]
        }
    });

    $('.select2').select2();

    /*Avatar yükleme form işlemleri*/
    $('#frmAvatarUpload').ajaxForm({
        beforeSend: function () {
            $('.progress').show();
            $('#status').empty();
            var percentVal = '0%';
            $('.bar').width(percentVal)
            $('.percent').html(percentVal);
        },
        uploadProgress: function (event, position, total, percentComplete) {
            var percentVal = percentComplete + '%';
            $('.bar').width(percentVal)
            $('.percent').html(percentVal);
        },
        success: function () {
            var percentVal = '100%';
            $('.bar').width(percentVal)
            $('.percent').html(percentVal);
        },
        complete: function (xhr)
        {
            if (xhr.readyState === 4)
            {
                if (xhr.status != 500)
                {
                    if (xhr.responseJSON.status) {
                        $("#removeAvatarDiv").show();
                        //$('#status').html("<div class='alert alert-success'> " + xhr.responseJSON.message + "</div>");
                        var newImg = xhr.responseJSON.data;
                        $(".dropdown-toggle").find("img").attr("src", "/assets/images/avatar/" + newImg);
                        $(".user-header").find("img").attr("src", "/assets/images/avatar/" + newImg);
                        $("#profileSettingsAvatarImg").attr("src", "/assets/images/avatar/" + newImg);

                        $(".progress").hide();
                    } else {
                        $('#status').html("<div class='alert alert-danger'> " + xhr.responseJSON.message + "</div>");
                        $(".progress").hide();
                    }
                }
                else
                {

                    $('.progress').hide();
                    $('.bar').width(0)
                    $('.percent').html(0);

                    alert(errmsg);
                }
            }
          
        }

    });

    /*Email aktivayonu işlemi*/
    $("#frmActivation").validate({
        rules:
        {
            activationCode:
            {
                required: true,
                maxlength: 6
            }
        },
        messages: {

            activationCode:
            {
                required: "Boş geçilemez",
                maxlength: "En fazla 6 karakter giriniz"
            }
        },
        submitHandler: function () {
            var activationCode = $("#activationCode").val();

            $("#activationResult").html("");
            $("#activationResult").hide();


            $.ajax({
                type: 'POST',
                url: '/Profile/Activation',
                data:
                {
                    'reqActivation': activationCode
                },
                success: function (msg) {
                    if (msg.status) {
                        $("#activationResult").show();
                        window.location.reload(true);
                    }
                    else {
                        $("#activationResult").html('<div class="alert alert-danger"> ' + msg.message + '</div>');
                        $("#activationResult").show();
                        $("#activationResult").html(msg.message);
                    }
                },
                error: function () {
                    alert(errmsg);
                }
            });
            return false;
        }
    });

    /*Yeni aktivasyon kodu isteme işlemi*/
    $("#btnPostActivationCode").click(function () {
        $("#btnPostActivationCode").html("Kod yeniden göneriliyor...");
        $("#activationResult").hide();
        $.ajax({
            type: 'POST',
            url: '/Profile/PostActivation',
            success: function (msg) {
                if (msg.status) {
                    $("#btnPostActivationCode").html("Tekrar Gönder");
                    $("#activationResult").html('<div class="alert alert-success"> Aktivasyon kodunuz gönderildi.</div>');
                    $("#activationResult").show();
                }
                else {
                    alert(msg.message);
                    $("#btnPostActivationCode").html("Tekrar Gönder");
                }
            },
            error: function () {
                $("#btnPostActivationCode").html("Tekrar Gönder");
                alert(errmsg);
            }
        });


    });

    /*Şifre değiştirme*/
    $("#frmChangePassword").validate({
        rules:
        {
            oldPassword:
            {
                required: true,
                maxlength: 20,
                minlength: 6,
                atLeastOneUppercaseLetter: true,
                atLeastOneNumber: true,
                atLeastOneLowercaseLetter: true
            },
            newPassword:
            {
                required: true,
                maxlength: 20,
                minlength: 6,
                atLeastOneUppercaseLetter: true,
                atLeastOneNumber: true,
                atLeastOneLowercaseLetter: true
            },
            newPasswordReplay: {
                equalTo: '[name="newPassword"]'
            }
        },
        messages: {

            oldPassword:
            {
                required: "Boş geçilemez",
                maxlength: "En fazla 20 karakter giriniz",
                minlength: "En az 6 karakter giriniz."
            },
            newPassword:
            {
                required: "Boş geçilemez",
                maxlength: "En fazla 20 karakter giriniz",
                minlength: "En az 6 karakter giriniz."
            },
            newPasswordReplay:
            {
                equalTo: "Şifreler uyuşmuyor"
            }
        },
        submitHandler: function () {

            $("#frmChangePassword").find(":submit").html("Şifreniz değiştiriliyor...");
            $("#frmChangePassword").find(":submit").prop('disabled', true);

            var oldPassword = $("#oldPassword").val();
            var newPassword = $("#newPassword").val();


            var reqUpdatePasswordModel = {
                OldPwd: oldPassword,
                NewPwd: newPassword
            };


            $("#changePasswordResult").html("");
            $("#changePasswordResult").hide();


            $.ajax({
                type: 'POST',
                url: '/Profile/ChangePassword',
                data:
                {
                    'reqUpdatePassword': reqUpdatePasswordModel
                },
                success: function (msg) {
                    if (msg.status) {
                        $("#frmChangePassword").find(":submit").prop('disabled', false);
                        $("#frmChangePassword").find(":submit").html("Şifre Değiştir");
                        $("#changePasswordResult").show();
                        $("#changePasswordResult").html('<div class="alert alert-success"> ' + msg.message + '</div>');
                    }
                    else {
                        $("#frmChangePassword").find(":submit").prop('disabled', false);
                        $("#frmChangePassword").find(":submit").html("Şifre Değiştir");
                        $("#changePasswordResult").html('<div class="alert alert-danger"> ' + msg.message + '</div>');
                        $("#changePasswordResult").show();
                    }
                },
                error: function () {
                    $("#frmChangePassword").find(":submit").prop('disabled', false);
                    $("#frmChangePassword").find(":submit").html("Şifre Değiştir");
                    alert(errmsg);
                }
            });
            return false;
        }
    });

    /*Kişisel görüş değiştirme*/
    $("#frmPersonalOpinion").validate({
        rules:
        {
            PersonalOpinion:
            {
                maxlength: characterLimit
            }
        },
        messages: {

            PersonalOpinion:
            {
                maxlength: "En fazla " + characterLimit + " karakter giriniz",
            }

        },
        submitHandler: function () {
            $("#frmPersonalOpinion").find(":submit").html("Kişisel yorum değiştiriliyor...");
            $("#frmPersonalOpinion").find(":submit").prop('disabled', true);

            var opinion = $("#PersonalOpinion").val();

            $("#personalOpinionResult").html("");
            $("#personalOpinionResult").hide();


            $.ajax({
                type: 'POST',
                url: '/Profile/PostPersonalOpinion',
                data:
                {
                    'opinion': opinion
                },
                success: function (msg) {
                    if (msg.status) {
                        $("#frmPersonalOpinion").find(":submit").prop('disabled', false);
                        $("#frmPersonalOpinion").find(":submit").html("Kaydet");
                        $("#personalOpinionResult").show();
                        $("#personalOpinionResult").html('<div class="alert alert-success"> ' + msg.message + '</div>');
                    }
                    else {
                        $("#frmPersonalOpinion").find(":submit").prop('disabled', false);
                        $("#frmPersonalOpinion").find(":submit").html("Kaydet");
                        $("#personalOpinionResult").html('<div class="alert alert-danger"> ' + msg.message + '</div>');
                        $("#personalOpinionResult").show();

                    }

                },
                error: function () {
                    $("#frmPersonalOpinion").find(":submit").prop('disabled', false);
                    $("#frmPersonalOpinion").find(":submit").html("Kaydet");
                    alert(errmsg);
                }
            });
            return false;
        }
    });

    /*Hesap ayarlarındaki kişisel bilgileri güncelleme*/
    $("#frmPersonalInfo").validate({
        rules:
        {
            Name:
            {
                maxlength: 30
            },
            Surname:
            {
                maxlength: 30
            },
            TwitterProfile:
            {
                maxlength: 100
            },
            InstagramProfile:
            {
                maxlength: 100
            },
            FacebookProfile:
            {
                maxlength: 100
            }
        },
        messages: {

            Name:
            {
                maxlength: "En fazla 30 karakter giriniz"
            },
            Surname:
            {
                maxlength: "En fazla 30 karakter giriniz"
            },
            TwitterProfile:
            {
                maxlength: "En fazla 100 karakter giriniz"
            },
            InstagramProfile:
            {
                maxlength: "En fazla 100 karakter giriniz"
            },
            FacebookProfile:
            {
                maxlength: "En fazla 100 karakter giriniz"
            }
        },
        submitHandler: function () {
            $("#frmPersonalInfo").find(":submit").html("Kişisel bilgiler değiştiriliyor...");
            $("#frmPersonalInfo").find(":submit").prop('disabled', true);

            var reqUpdateProfile = {

                Name: $("#Name").val(),
                Surname: $("#Surname").val(),
                DateOfBirth: $("#DateOfBirth").val(),
                Job: $("#userModel_Job").val(),
                Gender: $("#userModel_Gender").val(),
                City: $("#userModel_City").val(),
                TwitterProfile: $("#TwitterProfile").val(),
                InstagramProfile: $("#InstagramProfile").val(),
                FacebookProfile: $("#FacebookProfile").val()
            };

            $("#personalInformationResult").html("");
            $("#personalInformationResult").hide();


            $.ajax({
                type: 'POST',
                url: '/Profile/UpdateProfile',
                data:
                {
                    'reqUpdateProfile': reqUpdateProfile
                },
                success: function (msg) {
                    if (msg.status) {
                        $("#frmPersonalInfo").find(":submit").prop('disabled', false);
                        $("#frmPersonalInfo").find(":submit").html("Kaydet");
                        $("#personalInformationResult").show();
                        $("#personalInformationResult").html('<div class="alert alert-success"> ' + msg.message + '</div>');
                    }
                    else {
                        $("#frmPersonalInfo").find(":submit").prop('disabled', false);
                        $("#frmPersonalInfo").find(":submit").html("Kaydet");
                        $("#personalInformationResult").html('<div class="alert alert-danger"> ' + msg.message + '</div>');
                        $("#personalInformationResult").show();

                    }

                },
                error: function () {
                    $("#frmPersonalInfo").find(":submit").prop('disabled', false);
                    $("#frmPersonalInfo").find(":submit").html("Kaydet");
                    alert(errmsg);
                }
            });
            return false;
        }
    });

    /* Custom validator for contains at least one lower -case letter*/
    $.validator.addMethod("atLeastOneLowercaseLetter", function (value, element) {
        return this.optional(element) || /[a-z]+/.test(value);
    }, "En az bir küçük karakter giriniz");

    /**
     * Custom validator for contains at least one upper-case letter.
     */
    $.validator.addMethod("atLeastOneUppercaseLetter", function (value, element) {
        return this.optional(element) || /[A-Z]+/.test(value);
    }, "En az bir büyük karakter giriniz");

    /**
     * Custom validator for contains at least one number.
     */
    $.validator.addMethod("atLeastOneNumber", function (value, element) {
        return this.optional(element) || /[0-9]+/.test(value);
    }, "En az bir sayı giriniz");
});