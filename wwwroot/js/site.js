
function loadDeals() {
    $.ajax(
        {
            url: "/Home/getTopDealsVc",
            method: "GET",
            success: function (result) {
                $('#topDeals').html(result);
            },
            error: function (error) {
                alert("Oops! unable to load deals");
            }
        })
}

function showCategoryItems(categoryId) {
    var id = categoryId;
    $.ajax(
        {
            method: 'POST',
            url: "/Product/ProductsByCategory",
            data: { categoryId: id },
            success: function (result) {
                $('#productsBox').html(result);
            },
            error: function (error) {
                console.log("error fetching products by category");
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

    var item = $("#addForm").serialize();
    var imgUrl = "";
   // var file = $("#img").get(0).files[0];
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
  
