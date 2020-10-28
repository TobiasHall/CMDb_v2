$('.more').click(function (e) {
    e.stopPropagation();
    e.preventDefault();
    $('.plot-div').animate({
        'height': '100%'
    })
});

$(document).click(function () {
    $('.plot-div').animate({
        'height': '50px'
    })
})