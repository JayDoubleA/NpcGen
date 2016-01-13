$(document).ready(function () {

    // reset list values
    npc.resetRaceLocation();

    // define list change behaviour
    $('#Para_RaceName').change(function () {
        var self = $(this);
        npc.updateLocations(self.val());
        $('#resetRaceLocation').prop('disabled', false);
    });

    $('#Para_LocationName').change(function () {
        var self = $(this);
        npc.updateRaces(self.val());
        $('#resetRaceLocation').prop('disabled', false);
    });

    // wire up list reset button
    $('#resetRaceLocation').click(function() {
        npc.resetRaceLocation();
        $(this).prop('disabled', true);
    });
});

var npc = (function () {
    // private functions
    var updateRaces = function (location) {
        jQuery.ajaxSetup({ async: false });
        $.getJSON('/ajax/RacesUpdate', { loc: location })
          .done(function (data) {
              updateList(data, 'Para_RaceName');
          });
    };

    var updateLocations = function (race) {
        jQuery.ajaxSetup({ async: false });
        $.getJSON('/ajax/UpdateLocations', { rac: race })
          .done(function (data) {
              updateList(data, 'Para_LocationName');
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
            var length = list.children('option').length;
            if (length === 1) {
                list.selectedIndex = 0;
            } else {
                list.val('');
            }
        }
    }

    var resetRaceLocation = function () {
        $('#Para_LocationName').val('');
        $('#Para_RaceName').val('');
    }

    // Public API
    return {
        updateRaces: updateRaces,
        updateLocations: updateLocations,
        resetRaceLocation: resetRaceLocation
    };
})();