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
        const resp = connectToApi(btnLike[index].name, btnLike[index].id)
        event = btnLike[index].textContent++
        btnLike[index].disabled = true
        btnDislike[index].disabled = true
    })
}

for (let index = 0; index < btnDislike.length; index++) {

    btnDislike[index].addEventListener('click', function (event) {
        connectToApi(btnDislike[index].name, btnDislike[index].id)
        event = btnDislike[index].textContent++
        btnLike[index].disabled = true
        btnDislike[index].disabled = true       
    })
}

function connectToApi(imdbId, statement) { 

    const url = `https://localhost:44313/api/${imdbId}/${statement}`
    fetch(url, {
        mode: 'no-cors'
    })
        .then(response => {
            return response.json()})
        .then(data => {
            console.log(data)
        })
        .catch(err => {
            window.alert('Something went wrong. Like or dislike did not registered')
            return err
        })
}