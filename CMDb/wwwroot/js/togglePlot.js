const moreBtn = document.querySelector('.more')
const plotDiv = document.querySelector('.plot-div')

moreBtn.addEventListener('click', function (event) {
    event.stopPropagation()
    event.preventDefault()
    if (moreBtn.text == 'Read more') {
        plotDiv.style.height = '100%'
        moreBtn.textContent = 'Collapse'
    }
    else {
        plotDiv.style.height = '50px'
        moreBtn.textContent = 'Read more'
    }
})