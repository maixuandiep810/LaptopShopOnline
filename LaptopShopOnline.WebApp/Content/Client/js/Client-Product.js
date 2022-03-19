/*Client-Product-Detail*/

const cart_inputs = $('button[id*=btn-add-cart-input]');
cart_inputs.each(function () {
    $(this).click(add_cart);
})

/*const btn_add_cart_input = $("#btn-add-cart-input");
btn_add_cart_input.click(add_cart)*/
function add_cart() {
    $(this).prop('disabled', true);
    const cart_input = $(this).siblings("#cart-input");
    cart_input.prop('disabled', true);
    var cart = {
        ProductId: $(cart_input).data('product-id'),
        Quantity: $(cart_input).val()
    }
    console.log(JSON.stringify(cart));
    $.ajax({
        context: this,
        url: '/gio-hang/them-moi',
        contentType: "application/json",
        data: JSON.stringify(cart) ,
        dataType: 'json',
        type: 'POST',
        cache: false,
        timeout: 600000,
        success: function (data) {
            var alert_box = $('#AlertBox');
            var alert_box_content = alert_box.children("#AlertBoxContent");
            alert_box_content.addClass("alert-success");
            alert_box_content.html(data.message);
            alert_box.removeClass('d-none').slideDown(500).stop().delay(2000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
            var cartCount = $("#cart-count");
            cartCount.html(data.data);
            $(this).prop('disabled', false);
            cart_input.prop('disabled', false);
        },
        error: function (e) {
            var alert_box = $('#AlertBox');
            var alert_box_content = alert_box.children("#AlertBoxContent");
            alert_box_content.addClass("alert-warning");
            alert_box_content.html(e.responseJSON.message);
            alert_box.removeClass('d-none').slideDown(500).stop().delay(2000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
            $(this).prop('disabled', false);
            cart_input.prop('disabled', false);
        }
    })
};