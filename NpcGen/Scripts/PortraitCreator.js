initPortrait = function (searchString) {
    google.load('search', '1');

    var imageSearch;


    function searchComplete() {

        if (imageSearch.results && imageSearch.results.length > 0) {

            var contentDiv = document.getElementById('portrait');
            contentDiv.innerHTML = '';

            var results = imageSearch.results;

            var result = results[getRandomInt(0, imageSearch.results.length)];
            var imgContainer = document.createElement('div');

            var newImg = document.createElement('img');

            newImg.src = result.url;
            imgContainer.appendChild(newImg);
            newImg.className = "resize";

            contentDiv.appendChild(imgContainer);


        }
    }

    function OnLoad() {

        // Create an Image Search instance.
        imageSearch = new google.search.ImageSearch();

        // Set searchComplete as the callback function when a search is
        // complete.  The imageSearch object will have results in it.
        imageSearch.setSearchCompleteCallback(this, searchComplete, null);

        imageSearch.execute(searchString);
    }

    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min)) + min;
    }

    google.setOnLoadCallback(OnLoad);
}