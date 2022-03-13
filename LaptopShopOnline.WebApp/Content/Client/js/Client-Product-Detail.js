/*Client-Product-Detail*/

const btn_add_cart_input = $("#btn-add-cart-input");
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
            alert_box_content.html("Thêm mới thành công");
            alert_box.removeClass('d-none').slideDown(500).stop().delay(5000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
            var cartCount = $("#cart-count");
            cartCount.html(data.data);
        },
        error: function (e) {
            var alert_box = $('#AlertBox');
            var alert_box_content = alert_box.children("#AlertBoxContent");
            alert_box_content.addClass("alert-warning");
            alert_box_content.html("Thêm mới lỗi");
            alert_box.removeClass('d-none').slideDown(500).stop().delay(5000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
        }
    })
};