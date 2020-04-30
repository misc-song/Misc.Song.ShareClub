// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    var w = $(".initElement").width();
    height = w * (9 / 16);
    $(".initElement").attr("style", "height:" + height + "px")
    console.log(w);

   


})