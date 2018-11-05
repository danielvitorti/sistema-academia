$(document).ready(function(){

    $("#plano").autocomplete({
        source: function (request, response) {
               $.ajax({
                   url: '/Plano/ListaPlanosJson',
                   type: 'GET',
                   cache: false,
                   data: request,
                   dataType: 'json',
                   success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item,
                            value: item + ""
                        }
                    }))
                   }
               });
           },
           minLength: 2,
           select: function (event, ui) {
               //alert('you have selected ' + ui.item.label + ' ID: ' + ui.item.value);
               $('#aluno').val(ui.item.label);
               return false;
           }
    });


});