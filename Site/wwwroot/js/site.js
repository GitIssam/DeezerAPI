// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//récuperer la liste des games
function getGames() {

    fetch("http://localhost:5173/api/Games")

        // appelle de la method .json qui permet de récuperer le contenu du resultat de la requete en format json
        .then(response => response.json() // lecture de la reponse http
        )
        .then(json => {

            var gameList = document.getElementById("gameList");
           

            json.forEach(game => {
                //console.log(game.title);
                var option = document.createElement("option");

                option.text = game.title;
                option.value = game.id;
                gameList.add(option);
            });

           // document.getElementById("games").innerHTML = json[0].title;

        });
}

function displayTracksFromGames() {

    // call sur game , récuperer quelles questions sont posés ( id , description )
    // et la liste des tracks à écouter 


    //fetch('http://localhost:5173/api/Games/120/Tracks')
    //    // appelle de la method .json qui permet de récuperer le contenu du resultat de la requete en format json
    //    .then(response => response.json() // lecture de la reponse http
    //    )
    //    .then(json => {

    //        var gamesArea = document.querySelector('displayGames');

    //        json.forEach(game => {
    //            //console.log(game.title);

    //           // gamesArea.append()

    //        });

    //   // gamesArea.append()


}

getGames()

