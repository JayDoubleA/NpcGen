initPortrait = function (searchString) {
    google.load('search', '1');

    var imageSearch;

    function searchComplete() {

        if (imageSearch.results && imageSearch.results.length > 0) {

            var contentDiv = document.getElementById('portrait');
            contentDiv.innerHTML = '';

            var results = imageSearch.results;

            for (var i = 0; i < results.length; i++) {
                var imgContainer = document.createElement('div');
                imgContainer.className = "col-sm-6";

                var newImg = document.createElement('img');

                newImg.src = results[i].url;
                imgContainer.appendChild(newImg);
                newImg.className = "resize";
                contentDiv.appendChild(imgContainer);
                newImg.onclick = function () {
                    contentDiv.innerHTML = '';
                    contentDiv.appendChild(imgContainer);
                };
            }
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