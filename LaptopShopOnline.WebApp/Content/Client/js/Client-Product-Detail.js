/*Client-Product-Detail*/

const btn_add_cart_input = $("#btn-add-card-input");
btn_add_cart_input.click(add_cart)
function add_cart() {
    const cart_input = $("#cart-input");
    var cart = {
        ProductId: $(cart_input).data('product-id'),
        Quantity: $(cart_input).val()
    }
    console.log(JSON.stringify(cart));
    $.ajax({
        url: '/gio-hang/them-moi',
        data: { cart: JSON.stringify(cart) },
        dataType: 'json',
        type: 'POST',
        success: function (data) {
            var alert_box = $('#AlertBox');
            var alert_box_content = alert_box.children("#AlertBoxContent");
            alert_box_content.html("OKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK");
            alert_box.removeClass('d-none').slideDown(500).stop().delay(5000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
        },
        error: function (e) {
            var alert_box = $('#AlertBox');
            var alert_box_content = alert_box.children("#AlertBoxContent");
            alert_box_content.html("Failllllllllllllllllllllllllll");
            alert_box.removeClass('d-none').slideDown(500).stop().delay(5000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
        }
    })
};