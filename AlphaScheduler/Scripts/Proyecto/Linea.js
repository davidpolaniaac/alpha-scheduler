function enviar(form) {
    if (form.valid()) {
        var formData = $('#formContainer').serialize();
        console.log(formData);
        jQuery.ajax({
            type: 'POST',
            contentType: "application/json",
            url: 'Insert/RegisterLinea/',
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
            '<select name="Id_facultad" id="Id_facultad">'+
            '<option value="">Seleccionar</option>';
        facultad = JSON.parse(facultad);
        for (var i = 0; i < facultad.length; i++) {
            if (facultad[i].FK_Id_Sede == parseInt(sele)) {
                text += '<option value="' + facultad[i].Id_Facultad + '">' + facultad[i].Nombre + '</option>';
            }
        }

        text += '</select>';

        $('#facultad').html(text);

    });

    $('#facultad').on('change', function (event) {

        var sele = $('#Id_facultad').val();
        var text = '<span>Programa </span>' +
            '<select name="FK_Id_Programa" id="FK_Id_Programa">' +
            '<option value="">Seleccionar</option>';
        programa = JSON.parse(programa);
        for (var i = 0; i < programa.length; i++) {
            console.log(programa[i].FK_Id_Sede + ' ' + parseInt(sele));
            if (programa[i].FK_Id_Facultad == parseInt(sele)) {
                text += '<option value="' + programa[i].Id_Programa + '">' + programa[i].Nombre + '</option>';
            }
        }

        text += '</select>';
        console.log(text);
        $('#programa').html(text);

    });


});