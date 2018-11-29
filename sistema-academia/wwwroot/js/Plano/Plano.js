
$(document).ready(function(){
    $(".removePlano").click(function(){
        
        $("#modal-default").modal();
        var id = $(this).attr('id');
        $("#frmModal").attr("action","/plano/excluir/"+id);
        
        
    });

    $(".js-example-data-array").select2({
        "language": "pt-BR",
         ajax: {
           url: "plano/ListaPlanosJson",
           dataType: 'json',
           delay: 250,
           data: function (params) {
             return {
               q: params.term, // search term
               page: params.page
             };
           },
           processResults: function (data, params) {
            
             params.page = params.page || 1;

             return {
               results: data.items,
               pagination: {
                 more: (params.page * 30) < data.total_count
               }
             };
           },
           cache: true
         },
         escapeMarkup: function (markup) { return markup; },
         minimumInputLength: 1,
         templateResult: formatRepo, 
         templateSelection: formatRepoSelection
   }); 

   
});


