$(document).ready(function () {
    CeviriListele();
});

$("#translationTable").click(function () {
    //Save_Arac("https://localhost:7253/translate/gettranslations");
    //clear();
});

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
function CeviriListele() {
    CallAjax("GET", "https://localhost:7253/translate/gettranslations", null,
        function (response) {
            var translations = JSON.parse(response.responseMessage);
            var html = null;
            $.each(translations, function (index, item) {
                html += "<tr>"
                html += "<td>" + item.OriginalText + "</td>";
                html += "<td>" + item.FormattedText + "</td>";
                html += "<td>" + item.CreatingDate + "</td>";
                html += "</tr>";
            });
            $('#translationList').html(html);
            $('#translationTable').DataTable();
        },
        function (response) { console.log(response) });
        //todo: Bind iþlemleri Generic yapýlacak
}

function CeviriListeleOnSuccess(response) {
    var translations = response;
    var html = null;
    $.each(aracListesi, function (index, item) {
        html += "<tr>"
        html += "<td>" + 1 + "</td>";
        html += "<td>" + 1 + "</td>";
        html += "<td>" + 1 + "</td>";
        html += "</tr>";
    });
    $('#translationList').html(html);
    $('#translationTable').DataTable();
}