$(document).ready(function () {
    //$('.dropMenu').click(function () { $(this).animate({ width: "px" }) });
    $('li[id^="li"').hover(menuOpen, menuClose);
    $('#liHome').unbind('mouseenter mouseleave');
});

function menuOpen() {
    $(this).stop().animate({
        width: '148px',
        height: '80px',
        borderBottomLeftRadius: '20px',
        marginBottom: "-97px",
    }).children().children('.hide').stop().animate({
        opacity: 1
    }, 'slow')
    $('#liHome').stop().animate({
        marginLeft: '28px'
    });
}

function menuClose() {
    $(this).stop().animate({
        width: '69px',
        height: '3px',
        marginBottom: "0px",
        borderBottomLeftRadius: '0',
    }).children().children('.hide').stop().animate({
        opacity: 0
    });
    $('#liHome').stop().animate({
        marginLeft: '108px'
    })

}