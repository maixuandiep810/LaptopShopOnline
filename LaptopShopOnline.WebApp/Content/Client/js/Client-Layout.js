$(document).ready(function () {
    $('#AlertBox').removeClass('d-none').slideDown(500).stop().delay(2000).slideUp(500).delay(0).queue(function () {
        $(this).addClass('d-none');
    });
});
$(document).ready(function () {
    $().UItoTop({ easingType: 'easeOutQuart' });
});