function EnviaCadastro() {
    var nome = $("#nomeCliente").val();
    var email = $("#email").val();
    var telefone = $("#telefone").val();
    var endereco = $("#endereco").val();
    var complemento = $("#complemento").val();
    var bairro = $("#bairro").val();
    var municipio = $("#municipio").val();
    var UF = $("#UF").val();
    var cep = $("#cep").val();
    var imagem = $("#foto").val();

    var data = { nome, email, telefone, endereco, complemento, bairro, municipio, UF, cep, imagem };
    var dados = JSON.stringify(data);

    $.ajax({
        url: 'https://gabrielsalomao-sqlazure.azurewebsites.net/Cadastro',
        type: 'post',
        contentType: 'application/json',
        data: dados
    }).done(function (response) {
        console.log(response);
    });
}

