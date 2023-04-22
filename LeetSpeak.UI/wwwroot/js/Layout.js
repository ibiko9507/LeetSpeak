//var userLoggedIn = true;
$(window).on('load', function () {
    InitiliazeLayout();
});

$(document).ready(function () {
    ActiveSelectedTab();
});

function InitiliazeLayout() {
    var userLoggedIn = true;
    if (!IsTokenValid()) {
        userLoggedIn = false;
        changeBody("/User/Login", userLoggedIn);
    }
    else {
        userLoggedIn = true;
        changeBody("/Translate/Translation", userLoggedIn);
    }
    bindClickEvents();
}

function changeBody(url) {
    $.ajax({
        url: url,
        type: "GET",
        success: function (result) {
            $("body").html(result);
        }
    });
}

$(".change-body-link").click(function ()
{
    ActiveSelectedTab();
    var url = $(this).attr("data-url");
    changeBody(url);
    bindClickEvents();
});

function bindClickEvents(userLoggedIn) {
    //$('#nav-sign-out').closest('li').css('visibility', 'hidden'); 
    $('#nav-log-in').closest('li').css('visibility', userLoggedIn ? 'hidden' : 'visible');
    $('#nav-translate').closest('li').css('visibility', userLoggedIn ? 'visible' : 'hidden');
}

function ActiveSelectedTab() {
    var activeTab = $('#navbar').find('.active');
    var activeTabHref = activeTab.children().attr('href');
    $(activeTabHref).addClass('show active');

    $('.nav-link').click(function (e) {
        e.preventDefault();
        var href = $(this).attr('href');

        $('.nav-link').not(this).parent().removeClass('active');
        $(href).siblings('.tab-pane').removeClass('show active');

        $(this).parent().addClass('active');
        $(href).addClass('show active');
    });
}