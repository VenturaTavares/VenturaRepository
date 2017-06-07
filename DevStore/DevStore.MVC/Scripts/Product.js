
$(document).ready(function () {
    //define aplicação angular e o controller
    var app = angular.module("produtosApp", []);
    //registra o controller e cria a função para obter os dados do Controlador MVC
    app.controller("produtosCtrl", function ($scope, $http) {
        $scope.Mensagem = "Olá.  Esse é nosso primeiro contato com o AgularJS no ASP .NEt MVC.";
        //$http.get('/Product/GetProdutos/')
        //.success(function (result) {
        //    $scope.produtos = result;
        //})
        //.error(function (data) {
        //    console.log(data);
        //});
    })
});