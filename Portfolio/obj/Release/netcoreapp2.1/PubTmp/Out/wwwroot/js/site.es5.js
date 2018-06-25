// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

"use strict";

$(document).ready(function () {
    $("#collapse").on("hide.bs.collapse", function () {
        $(".btn").html('<span class="fas fa-angle-down" aria-hidden="true" id="icon"></span>edit');
    });
    $("#collapse").on("show.bs.collapse", function () {
        $(".btn").html('<span class="fas fa-angle-up" aria-hidden="true" id="icon"></span>edit');
    });
});

