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
    .directive('fileModel', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                var model = $parse(attrs.fileModel);
                var modelSetter = model.assign;

                element.bind('change', function () {
                    scope.$apply(function () {
                        modelSetter(scope, element[0].files[0]);
                        var canvas = element.parent().find('img');
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            canvas.attr('src', e.target.result)

                        };
                        reader.readAsDataURL(element[0].files[0]);
                    });
                });
            }
        };
    }])

    .directive('fileCanvas', ['$parse', function ($parse) {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                var model = $parse(attrs.fileCanvas);
                element.bind('click', function () {
                    var input = element[0].querySelector("input");
                    input.click();
                });


            }
        };
    }])

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