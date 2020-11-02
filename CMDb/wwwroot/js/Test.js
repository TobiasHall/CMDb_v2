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

        
        fetch(url2)
            .then(
                function (response) {
                    if (response.status !== 200) {
                        console.log('Looks like there was a problem. Status Code: ' +
                            response.status);
                        return;
                    }
                    // Examine the text in the response
                    response.json().then(function (data) {
                        console.log(data);
                    });
                }
            )
            .catch(function (err) {
                console.log('Fetch Error :-S', err);
            });
        

    }, 500);
}


