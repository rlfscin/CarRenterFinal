$(document).ready(function () {
    $('.car').hover(
        function () {
            $(this).stop().css('backgroundColor', '#ddd').animate({
                borderRadius: '20px'
            })
        }
        ,
        function () {
            $(this).stop().css('backgroundColor', '#ccc').animate({
                borderRadius: '2px'
        })
        }
    )
});

