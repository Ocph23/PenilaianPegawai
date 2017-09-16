angular.module('app', ['app.service','app.controller','ngRoute'])
.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "../Apps/Views/main.html",
        })
        .when("/pejabatpenilai", {
            templateUrl: "../Apps/Views/pejabatpenilai.html",
            controller: "PejabatPenilaiController"
        })
     
        .when("/pegawai", {
            templateUrl: "../Apps/Views/pegawai.html",
            controller:"PegawaiController"
        })

        .when("/tambahpegawai", {
            templateUrl: "../Apps/Views/tambahpegawai.html",
            controller: "TambahPegawaiController"
        })
        .when("/detailpegawai", {
            templateUrl: "../Apps/Views/detailpegawai.html",
            controller: "DetailPegawaiController"
        })
      
        .when("/kriteria", {
            templateUrl: "../Apps/Views/kriteria.html",
            controller: "KriteriaController"
        })

        .when("/laporan", {
            templateUrl: "../Apps/Views/laporan.html",
            controller: "LaporanDetailController"
        })

        .when("/permohonan", {
            templateUrl: "../Apps/Views/permohonan.html",
        })
    ;
})

.controller("RedController", function ($scope) {

    $scope.RW= [];

    $scope.Init=function()
    {
        var rw ={};
        rw.Nama="I";
        rw.RT=[];
        
        var rt1 = {};
        rt1.Nama="1";

        var rt2 = {};
        rt2.Nama="2";


        rw.RT.push(rt1);
        rw.RT.push(rt2);

        $scope.RW.push(rw);
        $scope.RW.push({ 'Nama': 'II' });

    }

    $scope.ShowName=function(model)
    {
        $scope.RW.push(model);
    }

   


})







    ;