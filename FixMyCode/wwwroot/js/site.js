// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.



//Check username Credentials: 5 characters or more
function a() {
    if ($("#usernameText").val().length < 5) {
        document.getElementById("usernameLength").style.visibility = "visible";
        document.getElementById("usernameLength").style.color = "red";
    }
    else {
        document.getElementById("usernameLength").style.visibility = "hidden";
    }
}

//Checks email credentials: if it contains @
function b() {
    if (!($("#emailText").val().includes("@"))) {
        document.getElementById("emailReal").style.visibility = "visible";
        document.getElementById("emailReal").style.color = "red";
    }
    else {
        document.getElementById("emailReal").style.visibility = "hidden";
    }
}

//Checks password credentials: 8 characters and contains a number
function c() {
    if ($("#passwordText").val().length < 8 || !$("#passwordText").val().includes("\d")) {
        document.getElementById("passwordCheck").style.visibility = "visible";
        document.getElementById("passwordCheck").style.color = "red";
    }
    else {
        document.getElementById("passwordCheck").style.visibility = "hidden";
    }
}

function d() {
    if (!($("#confirm_pw").val().equals($("#passwordText").val()))) {
        document.getElementById("confirmCheck").style.visibility = "visible";
        document.getElementById("confirmCheck").style.color = "red";
    }
    else {
        document.getElementById("confirmCheck").style.visibility = "hidden";
    }
}

$(document).delegate('#textbox', 'keydown', function (e) {
    var keyCode = e.keyCode || e.which;

    if (keyCode == 9) {
        e.preventDefault();
        var start = this.selectionStart;
        var end = this.selectionEnd;

        // set textarea value to: text before caret + tab + text after caret
        $(this).val($(this).val().substring(0, start)
            + "\t"
            + $(this).val().substring(end));

        // put caret at right position again
        this.selectionStart =
            this.selectionEnd = start + 1;
    }
});