
$(document).ready(function(){
    $(".removePlano").click(function(){
        
        $("#modal-default").modal();
        var id = $(this).attr('id');
        $("#frmModal").attr("action","/plano/excluir/"+id);
        
        
    });
});
