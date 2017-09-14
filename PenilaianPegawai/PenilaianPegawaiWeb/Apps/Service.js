angular.module("app.service", [])
    .factory("BaseUrl", function () {
        var service = {};
        service.URL = "http://localhost:52814";
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

        service.getMessage = function (code,message)
        {
           angular.forEach(messages, function (value, key) {
               if (value.code == code) {
                   message = value.message;
                }
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
        service.JenisKelamin= function () {
            return ['L', 'P'];
        }

        service.Pendidikan = function () {
            return ['SD', 'SMP', 'SMA', 'S1', 'S2', 'S3'];
        }


        service.StatusPerkawinan= function () {
            return ['Kawin', 'Belum'];
        }
        service.Kewarganegaraan = function () {
            return ['WNI', 'WNA'];
        }
        return service;

    })

    .factory("PejabatPenilaiService", function ($http, $q, BaseUrl,Helpers) {
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
                    url: BaseUrl.URL + "/api/pejabatpenilai/get",
                }).then(function (response) {
                    // With the data succesfully returned, we can resolve promise and we can access it in controller
                    collection = response.data;
                    deferred.resolve(collection);
                    isInstant = true;
                    }, function (error) {
                        alert(Helpers.getMessage(error.status,error.data.Message));
                   // deferred.reject(error);
                });
               
            } else
            {
                deferred.resolve(collection);
            }

            return deferred.promise;
        }
        service.Insert = function (model)
        {
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

                alert(Helpers.getMessage(error.status, error.data.Message));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

        service.put = function (model,selected) {
            deferred = $q.defer();
            $http({
                method: 'put',
                url: BaseUrl.URL + "/api/pejabatpenilai/put?id="+model.Id,
                data: model
            }).then(function (response) {
                selected.Nama = model.Nama;
                selected.Alamat = model.Alamat;
                selected.Level = model.Level;
                selected.Jabatan = model.Jabatan;
                alert(Helpers.getMessage(2, ""));
                deferred.resolve(response.data);
            }, function (error) {

                alert(Helpers.getMessage(error.status, error.data.Message));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

       


        service.delete = function(model)
        {
            deferred = $q.defer();
            $http({
                method: 'delete',
                url: BaseUrl.URL + "/api/pejabat/delete?id=" + model.Id,
                data: model
            }).then(function (response) {
                var index = collection.indexOf(model);
                collection.splice(index, 1);     
                alert(Helpers.getMessage(3, ""));
                deferred.resolve(response.data);
            }, function (error) {

                alert(Helpers.getMessage(error.status, error.data.Message));
                // deferred.reject(error);
            });

            return deferred.promise;
        }

        return service;
    })
    

    ;