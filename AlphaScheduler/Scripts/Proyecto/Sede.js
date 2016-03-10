
function enviar(form) {
    if (form.valid()) {
        var formData = $('#formContainer').serialize();
        console.log(formData);
        jQuery.ajax({
            type: 'POST',
            contentType: "application/json",
            url: 'http://localhost:24973/Insert/RegisterSede/',
            crossDomain: true,
            data: formData,
            dataType: 'jsonp',
            jsonp: 'postgrado_request',
            async: true,
            success: function (data) {

                if (data.status == 'success') {

                    alert("Datos guardados");

                } else {
                    alert("No se puede guardar");
                }
            },
            error: function () {
                alert("No se puede comunicar con el servidor");
            }
        });
    }
}


$(document).ready(function () {


    $('#tableDetails').dataTable({
        "order": [[0, "desc"]]
    });

    form = $("#formContainer");

    form.validate({
        debug: true,
        rules: {
            Nombre: {
                required: true,
                minlength: 2,

            },
            Ubicacion: {
                required: true,
                minlength: 2,

            }
        }
    });

    $("#btnEnviar").on('click', function (event) {
        event.preventDefault();

        enviar(form);
    });

});
