
$(document).ready(function () {

    $(".category").click(function () {
        $.get('/Admin/postResult', function (result) {
            $('#productsBox').html(result);
            
        });
    })
});


/* POST REQUEST
 
 
    $("#addProd").click(function () {
        {
            var name = $("#name").val();
            var price = $("#price").val();
            var quantity = $("#quantity").val();
            var description = $("#description").val();
            var categoryId = $("#categoryId").val();
            var discount = $("#discount").val();
            var discountPercentage = $("#discountPercentage").val();
            var img = $("#productImage").prop("file");
            $.ajax({
                type: 'POST',
                url: '/Admin/addProduct',
                data: { name, price, quantity, description, categoryId, discount, discountPercentage }, img,
                headers: {
                    'RequestVerificationToken': '@AntiForgery.GetAndStoreTokens(HttpContext).RequestToken'
                },
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                data: data,
                success: function (result) {
                    console.log('Successfully added new product');
                },
                error: function () {
                    console.log('Failed to receive the new product data');
                }
            })
        }
    }
  )
  
  */



/* ajax to get username on home page on login 

String name = $('#userMail').val();  

function welcomeUser() {
    var data = $('#userMail').val();
    alert(data);
    $.ajax({
        type: 'POST',
        url: '/signup/Login',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        data: data,
        success: function (result) {
            alert('Welcome to dMart. Thanks for using us ');
            console.log(result);
        },
        error: function () {
            alert('Failed to receive the Data');
            console.log('Failed ');
        }
    })
}

*/
