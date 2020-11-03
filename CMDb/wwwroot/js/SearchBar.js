function searchMovie() {
    if (this.timer) {
        window.clearTimeout(this.timer);
    }
    this.timer = window.setTimeout(function () {

        const movieName = document.querySelector('#txt').value        
        const url = "https://www.omdbapi.com/?s=" + movieName + "&apikey=1252672d";        
        
        const content = document.querySelector('.list-group')
        removeAllChildNodes(content)
        
        fetch(url)
            .then(function (response) {
                if (response.status !== 200) {
                    const error = document.createElement('a')
                    error.textContent = `Something went wrong, error code:${response.status}`
                    content.appendChild(error)
                    return;
                }
                response.json()
                    .then(function (data) {
                        for (var i = 0; i < data.Search.length; i++) {
                            const movie = document.createElement('a')
                            movie.textContent = `${data.Search[i].Title} (${data.Search[i].Year})`
                            movie.href = `/Movie/Detail?id=${data.Search[i].imdbID}`
                            const poster = document.createElement('img')
                            poster.src = data.Search[i].Poster
                            movie.appendChild(poster)
                            content.appendChild(movie)
                        }
                    });
            })
            .catch(function (err) {
                console.log('Fetch Error :-S', err);
            });
    }, 500);
}


function removeAllChildNodes(parent) {
    while (parent.firstChild) {
        parent.removeChild(parent.firstChild);
    }
}