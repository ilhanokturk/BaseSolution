var SWAL = {
    init: function () {
        SWAL.alerts();
        SWAL.confirms();
        SWAL.simpleconfirm();
        SWAL.callBackAlert();
        SWAL.redirect();
        SWAL.clear();
        SWAL.load();
        SWAL.process();
        SWAL.swalLogin();
        SWAL.ringLoad();
    },
    alerts: function (param) {
        SWAL.clear();
        var ok = $("#textPopupData").data('ok');
        $(".sweet-alert.showSweetAlert.visible h2").show();
        $(".sweet-alert.showSweetAlert.visible .sa-button-container").show();
        $(".sweet-alert.showSweetAlert.visible .sa-error-container").hide();
        swal({
            title: param,
            confirmButtonText: ok
        });
    },
    callBackAlert: function (func, paramx) {
        SWAL.clear();
        var ok = $("#textPopupData").data('ok');
        $(".sweet-alert.showSweetAlert.visible h2").show();
        $(".sweet-alert.showSweetAlert.visible .sa-button-container").show();
        $(".sweet-alert.showSweetAlert.visible .sa-error-container").hide();
        swal({
            title: paramx,
            confirmButtonText: ok
        },
            function () {
                func();
            });
    },
    confirms: function (func, param, param1, param2, id) {
        SWAL.clear();
        var no = $("#textPopupData").data('no');
        var save = $("#textPopupData").data('save');
        if (!param1) param1 = save;
        if (!param2) param2 = no;
        swal({
            title: param,
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: param1,
            cancelButtonText: param2,
            showLoaderOnConfirm: true,
            closeOnConfirm: false,
            allowEscapeKey: false
        }, function (isConfirm) {
            if (isConfirm) {
                $(".sweet-alert.showSweetAlert.visible h2").text("Bekleyiniz..");
                $(".sweet-alert.showSweetAlert.visible .sa-button-container").hide();
                $(".sweet-alert.showSweetAlert.visible .sa-error-container").show().html('<img id="theImg" src="../images/ring.gif" />');
                if (id) {
                    return func(id);
                } else {
                    return func();
                }
            }
        });

        return;
    },
    simpleconfirm: function (func, param, param1, param2, id) {
        SWAL.clear();
        var no = $("#textPopupData").data('no');
        var save = $("#textPopupData").data('save');

        if (!param1) param1 = save;
        if (!param2) param2 = no;
        swal({
            title: param,
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: param1,
            cancelButtonText: param2,
            closeOnConfirm: false
        }, function () {
            if (id) {
                func(id);
                swal.close();
            } else {
                func();
                swal.close();
            }
        });
    },
    redirect: function (func, param) {
        SWAL.clear();
        var ok = "Tamam";
        $(".sweet-alert.showSweetAlert.visible h2").show();
        $(".sweet-alert.showSweetAlert.visible .sa-button-container").show();
        $(".sweet-alert.showSweetAlert.visible .sa-error-container").hide();
        swal({
            title: param,
            confirmButtonText: ok
        },
            function () {
                func();
            });
    },
    redirectWithUrl: function (func, param, id) {
        SWAL.clear();
        var ok = $("#textPopupData").data('ok');
        $(".sweet-alert.showSweetAlert.visible h2").show();
        $(".sweet-alert.showSweetAlert.visible .sa-button-container").show();
        $(".sweet-alert.showSweetAlert.visible .sa-error-container").hide();
        swal({
            title: param,
            confirmButtonText: ok
        },
            function () {
                if (id) {
                    func(id);
                } else {
                    func();
                }
            });
    },
    clear: function () {
        swal.close();
        $("div[class*='sweet-']").remove();
    },
    load: function (func, id) {
        SWAL.clear();
        swal({
            title: "Yukleniyor...",
            text: '<img id="theImg" src="../images/ring.gif" style="margin-top: 40px; display: inline-block" />',
            html: true,
            showLoaderOnConfirm: true,
            showConfirmButton: false
        }, function () {
            $(".sweet-alert.showSweetAlert.visible h2").hide();
            $(".sweet-alert.showSweetAlert.visible .sa-button-container").hide();
            $(".sweet-alert.showSweetAlert.visible .sa-error-container").show().html('<img id="theImg" src="../images/ring.gif" />');
            if (id)
                func(id);
            else
                func(id);
        });
    },
    process: function (func, paramText,id) {
        SWAL.clear();
        if (!paramText) paramText = "Islem yapiliyor";
        swal({
            title: "Lutfen Bekleyin..",
            text: paramText,
            imageUrl: "../images/ring.gif",
            showConfirmButton: false,
            allowOutsideClick: false,
            showCancelButton: false,
            allowEscapeKey: false
        }, setTimeout(() => {
            if (id) {
                func(id);
            }
            else {
                func();
            }
        })
        )

    },
    messageokRedirect: function (func, param, param1, param2, param3) {
        SWAL.clear();
        $(".sweet-alert.showSweetAlert.visible h2").show();
        $(".sweet-alert.showSweetAlert.visible .sa-button-container").show();
        $(".sweet-alert.showSweetAlert.visible .sa-error-container").hide();
        swal({
            title: param,
            text: param1,
            type: param2,
            confirmButtonText: "Tamam"
        }, function () {
            if (param3)
                func(param3);
            else
                func();
        });
    },
    swalLogin: function (func, id) {
        SWAL.clear();
        swal({
            title: "Giris yapiliyor..",
            text: '<img id="theImg" src="../images/ring.gif" style="margin-top: 40px; display: inline-block" />',
            html: true,
            showLoaderOnConfirm: true,
            showConfirmButton: false,
            showCancelButton: false,
            allowEscapeKey: false,
            allowOutsideClick: false
        }, function () {
            $(".sweet-alert.showSweetAlert.visible h2").hide();
            $(".sweet-alert.showSweetAlert.visible .sa-button-container").hide();
                $(".sweet-alert.showSweetAlert.visible .sa-error-container").show().html('<img id="theImg" src="~/images/ring.gif" />');
            if (id)
                func(id);
            else
                func();
        });
    },
    ringLoad: function () {
        SWAL.clear();
        swal({
            title: "Giris yapiliyor..",
            text: '<img id="theImg" src="../images/ring.gif" style="margin-top: 40px; display: inline-block" />',
            html: true,
            showLoaderOnConfirm: true,
            showConfirmButton: false,
            showCancelButton: false,
            allowEscapeKey: false,
            allowOutsideClick: false
        });
    }
}
