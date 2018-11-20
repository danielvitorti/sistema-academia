
$(document).ready(function(){
    $(".remove").click(function(){
        
        $("#modal-default").modal();
        var id = $(this).attr('id');
        $("#frmModal").attr("action","/treino/excluir/"+id);
        
        
    });
});
