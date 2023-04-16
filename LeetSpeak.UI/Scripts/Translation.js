$(document).ready(function () {
    CeviriListele();
});

$("#translationTable").click(function () {
    Save_Arac("http://localhost:60245/home/Save_Arac");
    clear();
});

function CallAjax(type, url, data, onsuccess, error) {
    $.ajax({
        type: type,
        url: url,
        data: data,
        dataType: "json",
        success: onsuccess,
        error: error,
        async: false
    });
}
function CeviriListele() {
    CallAjax("GET", 'http://localhost:60245/home/Get_MarkaListesi', null, function (response) {
        var html = "<option value='0'>Lütfen Seçiniz</option>";
        $.each(response, function (index, item) {
            html += "<option value='" + item.markaId + "'>" + item.markaAdi + "</option>";
        });
        $('#selectMarka').html(html);
    });
    console.log("aa");
}