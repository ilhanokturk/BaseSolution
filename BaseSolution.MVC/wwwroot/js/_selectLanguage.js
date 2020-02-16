
    $(document).ready(function () {
        $("input[type=submit]").on("click", function (e) {
            var data = $(this).data("language");
            var returnUrl = $(this).data("returnurl");


            $("<input/>").attr("type", "hidden")
                .attr("name", "culture")
                .attr("value", data)
                .appendTo("#selectLanguage");

            $("<input />").attr("type", "hidden")
                .attr("name", "returnUrl")
                .attr("value", returnUrl)
                .appendTo("#selectLanguage");

            return true;
        });

});
