function enviar(form) {
    if (form.valid()) {
        var formData = $('#formContainer').serialize();
        console.log(formData);
        jQuery.ajax({
            type: 'POST',
            contentType: "application/json",
            url: 'Insert/RegisterPrograma/',
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
            Codigo: {
                required: true,
                minlength: 2,

            }
        }
    });

    $("#btnEnviar").on('click', function (event) {
        event.preventDefault();

        enviar(form);
    });

    $('#sede').on('change', function (event) {

        var sele = $('#sede').val();
        var text = '<span>Facultad </span>' +
            '<select name="FK_Id_Facultad" id="FK_Id_Facultad">'+
            ' <option value="">Seleccionar</option>';
        facultad = JSON.parse(facultad);
        for (var i = 0; i < facultad.length; i++) {
            //console.log(facultad[i].FK_Id_Sede + ' ' + parseInt(sele));
            if (facultad[i].FK_Id_Sede == parseInt(sele)) {
                text += '<option value="' + facultad[i].Id_Facultad + '">' + facultad[i].Nombre + '</option>';
            }
        }

        text += '</select>';

        $('#facultad').html(text);

    });

});