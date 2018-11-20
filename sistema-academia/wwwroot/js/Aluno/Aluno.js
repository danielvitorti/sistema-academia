
$(document).ready(function(){

    $("#enderecoCep").mask('99999999');
    
    $('#enderecoCep').blur(function() {
        
        var cep = $(this).val();
        if (cep.length == 8) 
        {

            
            $.blockUI({ message: '<h1> Aguarde...</h1>' });
            $.getJSON('https://viacep.com.br/ws/' + cep + '/json/',function(data) {
                if (data.erro == true) 
                {
                    alert('CEP Inválido!');
                } 
                else 
                {
                    $('#enderecoBairro').val(data.bairro);
                    $('#enderecoComplemento').val(data.complemento);
                    $('#enderecoCidade').val(data.localidade);
                    $('#enderecoRua').val(data.logradouro);
                    $('#enderecoEstado').val(data.uf);
                }
                $.unblockUI();
            });
        }
    });

    $(".removeAluno").click(function(){
        
        $("#modal-default").modal();
        var id = $(this).attr('id');
        $("#frmModal").attr("action","/alunos/excluir/"+id);        
        
    });

});