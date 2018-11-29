$(document).ready(function(){
    
  $('.money2').mask("#.##0,00", {reverse: true});

  $('.date').mask('00/00/0000');

  
  $(".date").datepicker({
    dateFormat: 'dd/mm/yy',
    dayNames: ['Domingo','Segunda','Terca','Quarta','Quinta','Sexta','Sabado','Domingo'],
    dayNamesMin: ['D','S','T','Q','Q','S','S','D'],
    dayNamesShort: ['Dom','Seg','Ter','Qua','Qui','Sex','SÃ¡b','Dom'],
    monthNames: ['Janeiro','Fevereiro','MarÃ§o','Abril','Maio','Junho','Julho','Agosto','Setembro','Outubro','Novembro','Dezembro'],
    monthNamesShort: ['Jan','Fev','Mar','Abr','Mai','Jun','Jul','Ago','Set','Out','Nov','Dez']
});

    $("#cmbAluno").select2({
        "language": "pt-BR",
         ajax: {
           url: "/alunos/ListaAlunosJson",
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
         templateResult: formatRepoAluno, 
         templateSelection: formatRepoSelectionAluno
   }); 


  /*$("#cmbAluno").on("change",function(){

    
      var alunoCodigo = "";

      alunoCodigo = $(this).val();

      $.blockUI({ message: '<h1> Aguarde...</h1>' });

      $.getJSON('/planoaluno/ListaPlanoJsonPorId/' + alunoCodigo,function(data) {
          
          
        $("#descplano").val(data["plano"].nome);
        $("#plano").val(data["plano"].id);
          
          
        $.unblockUI();
      });
  

  }); */

   function formatRepoAluno (repo) 
	{
	
	      if (repo.loading) return repo.text;

	      var markup = "<div class='select2-result-repository__id'>"+repo.id+"</div>" +
	                   "<div class='select2-result-repository__name'>"+repo.name+"</div>"; 


	      if (repo.description) 
	      {
	        	markup += "<div class='select2-result-repository__name'>"+repo.name+"</div>";
	        	markup += "<div class='select2-result-repository__id'>"+repo.id+"</div>";
	      }


	      return markup;
    }

    function formatRepoSelectionAluno(repo) 
    {

      
      $("#aluno").val(repo.id);
      $("#descaluno").val(repo.name);
      return repo.name;

    } 





    $("#cmbPlano").select2({
      "language": "pt-BR",
       ajax: {
         url: "/plano/ListaPlanosJson",
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
       templateResult: formatRepoPlano, 
       templateSelection: formatRepoSelectionPlano
 }); 



 $(".removePagamento").click(function(){
        
  $("#modal-default").modal();
  var id = $(this).attr('id');
  $("#frmModal").attr("action","/pagamentoaluno/excluir/"+id);        
  
});


 function formatRepoPlano (repo) 
{

      if (repo.loading) return repo.text;

      var markup = "<div class='select2-result-repository__id'>"+repo.id+"</div>" +
                   "<div class='select2-result-repository__name'>"+repo.name+"</div>"; 


      if (repo.description) 
      {
          markup += "<div class='select2-result-repository__name'>"+repo.name+"</div>";
          markup += "<div class='select2-result-repository__id'>"+repo.id+"</div>";
      }


      return markup;
  }

  function formatRepoSelectionPlano(repo) 
  {

    
    $("#plano").val(repo.id);
    $("#descplano").val(repo.name);
    return repo.name;

  } 




});