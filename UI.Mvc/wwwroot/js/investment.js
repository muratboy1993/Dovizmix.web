"use strict";
$(document).ready(function () {

    /*Daterangepicker için*/
    $('#purchasedate').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        minYear: 1901,
        //maxYear: parseInt(moment().format('YYYY'), 10),
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


    var price = new AutoNumeric('#price', {
        decimalPlaces: '4',
        minimumValue: 0,
        currencySymbolPlacement: 's',
        currencySymbol: '₺',
        selectOnFocus: false,
        watchExternalChanges: true,
        allowDecimalPadding: false,
        decimalCharacter : ',',
        digitGroupSeparator : ".",
    });
    var amount = new AutoNumeric('#amount', {
        decimalPlaces: '8',
        minimumValue: 0,
        allowDecimalPadding: false,
        watchExternalChanges: true,
        decimalCharacter : ',',
        digitGroupSeparator : '.',
    });

    /*Yatırım ekleme AddInvesment veya UpdateInvestment çağrılıyor*/
    $('#btnAddInvestment').on("click", function () {

        /* Investment ekleme front-end validation */

        $(".investmentAlert").remove();

        $("#investment_result").html("");
        var varlik = $("#varlik").val();
        var miktar = amount.rawValue.toString();
        miktar = miktar.replace(".", ",");
        var alistarih = $("#purchasedate").val();
        var fiyat = price.rawValue.toString();
        fiyat = fiyat.replace(".", ",");

        var not = $("#note").val();

        var validation = true;

        if (varlik === "Yatırım türü seçiniz..") {
            $("#varlik").parent().append('<div class="alert alert-danger investmentAlert">Boş geçilemez.</div>');
            validation = false;
        }
        if (miktar === "") {
            $("#amount").parent().parent().append('<div class="alert alert-danger investmentAlert">Boş geçilemez.</div>');
            validation = false;
        }
        if (alistarih === "") {
            $("#purchasedate").parent().parent().append('<div class="alert alert-danger investmentAlert">Boş geçilemez.</div>');
            validation = false;
        }
        if (fiyat === "") {
            $("#price").parent().parent().append('<div class="alert alert-danger investmentAlert">Boş geçilemez.</div>');
            validation = false;
        }

        //maksimum ve minimum durum
        if (not.length < 3 && not !== "") {
            $("#note").parent().parent().append('<div class="alert alert-danger investmentAlert">Minimum 3 karakter girmelisiniz.</div>');
            validation = false;
        }
        if (not.length > 500) {
            $("#note").parent().parent().append('<div class="alert alert-danger investmentAlert">Maksimum 500 karakter girmelisiniz.</div>');
            validation = false;
        }

        if (validation) {
            if ($("#formType").val() === "0") {
                varlik = $("#varlik").val();
                AddInvesment(varlik, miktar, fiyat, not, alistarih);
            } else {
                var id = $("#investmentId").val();
                varlik = $("#varlik").val();
                UpdateInvesment(id, varlik, miktar, fiyat, not, alistarih);
            }
        } else {
            return false;
        }
    });
});

/*Yatrımları getirir*/
function GetInvestment(InvestmentId) {
    $(".investmentAlert").remove();

    UpdateInvestmentButton(InvestmentId);


    $.ajax({
        type: 'POST',
        url: '/Common/GetInvestment',
        data: {
            'investmentId': InvestmentId
        },
        success: function (msg) {
            if (msg.status === true) {
                $("#varlik").val(msg.data.marketId);
                $("#amount").val(msg.data.amount);
                var d = new Date(msg.data.purchaseDateTime);
                var date = d.getDate() + '.' + (d.getMonth() + 1) + '.' + d.getFullYear();
                $("#purchasedate").val(date);
                $("#price").val(msg.data.price);
                $("#note").val(msg.data.note);
            }
        },
        error: function () {
            alert(msg.message);
        }
    });
}

