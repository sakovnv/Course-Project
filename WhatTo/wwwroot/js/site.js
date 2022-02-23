// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var darkModeSwitcher = document.getElementById("DarkModeSwitch");
var cookies = document.cookie;

darkModeSwitcher.onchange = function()
{
    if (darkModeSwitcher.checked == true) {
        document.cookie = "theme=dark; path=/;"
    }
    else {
        document.cookie = "theme=light; path=/;"
    }
    location.reload(true);
    console.log(document.cookie);
}

document.addEventListener("DOMContentLoaded", function (event) {
    var editor = CKEDITOR.replace('text-review');
});