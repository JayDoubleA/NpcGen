$(document).ready(function () {

    // reset list values
    $('#raceName').val('');
    $('#locationName').val('');

    $('#raceName').change(function () {
        var self = $(this);
        npc.updateLocations(self.val());
    });

    $('#locationName').change(function () {
        var self = $(this);
        npc.updateRaces(self.val());
    });
});

var npc = (function () {
    // private functions
    var updateRaces = function (location) {
        jQuery.ajaxSetup({ async: false });
        $.getJSON('/ajax/RacesUpdate', { loc: location })
          .done(function (data) {
              updateList(data, 'raceName');
          });
    };

    var updateLocations = function (race) {
        jQuery.ajaxSetup({ async: false });
        $.getJSON('/ajax/UpdateLocations', { rac: race })
          .done(function (data) {
            updateList(data, 'locationName');
        });
    };

    var updateList = function(data, listName) {
        var list = $('#' + listName);
        var val = list.val();
        list.empty();
        var json = JSON.parse(data);
        for (var i = 0; i < json.length; i++) {
            list.append($('<option></option>')
               .attr('value', json[i]).text(json[i]));
        }
        if (json.indexOf(val) > -1) {
            list.val(val);
        } else {
            list.val('');
        }
    }

    // Public API
    return {
        updateRaces: updateRaces,
        updateLocations: updateLocations
    };
})();