function likeMovie(imdbId, statement) {
    
    //const cmdb = new XMLHttpRequest()    
    //const url = `https://localhost:44313/api/${imdbId}/${statement}`
    //cmdb.open("Get", url, true)
    //cmdb.send()
}

const btnLike = document.querySelectorAll('#like')
const btnDislike = document.querySelectorAll('#dislike')


for (let index = 0; index < btnLike.length; index++) {

    btnLike[index].addEventListener('click', function (event) {
        event = btnLike[index].textContent++
        btnLike[index].disabled = true
        btnDislike[index].disabled = true
        likeMovie(btnLike[index].name, btnLike[index].id)
    })
}

for (let index = 0; index < btnDislike.length; index++) {

    btnDislike[index].addEventListener('click', function (event) {
        event = btnDislike[index].textContent++
        btnLike[index].disabled = true
        btnDislike[index].disabled = true
        likeMovie(btnDislike[index].name, btnDislike[index].id)
    })
}
