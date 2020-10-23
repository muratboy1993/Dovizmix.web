"use strict";

$(document).ready(function () {

    /*Beni Hatırla*/
    $("#RememberMe").on('change', function () {
        if ($(this).is(':checked')) {
            $(this).attr('value', 'true');
        } else {
            $(this).attr('value', 'false');
        }

    });

    /*Login işlemi*/
    $("#frmLogin").validate({
        rules:
        {
            UsernameOrEmail:
            {
                required: true,
                maxlength: 50
            },
            Password:
            {
                required: true
            }
        },
        messages: {

            UsernameOrEmail: {
                required: "Boş geçilemez",
                maxlength: "En fazla 50 karakter giriniz"
            },
            Password:
            {
                required: "Boş geçilemez"
            }
        },
        submitHandler: function () {
            var name = $("#UsernameOrEmail").val();
            var pass = $("#Password").val();
            var remember = $("#RememberMe").val();
            $("#frmLogin").find(":submit").html("Giriş yapılıyor...");
            $("#frmLogin").find(":submit").prop('disabled', true);

            var ReqLogin = {

                RememberMe: remember,
                Password: pass,
                UsernameOrEmail: name

            };
            $.ajax({
                type: 'POST',
                url: '/Account/Login',
                data:
                {
                    'model': ReqLogin
                },
                success: function (msg) {
                    if (msg.status === true) {
                        if (!msg.data) {
                            window.location.href = "/Profil/Ayarlar";
                        }
                        else {
                            window.location.reload(true);
                        }

                    }
                    else {
                        alert(msg.message);
                        $("#frmLogin").find(":submit").html("Giriş yap");
                        $("#frmLogin").find(":submit").prop('disabled', false);
                    }

                },
                error: function () {
                    alert(errmsg);
                    $("#frmLogin").find(":submit").html("Giriş yap");
                    $("#frmLogin").find(":submit").prop('disabled', false);
                }
            });
            return false;
        },
    });

    /*Şifremi unuttum işlemi*/
    $("#frmForgotPassword").validate({
        rules:
        {
            email:
            {
                required: true,
                maxlength: 50,
                email: true
            }
        },
        messages: {

            email: {
                required: "Boş geçilemez",
                maxlength: "En fazla 20 karakter giriniz",
                email: "Lütfen geçerli bir e-posta adresi girin."
            }
        },
        submitHandler: function () {
            $(".forgotPasswordResult").html("");
            $("#frmForgotPassword").find(":submit").html("Şifreniz gönderiliyor...");
            $("#frmForgotPassword").find(":submit").prop('disabled', true);
            var email = $("#email").val();

            $.ajax({
                type: 'POST',
                url: '/Account/ForgotPassword',
                data:
                {
                    'email': email
                },
                success: function (msg) {
                    if (msg.status === true) {
                        $(".forgotPasswordResult").append("<div class='alert alert-success'> " + msg.message + " </div>");
                    }
                    else {
                        $("#frmForgotPassword").find(":submit").html("Şifre Gönder");
                    }

                    $("#frmForgotPassword").find(":submit").prop('disabled', false);
                    $("#frmForgotPassword").find(":submit").html("Şifre Gönder");

                },
                error: function () {
                    $(".forgotPasswordResult").append("<div class='alert alert-danger'>" + errmsg + "</div>");
                    $("#frmForgotPassword").find(":submit").prop('disabled', false);
                    $("#frmForgotPassword").find(":submit").html("Şifre Gönder");
                }
            });


            return false;
        },
    });

    /*Kayıt olma işlemi*/
    $("#frmRegister").validate({
        rules:
        {
            Username:
            {
                required: true,
                maxlength: 20,
                minlength: 4
            },
            RegisterEmail:
            {
                required: true,
                maxlength: 50,
                email: true
            },
            ReqPassword:
            {
                required: true,
                maxlength: 20,
                minlength: 6,
                atLeastOneUppercaseLetter: true,
                atLeastOneNumber: true,
                atLeastOneLowercaseLetter: true
            },
            ReqPasswordCheck: {
                equalTo: '[name="ReqPassword"]',
            }
        },
        messages: {

            Username: {
                required: "Boş geçilemez",
                maxlength: "En fazla 20 karakter giriniz",
                minlength: "En az 4 karakter giriniz",
            },
            RegisterEmail: {
                required: "Boş geçilemez",
                maxlength: "En fazla 20 karakter giriniz",
                email: "Lütfen geçerli bir e-posta adresi girin."
            },
            ReqPassword:
            {
                required: "Boş geçilemez",
                maxlength: "En fazla 20 karakter giriniz",
                minlength: "En az 6 karakter giriniz."
            },
            ReqPasswordCheck:
            {
                equalTo: "Şifreler uyuşmuyor"
            }
        },
        submitHandler: function () {
            
            var Username = $("#Username").val();
            var Email = $("#RegisterEmail").val();
            var Password = $("#ReqPassword").val();
            var PasswordCheck = Password;
            $("#frmRegister").find(":submit").html("Kullanıcı kaydınız yapılıyor...");
            $("#frmRegister").find(":submit").prop('disabled', true);

            var model = {

                Username: Username,
                Email: Email,
                Password: Password,
                PasswordCheck: PasswordCheck

            };
            $.ajax({
                type: 'POST',
                url: '/Account/Register',
                data:
                {
                    'model': model

                },
                success: function (msg) {
                    if (msg.status === true) {
                        alert(msg.message);
                        window.location.href = "/Profil/Ayarlar";
                    }
                    else {
                        $("#registerResult").html("<div class='alert alert-danger'> " + msg.message + " </div>");
                        $("#frmRegister").find(":submit").html("Kayıt Yap");
                        $("#frmRegister").find(":submit").prop('disabled', false);
                    }

                },
                error: function () {
                    alert(errmsg);
                    $("#frmRegister").find(":submit").html("Kayıt Yap");
                    $("#frmRegister").find(":submit").prop('disabled', false);
                }
            });
            return false;
        }
    });

    /**
     * Custom validator for contains at least one lower-case letter
     */
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

    /*Kullanıcı adının varlığının kontrolü*/
    $("#frmRegister #Username").keyup(function () {

        if ($(this).val().length >= 4) {
            $.ajax({
                url: "/User/CheckUsername",
                dataType: "json",
                data:
                {
                    username: $(this).val()
                },
                success: function (data) {
                    if (data > 0) {
                        $("#frmRegister #Username").parent().find("span").css("color", "red");
                        $(".registerinvalidusername").remove();
                        $("#frmRegister #Username").parent().append('<div class="registerinvalidusername alert alert-danger">Bu Kullanıcı Adı daha önce alınmış.</div>');
                    }
                    else {
                        $("#frmRegister #Username").next("span").css("color", "#00cb82");
                        $(".registerinvalidusername").remove();
                        $("#frmRegister #Username").parent().find("span").css("color", "#495057");
                    }
                }, error: function (err) {
                    alert(errmsg);
                }
            });
        } else {
            $(".registerinvalidusername").remove();
        }

    });

    /*Emailin varlığının kontrolü*/
    $("#frmRegister #RegisterEmail").keyup(function () {

        if ($(this).val().length >= 7) {
            $.ajax({
                url: "/User/CheckEmail",
                dataType: "json",
                data:
                {
                    email: $(this).val()
                },
                success: function (data) {
                    if (data > 0) {
                        $("#frmRegister #RegisterEmail").parent().find("span").css("color", "red");
                        $(".registerinvalidemail").remove();
                        $("#frmRegister #RegisterEmail").parent().append('<div class="registerinvalidemail alert alert-danger">Bu Kullanıcı E-posta daha önce alınmış.</div>');
                    }
                    else {
                        $("#frmRegister #RegisterEmail").next("span").css("color", "#00cb82");
                        $(".registerinvalidemail").remove();
                        $("#frmRegister #RegisterEmail").parent().find("span").css("color", "#495057");
                    }
                }, error: function (err) {
                    alert(errmsg);
                }
            });
        } else {
            $(".registerinvalidusername").remove();
        }

    });
});