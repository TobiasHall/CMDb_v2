function likeMovie(clickedElement, imdbId) {
    
    //const cmdb = new XMLHttpRequest()
    //const statement = 'like'
    //const url = `https://localhost:44313/api/${imdbId}/${statement}`
    //cmdb.open("Get", url, true)
    //cmdb.send()
    clickedElement = clickedElement.textContent++
    const button = document.querySelector('#btn-dislike')
    button.disabled = true
}
function disLikeMovie(clickedElement, imdbId) {

    //const cmdb = new XMLHttpRequest()
    //const statement = 'dislike'
    //const url = `https://localhost:44313/api/${imdbId}/${statement}`
    //cmdb.open("Get", url, true)
    //cmdb.send()
    clickedElement = clickedElement.textContent++
}