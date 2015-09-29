$('.statChoice1').on('change', function () {
    $('.hidden1').attr('name', "Para." + $('.statChoice1 option:selected').data('property-name'));
})

$('.statChoice2').on('change', function () {
    $('.hidden2').attr('name', "Para." + $('.statChoice2 option:selected').data('property-name'));
})