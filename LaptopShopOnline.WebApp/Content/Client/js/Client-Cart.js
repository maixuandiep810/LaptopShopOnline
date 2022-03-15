﻿/*Client-Product-Detail*/

// EDIT
const cart_inputs = $('input[id*=cart-input]');
cart_inputs.each(function () {
    $(this).change(cart_input_change);
})

function cart_input_change() {
    $(this).prop('disabled', true);
    var cart = {
        Id: $(this).data('cart-id'),
        Quantity: $(this).val()
    }
    console.log(JSON.stringify(cart));
    $.ajax({
        context: this,
        url: `/gio-hang/cap-nhat/${cart.Id}`,
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
            alert_box_content.html("Cập nhật thành công");
            alert_box.removeClass('d-none').slideDown(500).stop().delay(2000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
            var cartCount = $("#cart-count");
            cartCount.html(data.data);
            $(this).prop('disabled', false);
        },
        error: function (e) {
            var alert_box = $('#AlertBox');
            var alert_box_content = alert_box.children("#AlertBoxContent");
            alert_box_content.addClass("alert-warning");
            alert_box_content.html("Cập nhật lỗi");
            alert_box.removeClass('d-none').slideDown(500).stop().delay(2000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
            $(this).prop('disabled', false);
        }
    })
};

// DELETE
const cart_dels = $('a[id*=cart-del]');
cart_dels.each(function () {
    $(this).click(cart_del_click);
})

function cart_del_click(e) {
    e.preventDefault;
    $(this).prop('disabled', true);
    const cart_id = $(this).data('cart-id');
    $.ajax({
        context: this,
        url: `/gio-hang/xoa/${cart_id}`,
        contentType: "application/json",
        dataType: 'json',
        type: 'GET',
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
            var cart_item = $(this).parent("td").parent("#cart-item");
            cart_item.remove();
            var cartCount = $("#cart-count");
            cartCount.html(data.data);
        },
        error: function (e) {
            var alert_box = $('#AlertBox');
            var alert_box_content = alert_box.children("#AlertBoxContent");
            alert_box_content.addClass("alert-warning");
            alert_box_content.html("Xóa lỗi");
            alert_box.removeClass('d-none').slideDown(500).stop().delay(2000).slideUp(500).delay(0).queue(function () {
                $(this).addClass('d-none');
            });
            $(this).prop('disabled', false);
        }
    })
};