
function showCategoryItems() {
    $.ajax(
        {
            url: "/Admin/postResult",
            method: "POST",
            success: function (result) {
                $('#productsBox').html(result);
            },
            error: function (error) {
            },
        })
}

function searchProduct() {
    $.ajax({
        method: 'POST',
        url: '/Product/SearchResult',
        data: $("#search").serialize(),
        success: function (result) {
            $('body').html(result);
        },
        error: function () {
            console.log('Failed search');
        }
    })
  }

// POST REQUEST

function addProduct() {
    var name = $("#name").val();
    var price = $("#price").val();
    var quantity = $("#quantity").val();
    var description = $("#description").val();
    var categoryId = $("#categoryId").val();
    var discount = $("#discount").val();
    var discountPercentage = $("#discountPercentage").val();
    
    var item = $("#addForm").serialize();
    var imgUrl = "";

    var item2 = {
        Name: name,
        Description: description,
        Price: price,
        Quantity: quantity,
        ImageUrl: imgUrl,
        CategoryId: categoryId,
        Discount: discount,
        DiscountPercentage: discountPercentage
    }
    var input = document.getElementById("productImage"); //get image file input id
    var files = input.files; //get files
    var formData = new FormData(); //create form
    formData.append("files", files[0]); //get only one image per product

    console.log(item);
    console.log(formData);

    $.ajax({
        type: 'POST',
        url: '/Admin/addProduct',
        headers: {
            'RequestVerificationToken': '@AntiForgery.GetAndStoreTokens(HttpContext).RequestToken'
        },
        data: { item: item, postedImage: formData },
        processData: false,// tell jQuery not to process the data
        contentType: false,
        cache: false,
        success: function (result) {
            console.log('Successfully added new product');
            alert(result);
        },
        error: function () {
            console.log('Failed to receive the new product data');
        }
    })
}
  
  
  


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
