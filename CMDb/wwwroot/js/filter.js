
const filterRow = document.querySelectorAll('.filterRow')

for (var i = 0; i < filterRow.length; i++) {
    filterRow[i].addEventListener('click', function (event) {
        liToShow = event.target.textContent
        if (liToShow === 'Title') {
            document.getElementById('filterOnTitle').style.display = 'contents'
            document.getElementById('filterOnTitle').className = 'active'
            document.getElementById('filterOnYear').style.display = 'none'
            document.getElementById('filterOnLikes').style.display = 'none'
            document.getElementById('filterOnDislikes').style.display = 'none'
        }
        if (liToShow === 'Year') {
            document.getElementById('filterOnTitle').style.display = 'none'
            document.getElementById('filterOnYear').style.display = 'contents'
            document.getElementById('filterOnLikes').style.display = 'none'
            document.getElementById('filterOnDislikes').style.display = 'none'
        }
        if (liToShow === 'Likes') {
            document.getElementById('filterOnTitle').style.display = 'none'
            document.getElementById('filterOnYear').style.display = 'none'
            document.getElementById('filterOnLikes').style.display = 'contents'
            document.getElementById('filterOnDislikes').style.display = 'none'
        }
        if (liToShow === 'Dislikes') {
            document.getElementById('filterOnTitle').style.display = 'none'
            document.getElementById('filterOnYear').style.display = 'none'
            document.getElementById('filterOnLikes').style.display = 'none'
            document.getElementById('filterOnDislikes').style.display = 'contents'
        }
    })
}