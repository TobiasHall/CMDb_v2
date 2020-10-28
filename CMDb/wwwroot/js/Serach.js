$('form').submit(function (event) {

    event.preventDefault();


    var movieName = $('#search').val();
    var movieURL = "https://www.omdbapi.com/?s=" + movieName + "&apikey=1252672d";

 

    function displayMovies(data) {
        for (let index = 0; index < 5; index++) {
            //TODO: Fixa så alla items visas i vyn efter en sökning
        }
    }
    $.getJSON(movieURL, displayMovies);
});