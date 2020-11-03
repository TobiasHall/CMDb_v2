
const moreBtn = document.querySelectorAll('.more')
const plotDiv = document.querySelectorAll('.plot-div')

for (let index = 0; index < moreBtn.length; index++) {
    moreBtn[index].addEventListener('click', function (event) {
        event.preventDefault()
        if (moreBtn[index].text == 'Read more') {
            plotDiv[index].classList.toggle('is-active')            
            moreBtn[index].textContent = 'Collapse'
        }
        else {
            plotDiv[index].classList.toggle('is-active')
            moreBtn[index].textContent = 'Read more'
        }
    })    
}

