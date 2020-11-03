
const btnLike = document.querySelectorAll('#like')
const btnDislike = document.querySelectorAll('#dislike')


for (let index = 0; index < btnLike.length; index++) {

    btnLike[index].addEventListener('click', function () {
        const imdbId = btnLike[index].name
        const statement = btnLike[index].id
        //const url = `https://localhost:44313/api/${imdbId}/${statement}`
        const url = `https://cmdbapi.kaffekod.se/api/${imdbId}/${statement}`
        fetch(url).then(function (response) {
            return response.json();
        }).then(function (json) {
            btnLike[index].textContent++
            btnLike[index].disabled = true
            btnDislike[index].disabled = true
            console.log(json);
        }).catch(function (err) {
            console.log('Fetch problem: ' + err.message);
        });
    })
}


for (let index = 0; index < btnDislike.length; index++) {

    btnDislike[index].addEventListener('click', function () {
        const imdbId = btnLike[index].name
        const statement = btnLike[index].id
        //const url = `https://localhost:44313/api/${imdbId}/${statement}`
        const url = `https://cmdbapi.kaffekod.se/api/${imdbId}/${statement}`
        fetch(url).then(function (response) {
            return response.json();
        }).then(function (json) {
            btnDislike[index].textContent++
            btnLike[index].disabled = true
            btnDislike[index].disabled = true
            console.log(json);
        }).catch(function (err) {
            console.log('Fetch problem: ' + err.message);
        });
    })
}