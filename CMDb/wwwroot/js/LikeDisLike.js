
const btnLike = document.querySelectorAll('#like')
const btnDislike = document.querySelectorAll('#dislike')


for (let index = 0; index < btnLike.length; index++) {

    btnLike[index].addEventListener('click', async function () {
        const imdbId = btnLike[index].name
        const statement = btnLike[index].id
        const url = `https://localhost:44313/api/${imdbId}/${statement}`
        //const url = `https://cmdbapi.kaffekod.se/api/${imdbId}/${statement}`
        await fetch(url).then(function (response) {
            if (response.status !== 200) {
                window.alert(`Something went wrong, error code:${response.status}`)
                return
            }
            response.json()
                .then(function (data) {                   
                    btnLike[index].textContent = data.numberOfLikes
                    btnLike[index].disabled = true
                    btnDislike[index].textContent = data.numberOfDislikes
                    btnDislike[index].disabled = true
                })
                .catch(function (err) {
                    window.alert('Fetch problem: ' + err.message)
                })
        })
    })
}

for (let index = 0; index < btnDislike.length; index++) {

    btnDislike[index].addEventListener('click', async function () {
        const imdbId = btnDislike[index].name
        const statement = btnDislike[index].id
        const url = `https://localhost:44313/api/${imdbId}/${statement}`
        //const url = `https://cmdbapi.kaffekod.se/api/${imdbId}/${statement}`
        await fetch(url).then(function (response) {
            if (response.status !== 200) {
                window.alert(`Something went wrong, error code:${response.status}`)
                return
            }
            response.json()
                .then(function (data) {
                    btnLike[index].textContent = data.numberOfLikes
                    btnLike[index].disabled = true
                    btnDislike[index].textContent = data.numberOfDislikes
                    btnDislike[index].disabled = true
                })
                .catch(function (err) {
                    window.alert('Fetch problem: ' + err.message)
                })
        })
    })
}

