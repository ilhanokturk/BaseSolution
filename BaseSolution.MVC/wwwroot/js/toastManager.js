@import "toastr";

var TOAST = {
    init: function () {
        TOAST.error();
        TOAST.success();
        TOAST.info();
        TOAST.clear();
    },
    error: function (message) {
        
        $.toastr({
            text: message,
            position: 'bottom-right',
            loaderBg: '#ff6849',
            icon: 'error',
            hideAfter: 6000
        });
    },
    success: function (message) {

        $.toastr({
            text: message,
            position: 'bottom-right',
            loaderBg: '#ff6849',
            icon: 'success',
            hideAfter: 6000
        });
    },
    info: function (message) {

        $.toastr({
            heading: 'Bilgilendirme',
            text: message,
            position: 'bottom-right',
            loaderBg: '#ff6849',
            icon: 'info',
            hideAfter: 6000,
            stack: 6
        });
    },
    clear: function () {
        $.toastr.clear();
    }
}