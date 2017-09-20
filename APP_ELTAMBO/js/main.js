/* Mis Funciones */
$(document).ready(function () {
    totalItems();
    $('.cart_quantity_up').on('click', function () {
        var $qty = $(this).closest('.cart_quantity_button').find('input.cart_quantity_input');
        var currentVal = parseInt($qty.val());
        if (!isNaN(currentVal)) {
            $qty.val(currentVal + 1);
        }

    });
    $('.cart_quantity_down').on('click', function () {
        var $qty = $(this).closest('.cart_quantity_button').find('.cart_quantity_input');
        var currentVal = parseInt($qty.val());
        if (!isNaN(currentVal) && currentVal > 1) {
            $qty.val(currentVal - 1);
        }
    });
});

function update(id) {
    cant = $("#cantid_" + id).val();
    console.log(cant);
    var info = {
        'IdProducto': id,
        'Cantidad': cant
    }
    $.ajax({
        type: "POST",
        url: '/Carrito/AumentarItem',
        contentType: "application/json; charset=utf-8",
        processData: false,
        data: JSON.stringify(info),
        success: function (result) {
            msgnotif(result.message, "sucess");
            location.reload();
        },
        error: function (xhr) {
            console.log(xhr.responseText);
        }
    });
}

function addProducto(x) {
    var info = {
        'IdProducto': x,
        'Cantidad': 1
    }
    $.ajax({
        type: "POST",
        url: '/Carrito/AgregarProducto',
        contentType: "application/json; charset=utf-8",
        processData: false,
        data: JSON.stringify(info),
        success: function (result) {
            msgnotif(result.message, "sucess");
            totalItems();
        },
        error: function (xhr) {
            console.log(xhr.responseText);
        }
    });
}

function quitarProducto(x) {
    var info = {
        'IdProducto': x
    }
    $.ajax({
        type: "POST",
        url: '/Carrito/quitarProducto',
        contentType: "application/json; charset=utf-8",
        processData: false,
        data: JSON.stringify(info),
        success: function (result) {
            msgnotif(result.message, "warning");
            location.reload();
        },
        error: function (xhr) {
            console.log(xhr.responseText);
        }
    });
}

function totalItems() {
    $.ajax({
        type: "POST",
        url: '/Carrito/TotalItems',
        contentType: "application/json; charset=utf-8",
        processData: false,
        success: function (result) {
            $.each(result, function (i, item) {
                $("#shop").text(item);
            });
        },
        error: function (xhr) {
            console.log(xhr.responseText);
        }
    });
}

function msgnotif(x,type) {
    notif({
        msg: x,
        type: type,
        position: "center",
        timeout: 1500,
        bgcolor:"#A61493",
        color: "#FFFFFF"
    });
}


 var RGBChange = function () {
     $('#RGB').css('background', 'rgb(' + r.getValue() + ',' + g.getValue() + ',' + b.getValue() + ')')
};	
		