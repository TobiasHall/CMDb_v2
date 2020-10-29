$('form').submit(function (event) {

    event.preventDefault();


    var movieName = $('#search').val();
    var movieURL = "https://www.omdbapi.com/?s=" + movieName + "&apikey=1252672d";

 

    function displayMovies(data) {
        for (let index = 0; index < 5; index++) {

            //const test = document.querySelector('#search')
            //const text = data.Search[index].Title 
            //test.value += text;
            var html = "<ul>";
            data.Search.forEach((i) => {
                html += "<li>" + i.Title + "</li>";
                html += "<ul>";
            });
            $("#search").html(html);
            //TODO: Fixa så alla items visas i vyn efter en sökning
        //    const header = document.createElement('p')
        //    header.textContent = data.Search[index].Title

        //    const author = document.createElement('p')
        //    author.textContent = data.Search[index].imdbID

        //    const content = document.querySelector('#movieInformation')
        //    content.appendChild(header)
        //    content.appendChild(author)
        }
    }

    $.getJSON(movieURL, displayMovies);
});