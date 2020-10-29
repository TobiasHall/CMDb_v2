//$('.more').click(function (e) {
//    e.stopPropagation();
//    e.preventDefault();
//    $('.plot-div').animate({
//        'height': '100%'
//    })
//    $('.more').text('Collapse')
    
    
//});

$('.more').click(function (e) {
    e.stopPropagation();
    e.preventDefault();
    const link = document.querySelector('.more')
    var h = this.scrollHeight;
    if (link.text == 'Read more') {
        $('.plot-div').animate({
            'height': '100%'
        })
        $('.more').text('Collapse')
    }
    else {
        $('.plot-div').animate({
            'height': '50px'
        })
        $('.more').text('Read more')

    }
});


//$(document).click(function () {
//    $('.plot-div').animate({
//        'height': '50px'
//    })
//})