// Write your Javascript code.
$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("menuDisplayed");
    $(".sidebar-nav li").removeClass("menu-selected");
});

// Write your Javascript code.
$(".sidebar-nav li").click(function (e) {
    e.preventDefault();
    $(".sidebar-nav li").removeClass("menu-selected");
    $(this).addClass("menu-selected");
});