/*Siler*/
function DeleteInvestment(InvestmentId) {
    $.ajax({
        type: 'POST',
        url: '/Common/DeleteInvestment',
        data: {
            'investmentId': InvestmentId
        },
        success: function (msg) {
            if (msg.status === true) {
                alert(msg.message);
                setTimeout(function () {
                    window.location.reload(true);
                }, 1000);
            }
        },
        error: function () {
            alert(msg.message);
        }
    });
}

/*Ekler*/
function AddInvesment(varlik, miktar, fiyat, not, alistarih) {
    var model = {
        MarketId: varlik,
        Amount: miktar,
        Price: fiyat,
        Note: not,
        PurchaseDateTime: alistarih
    };

    $("#frmInvestment").find(":button").prop('disabled', true);
    $("#frmInvestment").find(":button").html("Yatırımınız ekleniyor..");

    $.ajax({
        type: 'POST',
        url: '/Common/AddInvestment',
        data: {
            'model': model
        },

        success: function (msgg) {
            if (msgg.status === true) {
                $("#investment_result").append("<div class='alert alert-success'> " + msgg.message + " </div>");
                setTimeout(function () {
                    window.location.reload(true);
                }, 1000);
            }
            else {
                //alert(msgg.message);
                $("#investment_result").append("<div class='alert alert-danger'> " + msgg.message + " </div>");
            }
            $("#frmInvestment").find(":button").prop('disabled', false);
            $("#frmInvestment").find(":button").html("Yatırım Ekle");
        },
        error: function () {
            $("#investment_result").append("<div class='alert alert-danger'> İşlem sırasında istenmeyen hata meydana geldi. </div>");
            $("#frmInvestment").find(":button").prop('disabled', false);
            $("#frmInvestment").find(":button").html("Yatırım Ekle");
        }
    });
}

/*Günceller*/
function UpdateInvesment(id, varlik, miktar, fiyat, not, alistarih) {

    var model = {
        Id: id,
        MarketId: varlik,
        Amount: miktar,
        Price: fiyat,
        Note: not,
        PurchaseDateTime: alistarih
    };

    $("#frmInvestment").find(":button").prop('disabled', true);
    $("#frmInvestment").find(":button").html("Yatırımınız ekleniyor..");

    $.ajax({
        type: 'POST',
        url: '/Common/UpdateInvestment',
        data: {
            'model': model
        },

        success: function (msgg) {
            if (msgg.status === true) {
                $("#investment_result").append("<div class='alert alert-success'> " + msgg.message + " </div>");
                setTimeout(function () {
                    window.location.reload(true);
                }, 1000);
            }
            else {
                $("#investment_result").append("<div class='alert alert-danger'> " + msgg.message + " </div>");
            }
            $("#frmInvestment").find(":button").prop('disabled', false);
            $("#frmInvestment").find(":button").html("Yatırım Ekle");
        },
        error: function () {
            $("#investment_result").append("<div class='alert alert-danger'> İşlem sırasında istenmeyen hata meydana geldi. </div>");
            $("#frmInvestment").find(":button").prop('disabled', false);
            $("#frmInvestment").find(":button").html("Yatırım Ekle");
        }
    });
}

/*Formu temizler*/
function ClearInvesmentForm() {
    $("#varlik").val("");
    $("#amount").val("");
    $("#purchasedate").val("");
    $("#price").val("");
    $("#note").val("");
}

/*ClearInvesment çağrılıyor ve AddInvestment'ın çağırılması sağlanıyor.*/
function AddInvestmentButton() {
    ClearInvesmentForm();
    $("#varlik>option:eq(0)").prop('selected', true);
    $("#formType").val("0");
    $("#investmentId").val("");
    var dt = new Date();
    var date = dt.getDate() + '.' + (dt.getMonth() + 1) + '.' + dt.getFullYear();
    $("#purchasedate").val(date);
}

/*ClearInvesment çağrılıyor ve UpdateInvesment'ın çağırılması sağlanıyor.*/
function UpdateInvestmentButton(investmentId) {
    ClearInvesmentForm();
    $("#formType").val("1");
    $("#investmentId").val(investmentId);

}
