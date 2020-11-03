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
        const imdbId = btnLike[index].name
        const statement = btnLike[index].id


        const url = `https://localhost:44313/api/${imdbId}/${statement}`
        fetch(url).then(function (response) {
            return response.json();
        }).then(function (json) {
            event = btnLike[index].textContent++
            btnLike[index].disabled = true
            btnDislike[index].disabled = true
            console.log(json);
        }).catch(function (err) {
            console.log('Fetch problem: ' + err.message);
        });






        //event = btnLike[index].textContent++
        //btnLike[index].disabled = true
        //btnDislike[index].disabled = true
    })
}


for (let index = 0; index < btnDislike.length; index++) {

    btnDislike[index].addEventListener('click', function (event) {
        const imdbId = btnLike[index].name
        const statement = btnLike[index].id



        const url = `https://localhost:44313/api/${imdbId}/${statement}`
        fetch(url).then(function (response) {
            return response.json();
        }).then(function (json) {
        event = btnDislike[index].textContent++
        btnLike[index].disabled = true
        btnDislike[index].disabled = true       
  
            console.log(json);
        }).catch(function (err) {
            console.log('Fetch problem: ' + err.message);
        });
    })
}

//function connectToApi(imdbId, statement) { 

//    const url = `https://localhost:44313/api/${imdbId}/${statement}`
//     fetch(url).then(function (response) {
//        return response.json();
//    }).then(function (json) {
//        console.log(json);
//    }).catch(function (err) {
//        console.log('Fetch problem: ' + err.message);
//    });
//}