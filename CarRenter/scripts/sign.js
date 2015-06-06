$("document").ready(function () {
    $("#Content_txtOtherCity").attr('disabled', 'disabled');
    $("#Content_chkOtherCity").change(function () {
        if ($(this).is(":checked")) {
            $("#Content_txtOtherCity").removeAttr('disabled');
            $("#Content_drpCity").attr('disabled', 'disabled');
        }
        else {
            $("#Content_txtOtherCity").attr('disabled', 'disabled');
            $("#Content_drpCity").removeAttr('disabled');
        }
    });
});