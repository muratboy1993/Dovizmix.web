$(document).ready(function () {

    /*Functions*/

    check();
    uncheck();

    //Get Default Economic Calendar
    var countryList = new Array();
    var importantList = new Array();

    var now = new Date();
    
    var yil = now.getFullYear();
    var ay = now.getMonth();
    var gun = now.getDate();

    var startDate = sifirekle(gun) + "." + sifirekle(ay+1) + "." + yil +" 00:00";
    var endDate = sifirekle(gun) + "." + sifirekle(ay+1) + "." + yil + " 23:58";

    /*Seçili olan ülkeleri getirir.*/
    $("input[name=CalendarPageCountry]:checked").each(function () {

        countryList.push($(this).val());

    });

    /*Seçili olan önem seviyelerini getirir.*/
    $("input[name=CalendarPageImportants]:checked").each(function () {

        importantList.push($(this).val());

    });

    GetCalander(startDate, endDate, countryList, importantList);
    //Get Default Economic Calendar

    $('input[name="EconomicCalendarPageDate"]').daterangepicker({
        timePicker: false,
        "opens": "left",
        "applyClass": "btn btn-xs btn-default",
        "cancelClass": "btn btn-xs btn-link",
        startDate: moment().startOf('hour'),
        endDate: moment().startOf('hour').add(32, 'hour'),
        ranges: {
            'Bugün': [moment(), moment()],
            'Dün': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
            'Son 7 gün': [moment().subtract(6, 'days'), moment()],
            'Son 30 gün': [moment().subtract(29, 'days'), moment()],
            'Bu ay': [moment().startOf('month'), moment().endOf('month')],
            'Geçen ay': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
        },
        locale: {
            "customRangeLabel": "Elle Seç",
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
            ],
            "firstDay": 1
        }
    });

    $('#btnEconomicCalendarPageFilter').click(function ()
    {
        var countryList = new Array();
        var importantList = new Array();

        $("input[name=CalendarPageCountry]:checked").each(function () {

            countryList.push($(this).val());

        });

        $("input[name=CalendarPageImportants]:checked").each(function () {

            importantList.push($(this).val());

        });

        if (countryList.length <= 0 || importantList.length <= 0)
        {
            alert("En az 1 ülke ve/veya 1 önem derecesi seçmelisin");
        }
        else {
            var split = $("#EconomicCalendarPageDate").val().split("-");
            var startDate = split[0];
            var endDate = split[1];
            GetCalander(startDate, endDate, countryList, importantList);
        }


    });

    /*Ekonomik takvimi getirme*/
    function GetCalander(startDate, endDate, countryIds, importantIds)
    {
        $('#tblEconomicCalendar').show();

        var model = {
            StartDate: startDate,
            EndDate: endDate,
            CountryId: countryIds,
            Important: importantIds

        };

        $('#tblEconomicCalendar').DataTable({
            "processing": true, // for show progress bar  
            "destroy": true,
            "filter": true, // this is for disable filter (search box)  
            "orderMulti": false, // for disable multiple column at once  
            "paging": false,
            "checkbox": true,

            "ajax":
            {
                data:
                {
                    'model': model
                },
                type: 'POST',
                url: '/Home/GetEconomicCalendar',
                dataType: 'json',

            },
            "columns":
                [
                    { "data": "country", "title": "Ülkeler" },
                    { "data": "subject", "title": "Konu" },
                    { "data": "important", "title": "Önem" },
                    //{ "data": "currencyCode", "title": "Döviz" },
                    { "data": "subjectDateTime", "title": "Tarih", "format": "dd-mm-yyyy" },
                    // { "data": "countryFlagCode"},
                    { "data": "actual", "title": "Açıklanan" },
                    { "data": "forecast", "title": "Beklenen" },
                    { "data": "previous", "title": "Önceki" }

                ],
            "columnDefs":
                [
                    {

                        "render": function (data, type, row) {


                            return "<img alt='" + row.country + "' title='" + row.country + "' src='/assets/Flags/blank.gif' class='ceFlags " + row.countryFlagCode + "'><span>" + row.currencyCode + "</span>";



                        },
                        "targets": 0
                    },
                    {

                        "render": function (data, type, row) {
                            var importants = "";
                            for (var i = 0; i < data; i++) {
                                importants += "<span><i style='font-size: 17px' class='fa fa-exclamation'></i></span>";
                            }
                            return importants;
                        },
                        "targets": 2
                    },
                    {

                        "render": function (data, type, row)
                        {
                            return DateFormatFromString(data);
                        },
                        "targets": 3
                    },

                    { "orderable": false, "targets": [1] },
                    { "orderable": false, "targets": [4] },
                    { "orderable": false, "targets": [5] },
                    { "orderable": false, "targets": [6] }
                ],
            "language": {
                //"url": "https://cdn.datatables.net/plug-ins/1.10.19/i18n/Turkish.json",
                "sDecimal": ",",
                "sEmptyTable": "Planlanmış Etkinlik Bulunmamaktadır.",
                "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
                "sInfoEmpty": "Kayıt yok",
                "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
                "sInfoPostFix": "",
                "sInfoThousands": ".",
                "sLengthMenu": "Sayfada _MENU_ kayıt göster",
                "sLoadingRecords": "Yükleniyor...",
                "sProcessing": "İşleniyor...",
                "sSearch": "Ara:",
                "sZeroRecords": "Eşleşen kayıt bulunamadı",
                "oPaginate": {
                    "sFirst": "İlk",
                    "sLast": "Son",
                    "sNext": "Sonraki",
                    "sPrevious": "Önceki"
                },
                "oAria": {
                    "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                    "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
                },
                "select": {
                    "rows": {
                        "_": "%d kayıt seçildi",
                        "0": "",
                        "1": "1 kayıt seçildi"
                    }
                }
            },

        });
    }

    $("#tblEconomicCalendar_info").remove();

    $.fn.dataTable.ext.errMode = function (settings, helpPage, message) {
        $('#tblEconomicCalendar').hide();
        alert(errmsg);
        
    };
});

/*Tüm checkboxları seçme*/
function check() {
    // Check All
    $('.checkallcountry').click(function () {
        $("input[name=CalendarPageCountry]").prop("checked", true);
    });
}

/*Tüm checkbocların seçimlerini kaldırma*/
function uncheck() {
    // Uncheck All
    $('.uncheckallcountry').click(function () {
        $("input[name=CalendarPageCountry]").prop("checked", false);
    });
}

/**/
function DateFormatFromString(dateString) {
    var aylar = new Array("Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık");
    var gunler = new Array("Pazar", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi");
    var now = new Date(dateString);
    var yil = now.getFullYear();
    var ay = now.getMonth();
    var gun = now.getDate();
    var haftagun = now.getDay();
    var now = new Date();
    var saat = now.getHours();
    var dakika = now.getMinutes();
    saat = sifirekle(saat);
    dakika = sifirekle(dakika);
    return gun + " " + aylar[ay] + " " + yil + " " + gunler[haftagun] + " " + saat + ":" + dakika;
}

/*Rakamların başına 0 yazar.*/
function sifirekle(sayi) {
    if (sayi < 10) {
        return "0" + sayi.toString();
    } else {
        return sayi.toString();
    }
}
