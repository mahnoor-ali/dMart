/* ajax to get username on home page on login */
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
