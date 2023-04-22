//var userLoggedIn = true;
$(window).on('load', function () {
    InitiliazeLayout();
});

$(document).ready(function () {
    ActiveSelectedTab();
});

function InitiliazeLayout() {
    if (!IsTokenValid()) {
        changeBody("/User/Login");
        bindClickEvents();
    }
    else {
        bindClickEvents();
    }
}

function changeBody(url) {
    $.ajax({
        url: url,
        type: "GET",
        success: function (result) {
            $("body").html(result);
            bindClickEvents();
        }
    });
}

$(".change-body-link").click(function () {
    ActiveSelectedTab();
    var url = $(this).attr("data-url");
    changeBody(url);
});

function bindClickEvents() {
    var loggedIn = IsTokenValid();
    if (loggedIn) {
        $('#nav-sign-out').closest('li').show();
        $('#nav-log-in').closest('li').hide();
        $('#nav-translate').closest('li').show();
    } else {
        $('#nav-sign-out').closest('li').hide();
        $('#nav-log-in').closest('li').show();
        $('#nav-translate').closest('li').hide();
    }
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