$(function () {
    $("#add").click(function () {
        var isValid = true;

        if (document.getElementById("productsItems").selectedIndex == 0) {
            $('#productsItems').siblings('span.error').text('Please select item');
            isValid = false;
        }
        else {
            $('#productsItems').siblings('span.error').text('');
        }

        if (!($("#quantity").val().trim() != '' && (parseInt($('#quantity').val()) || 0))) {
            $('#quantity').siblings('span.error').text('Please enter quantity');
            isValid = false;
        }
        else {
            $('#quantity').siblings('span.error').text('');
        }

        if (!($("#price").val().trim() != '' && (parseFloat($('#price').val()) || 0))) {
            $('#price').siblings('span.error').text('Please enter price');
            isValid = false;
        }
        else {
            $('#price').siblings('span.error').text('');
        }

        if (isValid) {

            var total = parseInt($("#quantity").val()) * parseFloat($("#price").val());
            $("#total").val(total);

            var ProductID = document.getElementById("productsItems").value;

            var $newRow = $("#MainRow").clone().removeAttr('id');

            $('.productsItems', $newRow).val(ProductID);

            $('#add', $newRow).addClass('remove').html('Remove').removeClass('btn-success').addClass('btn-danger');

            $('#productsItems, #quantity, #price', $newRow).attr('disabled', true);

            $("#productsItems, #quantity, #price, #total", $newRow).removeAttr("id");
            $("span.error", $newRow).remove();

            $("#OrderItems").append($newRow[0]);

            document.getElementById("productsItems").selectedIndex = 0;
            $("#price").val('');
            $("#quantity").val('');
            $("#total").val('');
        }
    });

    $("#OrderItems").on("click", ".remove", function () {
        $(this).parents("tr").remove();
    });

    $("#submit").click(function () {
        var isValid = true;

        var itemsList = [];

        $("#OrderItems tr").each(function () {
            var item = {
                ProductID: $('select.productsItems', this).val(),
                Price: $('.price', this).val(),
                Quantity: $('.quantity', this).val(),
                TotalPrice: $('.total', this).val()
            }
            itemsList.push(item);
        });

        if (itemsList.length == 0) {
            $('#orderMessage').text('Please add items !');
            isValid = false;
        }

        if (isValid) {
            var data = {
                Date: $("#date").val(),
                Items: itemsList
            }

            $("#submit").attr("disabled", true);
            $("#submit").html('Please wait ...');

            $.ajax({
                type: 'POST',
                url: '/Invoices/AddOrderAndOrderDetials',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {
                    if (data.status) {
                        $('#orderMessage').text(data.message);
                        $("#submit").attr("disabled", false);
                        $("#submit").html('Submit');
                    }
                    else {
                        $('#orderMessage').text(data.message);
                        $("#submit").attr("disabled", false);
                        $("#submit").html('Submit');
                    }
                }
            });
        }
    });
});