
// Write your JavaScript code.

//function FillCities(lstCountryCtrl, lstCityId) {
//    var lstCities = $("#" + lstCityId);
//    lstCities.empty();

//    lstCities.append($('<option/>',
//        {
//            value: null,
//            text: "Select City"
//        }));

//    var selectedCountry = lstCountryCtrl.options[lstCountryCtrl.selectedIndex].value;

//    if (selectedCountry != null && selectedCountry != '') {
//        $.getJSON('/Customer/getcitiesbycountry', { countryId: selectedCountry }, function (cities) {
//            if (cities != null && !jQuery.isEmptyObject(cities)) {
//                $.each(cities, function (index, city) {
//                    lstCities.append($('<option/>',
//                        {
//                            value: city.value,
//                            text: city.text
//                        }));
//                });
//            };
//        });
//    }
//    return;
//}


$(".custom-file-input").on("change", function () {

    var fileName = $(this).val().split("\\").pop();

    document.getElementById('PreviewPhoto').src = window.URL.createObjectURL(this.files[0]);

    document.getElementById('PhotoUrl').value = fileName;

});

$(".Falcustom-file-input").on("change", function () {

    var falfileName = $(this).val().split("\\").pop();

    document.getElementById('FalPreviewPhoto').src = window.URL.createObjectURL(this.files[0]);

    document.getElementById('FalPhotoUrl').value = falfileName;

});

$(".Farcustom-file-input").on("change", function () {

    var farfileName = $(this).val().split("\\").pop();

    document.getElementById('FarPreviewPhoto').src = window.URL.createObjectURL(this.files[0]);

    document.getElementById('FarPhotoUrl').value = farfileName;

});

//function ShowCreateModalForm() {
//    $("#DivCreateDialogHolder").modal('show');
//    return;
//}

//window.setTimeout(function () {
//    $(".alert").fadeTo(100, 0).slideUp(100, function () {
//        $(this).remove();
//    });
//}, 2000);

