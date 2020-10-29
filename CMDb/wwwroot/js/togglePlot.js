$('.more').click(function (e) {
    e.stopPropagation();
    e.preventDefault();
    $('.plot-div').animate({
        'height': '100%'
    })
    $('.more').text('Collapse')
    $('.more').removeClass('more').addClass('collapse')
    
});


$('.collapse').click(function () {
    $('.plot-div').animate({
        'height': '50px'
    })
})



//$(document).click(function () {
//    $('.plot-div').animate({
//        'height': '50px'
//    })
//})