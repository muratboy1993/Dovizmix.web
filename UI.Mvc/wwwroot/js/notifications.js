"use strict";
$(document).ready(function () {

    /*Functions*/
    
    /*GetLikeNotification*/
    setInterval(function () {
        if ($("#frmLogin") != null || $("#frmLogin") != undefined) {
            $.ajax({
                url: "/User/GetUserLikeNotification",
                dataType: "json",
                success: function (response) {
                    $.each(response.data, function (index, val) {
                        $.toast({
                            //heading: '',
                            text: val.message,
                            position: 'top-right',
                            loaderBg: '#ff6849',
                            icon: 'success',
                            hideAfter: 10000,
                            stack: 10
                        });
                    });
                },
                error: function (err) {
                    //alert(errmsg);
                }
            });
        }
    }, 50000);
});