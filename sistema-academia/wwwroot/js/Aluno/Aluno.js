
$(document).ready(function(){

    $('#enderecoCep').blur(function() {
        var cep = $(this).val();
        if (cep.length == 9) 
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
                    $('#enderecoLogradouro').val(data.logradouro);
                    $('#enderecoEstado').val(data.uf);
                }
                $.unblockUI();
            });
        }
    });

});