//const moreBtn = document.querySelector('.more')
//const plotDiv = document.querySelector('.plot-div')

//moreBtn.addEventListener('click', function (event) {
//    event.stopPropagation()
//    event.preventDefault()
//    if (moreBtn.text == 'Read more') {
//        plotDiv.classList.toggle('is-active')

//        //plotDiv.style.height = '100%'
//        moreBtn.textContent = 'Collapse'
//    }
//    else {
//        plotDiv.classList.toggle('is-active')
//        //plotDiv.style.height = '50px'
//        moreBtn.textContent = 'Read more'
//    }
//})

const moreBtn = document.querySelectorAll('.more')
const plotDiv = document.querySelectorAll('.plot-div')

for (let index = 0; index < moreBtn.length; index++) {
    moreBtn[index].addEventListener('click', function (event) {
        //event.stopPropagation()
        event.preventDefault()
        if (moreBtn[index].text == 'Read more') {
            plotDiv[index].classList.toggle('is-active')
            //plotDiv.style.height = '100%'
            moreBtn[index].textContent = 'Collapse'
        }
        else {
            plotDiv[index].classList.toggle('is-active')
            //plotDiv.style.height = '50px'
            moreBtn[index].textContent = 'Read more'
        }
    })    
}

