$(document).ready(function () {


    $('#userlogin').click(function () {
        //var data = {
        //    "userid": $("#userid").val();
        //    "pass": $("#pass").val();
        //};
        $.ajax({
            url: '/Home/validateuser',
            //type: 'post',
            //data: JSON.stringify(data),
            //dataType: JSON,
            //contentType: "application/json",

            success: function (result) {
                //if (response.Success) {
                //    $.get("@url.Action('Mainpage', 'Home')", function (data) {
                //        $('#test - form').html(data);
                //    });
                //}
                //else
                //    window.location.href = "@url.Action('Mainpage', 'Home')";
                alert("hii");

            },
            //error: function () {
            //    console.log('login fail');
            //}
        });
    });

});
