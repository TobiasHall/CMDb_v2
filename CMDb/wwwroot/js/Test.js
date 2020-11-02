function myFunction() {
    if (this.timer) {
        window.clearTimeout(this.timer);
    }
    this.timer = window.setTimeout(function () {

        const movieName = document.querySelector('#txt').value
        //const cmdb = new XMLHttpRequest()    
        const url = "https://www.omdbapi.com/?s=" + movieName + "&apikey=1252672d";        
        //cmdb.open("Get", url, true)
        //cmdb.send()
        const content = document.querySelector('.list-group')
        removeAllChildNodes(content)
        
        fetch(url)
            .then(
                function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' +
                            response.status);
                        return;
                    }
                    // Examine the text in the response
                    response.json().then(function (data) {

                        for (var i = 0; i < data.Search.length; i++) {

                            const movie = document.createElement('button')
                            movie.textContent = `${data.Search[i].Title} (${data.Search[i].Year})`                            
                            movie.type = 'Submit'

                            
                            
                            content.appendChild(movie)


                        }






                    });
                }
            )
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