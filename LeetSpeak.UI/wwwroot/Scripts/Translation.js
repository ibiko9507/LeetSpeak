$(document).ready(function () {
    CeviriListele();
});

$("#translate").click(function () {
    var originalText = $.trim($("#originalText").val());

    if (originalText == 0) {
        ShowErrorAlert("Enter the word to translate");
        $('#originalText').focus();
    }
    
    var data = { OriginalText: $('#originalText').val() };
    CeviriKaydet(data, GenerateUrl("translate/ConvertOriginalTextToFormattedText"));        
});

function TemizleCeviriTablosu() {
    $('#translationTable').DataTable().destroy();
}

function CeviriKaydet(data, url) {
    CallAjax("GET", url, data, function (response) {
        TemizleCeviriTablosu();
        CeviriListele();
        ShowSuccessAlert("Ceviri islemi tamamlanmistir");
    },
        function (response) { console.log(response) });
}

function CeviriListele() {
    CallAjax("GET", GenerateUrl("translate/gettranslations"), null,
        function (response) {
            var translations = JSON.parse(response.responseMessage);
            var html = null;
            $.each(translations, function (index, item) {
                html += "<tr>"
                html += "<td>" + item.OriginalText + "</td>";
                html += "<td>" + item.FormattedText + "</td>";
                html += "<td>" + FormatDate(item.CreatingDate) + "</td>";
                html += "</tr>";
            });
            $('#translationList').html(html);
            $('#translationTable').DataTable();
        },
        function (response) { console.log(response) });
}