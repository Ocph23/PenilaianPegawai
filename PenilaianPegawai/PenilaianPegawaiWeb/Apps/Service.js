angular.module("app.service", [])
    .factory("BaseUrl", function () {
        var service = {};
        service.URL = "";
        return service;
    })

    .factory("PagenationService", function ($filter) {

        var service = {};
        service.items = [];
        service.Load = function (items, q, size) {
            this.pageSize = size;
            this.items = items;
            this.q = q;
            this.numberOfPages = Math.ceil(this.items.length / this.pageSize);
            return $filter('filter')(this.items, this.q);
        }
        service.currentPage = 0;
        service.pageSize = 10;
        service.q = '';
        service.numberOfPages = 0;


        service.numberOfPagesData = function () {
            var data = [];
            for (var i = 0; i < this.numberOfPages; i++) {
                data.push(i);
            }
            return data;
        }

        return service;

    })

    .filter('startFrom', function () {
        return function (input, start) {
            start = +start; //parse to int
            return input.slice(start);
        }
    })


    .factory("Helpers", function ()
    {
        var service = {};
        var messages = [];
        Load();

        service.getMessage = function (code,data)
        {
            var message = "";
            if (data.Message != undefined)
                message = data.Message;
            else
                message = data;
           angular.forEach(messages, function (value, key) {
               if (value.code == code) {
                   message = value.message;
                }
            });

           return message;
        }


        service.getMessageProperty = function (data) {
            var message = "Data Anda Tidak Lengkap";
            angular.forEach(data, function (value, key) {
                message += "\r" + value;
            });

            return message;
        }

      

        function Load()
        {
            messages.push({ code: 1, message: 'Data Berhasil Ditambah' });
            messages.push({ code: 2, message: 'Data Berhasil Diubah' });
            messages.push({ code: 3, message: 'Data Berhasil DiHapus' });
            messages.push({ code: 401, message: 'Anda tidak memiliki hak akses' });
        }


        service.Kepercayaan = function ()
        {
            return ['Islam', 'Protestan', 'Khatolik', 'Hindu', 'Budha', 'Konghuchu'];
        }

        service.Golongan = function () {
            return ['II/A', 'II/B', 'II/C', 'II/D', 'III/A', 'III/B', 'III/C', 'III/D','IV/A', 'IV/B', 'IV/C', 'IV/D'];
        }


        service.JenisKelamin= function () {
            return ['L', 'P'];
        }

        service.Pendidikan = ['SMP', 'SMA', 'S1', 'S2', 'S3'];


        service.Asals = function () {
            return ['Papua', 'NonPapua'];
        }


        service.StatusKepegawaian = function () {
            return ['CPNS', 'PNS'];
        }

        service.JenisKepegawaian = function () {
            return ['PNSP', 'PNSD'];
        }

        service.SKPejabat= function () {
            return ['Presiden', 'Gubernur', 'Menteri', 'Satker'];
        }

        return service;

    })

    .factory("PejabatPenilaiService", function ($http, $q, BaseUrl, Helpers) {
        var service = {};
        var isInstant = false;
        var collection = [];
        service.source = function () {
            deferred = $q.defer();
            if (!isInstant) {
                $http({
                    method: 'GET',
                    url: BaseUrl.URL + "/api/pejabatpenilai/get",
                }).then(function (response) {
                    // With the data succesfully returned, we can resolve promise and we can access it in controller
                    collection = response.data;
                    deferred.resolve(collection);
                    isInstant = true;
                }, function (error) {
                    alert(Helpers.getMessage(error.status, error.data));
                    // deferred.reject(error);
                });

            } else {
                deferred.resolve(collection);
            }

            return deferred.promise;
        }
        service.Insert = function (model) {
            deferred = $q.defer();
            $http({
                method: 'post',
                url: BaseUrl.URL + "/api/pejabatpenilai/register",
                data: model
            }).then(function (response) {
                collection.push(response.data);
                alert(Helpers.getMessage(1, ""));
                deferred.resolve(response.data);
            }, function (error) {

                alert(Helpers.getMessage(error.status, error.data));
                // deferred.reject(error);
            });

            return deferred.promise;
        }


        service.put = function (model) {
            deferred = $q.defer();
            $http({
                method: 'put',
                url: BaseUrl.URL + "/api/pejabatpenilai/put",
                data: model
            }).then(function (response) {
                alert("Berhasil Diubah");
                deferred.resolve(response.data);
            }, function (error) {
                alert(Helpers.getMessage(error.status, error.data));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

        return service;
    })

    .factory("KriteriaService", function ($http, $q, BaseUrl,Helpers) {
        var service = {};
       var isInstant = false;
       var collection = [];
        service.source = function ()
        {
            deferred = $q.defer();
            if (!isInstant)
            {
                $http({
                    method: 'GET',
                    url: BaseUrl.URL + "/api/kriteria/Get",
                }).then(function (response) {
                    // With the data succesfully returned, we can resolve promise and we can access it in controller
                    collection = response.data;
                    deferred.resolve(collection);
                    isInstant = true;
                    }, function (error) {
                       
                            alert(Helpers.getMessage(error.status,error.data));
                   // deferred.reject(error);
                });
               
            } else
            {
                deferred.resolve(collection);
            }

            return deferred.promise;
        }
        service.post = function (model)
        {
            deferred = $q.defer();
            $http({
                method: 'post',
                url: BaseUrl.URL + "/api/kriteria/post",
                data: model
            }).then(function (response) {
                collection.push(response.data);
                alert(Helpers.getMessage(1, ""));
                deferred.resolve(response.data);
            }, function (error) {
                if (error.status == 403) {
                    alert(Helpers.getMessageProperty(error.data));
                } else
                alert(Helpers.getMessage(error.status, error.data));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

        service.put = function (model,selected) {
            deferred = $q.defer();
            $http({
                method: 'put',
                url: BaseUrl.URL + "/api/kriteria/put?id="+model.Id,
                data: model
            }).then(function (response) {
                selected.Nama = model.Nama;
                selected.Keterangan = model.Keterangan;
                alert(Helpers.getMessage(2, ""));
                deferred.resolve(response.data);
            }, function (error) {

                alert(Helpers.getMessage(error.status, error.data));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

       


        service.delete = function(model)
        {
            deferred = $q.defer();
            $http({
                method: 'delete',
                url: BaseUrl.URL + "/api/kriteria/delete?id=" + model.IdKriteria,
                data: model
            }).then(function (response) {
                var index = collection.indexOf(model);
                collection.splice(index, 1);     
                alert(Helpers.getMessage(3, ""));
                deferred.resolve(index);
            }, function (error) {

                alert(Helpers.getMessage(error.status, error.data));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

        return service;
    })


    .factory("PegawaiService", function ($http, $q, BaseUrl, Helpers) {
        var service = {};
        var isInstant = false;
        var collection = [];
        service.source = function () {
            deferred = $q.defer();
            if (!isInstant) {
                $http({
                    method: 'GET',
                    url: BaseUrl.URL + "/api/pegawai/Get",
                }).then(function (response) {
                    // With the data succesfully returned, we can resolve promise and we can access it in controller
                    collection = response.data;
                    deferred.resolve(collection);
                    isInstant = true;
                }, function (error) {
                    alert(Helpers.getMessage(error.status, error.data));
                    // deferred.reject(error);
                });

            } else {
                deferred.resolve(collection);
            }

            return deferred.promise;
        }
        service.post = function (model) {
            deferred = $q.defer();
            $http({
                method: 'post',
                url: BaseUrl.URL + "/api/pegawai/post",
                data: model
            }).then(function (response) {
                collection.push(response.data);
                alert(Helpers.getMessage(1, ""));
                deferred.resolve(response.data);
            }, function (error) {

                alert(Helpers.getMessage(error.status, error.data));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

        service.put = function (data, selected) {
            deferred = $q.defer();
            $http({
                method: 'put',
                url: BaseUrl.URL + "/api/pegawai/PutPegawai",
                data: data
            }).then(function (response) {
                var model = response.data;
                selected.NIP = model.NIP;
                selected.Nama = model.Nama;
                selected.TempatLahir = model.TempatLahir;
                selected.TanggalLahir = model.TanggalLahir;
                selected.NomorKartuPegawai = model.NomorKartuPegawai;
                selected.Pendidikan = model.Pendidikan;
                selected.PangkatGolonganTerakhir = model.PangkatGolonganTerakhir
                selected.JabatanAkhir = model.JabatanAkhir;
                selected.Asal = model.Asal;
                selected.JenisKelamin = model.JenisKelamin;
                selected.Detail = model.Detail;
                alert(Helpers.getMessage(2, ""));
                deferred.resolve(response.data);
            }, function (error) {

                alert(Helpers.getMessage(error.status, error.data.Message));
                // deferred.reject(error);
            });

            return deferred.promise;
        }




        service.delete = function (model) {
            deferred = $q.defer();
            $http({
                method: 'delete',
                url: BaseUrl.URL + "/api/pegawai/delete?id=" + model.IdPegawai,
                data: model
            }).then(function (response) {
               
                deferred.resolve(response);
            }, function (error) {

                alert(Helpers.getMessage(error.status, error.data.Message));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

        return service;
    })
  

    ;