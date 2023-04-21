var rootUrl = "https://localhost:7253/translate/"

$(document).ready(function () {

});

function GenerateUrl(subUrl) {
    return rootUrl + subUrl;
}

function ClearTable(tableId) {
    $("#" + tableId).DataTable().destroy();
}

function CeviriKaydet(data, url) {
    CallAjax("GET", url, data, function (response) {
        TemizleCeviriTablosu();
        CeviriListele();
        ShowSuccessAlert("Ceviri islemi tamamlanmistir");
    },
        function (response) { console.log(response) });
}


function ShowSuccessAlert(errorMessage) {
    ShowGeneralAlert(errorMessage, "success");
}

function ShowErrorAlert(errorMessage) {
    ShowGeneralAlert(errorMessage, "danger");
}

function ShowInfoAlert(errorMessage) {
    ShowGeneralAlert(errorMessage, "info");
}

function ShowWarningAlert(errorMessage) {
    ShowGeneralAlert(errorMessage, "warning");
}

function ShowGeneralAlert(errorMessage, alertType) {
    $('.alert').slideUp(010, function () {
        $(this).remove();
    });

    var alertDiv = $('<div class="alert alert-' + alertType + ' fade show">')
        .html('<strong>Hata:</strong> ' + errorMessage);

    $('#alert-container').prepend(alertDiv);

    setTimeout(function () {
        alertDiv.slideUp(300, function () {
            $(this).remove();
        });
    }, 3000);
}

function CallAjax(type, url, data, onsuccess, error) {
    $.ajax({
        type: type,
        url: url,
        data: data,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: onsuccess,
        error: error,
        async: true,
        crossDomain: true,
        xhrFields: {
            withCredentials: true
        },
    });
}

function FormatDate(date) {
    return moment(date).format("YYYY-MM-DD");
}
