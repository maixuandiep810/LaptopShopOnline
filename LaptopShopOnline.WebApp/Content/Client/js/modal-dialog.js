$('.dialog-link').click(function (e) {
    var a_href = $(this).attr('href');
    e.preventDefault();
    $.ajax({
        url: a_href,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('#content-wrapper').prepend(data);
            $('#MyModal').modal('show');
        },
        error: function (e) {
            var alert_box = $('#AlertBox');
            var alert_box_content = alert_box.children("#AlertBoxContent");
            alert_box_content.addClass("alert-warning");
            alert_box_content.html(e.responseJSON.message);
            alert_box.removeClass('d-none').slideDown(500).stop().delay(2000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
        }
    });
});
