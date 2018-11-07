$(document).ready(function(){


    $("#plano").select2({});


    /*$('#plano').select2({
        minimumInputLength: 2,
        ajax: {
            //url: "teste.json",
            url: '/Plano/ListaPlanosJson',
            dataType: 'json',
            data: function (term, page) {
                return {
                    q: term
                };
            },
            results: function (data, page) {
                return {
                    results: data
                };
            }
        }
    }); */

    $("#aluno").select2({});

    /*$("#plano").autocomplete({
        source: function (request, response) {
               $.ajax({
                   url: '/Plano/ListaPlanosJson',
                   type: 'GET',
                   cache: false,
                   data:'{QueryFilter: "' + request.term  + '"}',
                   dataType: 'json',
                   success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label: item.name,
                            value: item.id
                        };
                    }))
                   }
               });
           },
           minLength: 3,
           select: function (event, ui) {
               //alert('you have selected ' + ui.item.label + ' ID: ' + ui.item.value);
               $('#aluno').val(ui.item.label);
               return false;
           }
    }); */



    


});