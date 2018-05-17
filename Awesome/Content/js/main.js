$(document).ready(function () {

    // Show/hide Login and register fields
    $('#login').hide();
    $('#signup').hide();
    var loginErrorMessage = $('#loginErrorMessage').attr('value');
    var signupErrorMessage = $('#signupErrorMessage').attr('value');

    if (loginErrorMessage === "value") {
        $('#login').show();
    }
    if (signupErrorMessage === "value") {
        $('#signup').show();
    }
});

//Dropdown menu
$('#dropDownList').click(function (e) {
    $('#dropDownList').addClass('active');
});