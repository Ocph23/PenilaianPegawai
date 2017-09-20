angular.module("app.controller", [])
    .controller("PejabatPenilaiController", function ($scope,$window,PejabatPenilaiService,PegawaiService) {
        $scope.TambahTitle = "Tambah Pejabat";
        $scope.IsNew = true;
        $scope.Pejabats = [];
        PejabatPenilaiService.source().then(function (data) {
            try {
                $scope.Pejabats = data;
                PegawaiService.source().then(function (response) {
                    $scope.Pegawais = response;
                });
            } catch (e) {
                alert(e.Message);
            }
        });

        $scope.Save = function (model)
        {
            model.Id = 0;

            PejabatPenilaiService.Insert(model).then(function (response) {
               
            });
        }
     

        $scope.DeleteItem = function (item)
        {
            var deleteUser = $window.confirm("Anda Yakin Menghapus " + "'" + item.Nama + "'?");
            if (deleteUser) {
                PejabatService.delete(item).then(function (response) {

                });
            }
        }


        $scope.Detail = function (item) {
            $scope.detail = item;
        }
    })
    
    .controller("KriteriaController", function ($scope, $window, KriteriaService, PagenationService) {
        $scope.IsBusy = false;
        $scope.Kriterias = [];
        $scope.Pagenation = PagenationService;
        $scope.Search = '';
        $scope.Init = function()
        {
            KriteriaService.source().then(function (response) {
                $scope.Kriterias = $scope.Pagenation.Load(response, $scope.Search, 10);
            });

        }
      
        $scope.SetNoActive = function (item) {
            $scope.SelectedRW = item;
            $(document).ready(function () {
                $('.btn').click(function (e) {

                    var a = $('.btn').removeClass('active');


                });
            });



        };



        $scope.Selected = function(item)
        {
            $scope.SelectedItem = item;
            $scope.model = angular.copy(item);
        }


        $scope.Save = function (model)
        {
            try {
                $scope.IsBusy = true;
                if (model.IdKriteria === undefined) {
                    KriteriaService.post(model).then(function (response) {
                        $scope.Kriterias.push(response);
                    });
                } else {
                    KriteriaService.put(model, $scope.SelectedItem).then(function (respon) {

                    });
                }

            } catch (e) {
                alert(e.message);
            } finally
            {
                $scope.IsBusy = false;
            }
           
           
          
        }

        $scope.Delete = function (item) {
            var deleteUser = $window.confirm("Anda Yakin Menghapus " + "' Kriteria " + item.Nama + "'?");
            if (deleteUser) {
                KriteriaService.delete(item).then(function (index) {
                    $scope.Kriterias.splice(index, 1);
                });
            }
           
        };

    })


    .controller("PegawaiController", function ($scope, $window, PegawaiService, PagenationService,Helpers,$rootScope) {
        $scope.IsBusy = false;
        $scope.Pegawais = [];
        $scope.Pagenation = PagenationService;
        $scope.Search = '';
     

        PegawaiService.source().then(function (response) {
            $scope.Pegawais = $scope.Pagenation.Load(response, $scope.Search, 10);
        });

        $scope.Selected = function (item) {
            $scope.SelectedItem = item;
            $rootScope.SelectedPegawai = item;
            $scope.model = angular.copy(item);
        }
        $scope.UploadFoto = function (file,model)
        {
            if (file !== undefined) {
                var url = "/api/Photo/Post";
                var form = new FormData();
                form.append("file", file);
                form.append("NIP", model.NIP);
                var settings = {
                    "async": true,
                    "crossDomain": true,
                    "url": url,
                    "method": "Post",
                    "headers": {
                        "cache-control": "no-cache",
                    },
                    "processData": false,
                    "contentType": false,
                    "mimeType": "multipart/form-data",
                    "data": form
                }

                $.ajax(settings).done(function (response, data) {
                    alert("Foto Berhasil Diubah");
                    var d = JSON.parse(response);
                    $scope.SelectedItem.Foto = d.Foto;
                }).error(function (response) {
                    alert(response.responseText);
                    })

                    ;
            } else {
                alert("Anda Belum Memilih File Foto");
            }
        }
       

        $scope.Save = function (model) {
            try {
                $scope.IsBusy = true;
                if (model.IdKriteria === undefined) {
                    PegawaiService.post(model).then(function (response) {
                        $scope.Kriterias.push(response);
                    });
                } else {
                    PegawaiService.put(model, $scope.SelectedItem).then(function (respon) {

                    });
                }

            } catch (e) {
                alert(e.message);
            } finally {
                $scope.IsBusy = false;
            }



        }


        $scope.Detail = function (item)
        {
            $scope.detail = item.Detail;
        }

        $scope.Delete = function (item) {
            var deleteUser = $window.confirm("Anda Yakin Menghapus " + "' Kriteria " + item.Nama + "'?");
            if (deleteUser) {
                PegawaiService.delete(item).then(function (index) {
                    $scope.Kriterias.splice(index, 1);
                });
            }

        };

    })

    .controller("TambahPegawaiController", function ($scope, $window, PegawaiService, PagenationService,Helpers,$rootScope) {
        $scope.IsBusy = false;
        $scope.Kriterias = [];
        $scope.Pagenation = PagenationService;
        $scope.Search = '';
        $scope.Helpers = Helpers;
        $scope.Init = function ()
        {
            if ($rootScope.SelectedPegawai != undefined)
            {
                $scope.model = angular.copy($rootScope.SelectedPegawai);
                $scope.model.TanggalLahir = new Date($scope.model.TanggalLahir);
                if ($scope.model.Detail != null)
                {
                    $scope.model.Detail.TamatCPNS = new Date($scope.model.Detail.TamatCPNS);
                    $scope.model.Detail.TamatGolongan = new Date($scope.model.Detail.TamatGolongan);
                    $scope.model.Detail.TamatJabatan = new Date($scope.model.Detail.TamatJabatan);
                    $scope.model.Detail.TanggalSK = new Date($scope.model.Detail.TanggalSK);
                }
            }
        }

        $scope.Save = function (model) {
            try {
                if ($rootScope.SelectedPegawai != undefined)
                {
                    $scope.IsBusy = true;
                    model.Detail.NIP = model.NIP;
                    PegawaiService.put(model, $rootScope.SelectedPegawai).then(function (response) {
                    });
                } else
                {
                    $scope.IsBusy = true;
                    model.Detail.NIP = model.NIP;
                    PegawaiService.post(model).then(function (response) {
                    });
                }
            } catch (e) {
                alert(e.message);
            } finally {
                $scope.IsBusy = false;
            }



        }

        $scope.Delete = function (item) {
            var deleteUser = $window.confirm("Anda Yakin Menghapus " + "' Kriteria " + item.Nama + "'?");
            if (deleteUser) {
                KriteriaService.delete(item).then(function (index) {
                    $scope.Kriterias.splice(index, 1);
                });
            }

        };

    })


    .controller("PenilaianController", function ($scope, $rootScope, PagenationService) {
        $scope.Strukturs = [];
        $scope.IsBusy = false;
        $scope.Kepercayaan = Helpers.Kepercayaan();
        $scope.JenisKelamin = Helpers.JenisKelamin();
        $scope.KartuKeluarga = [];
        $scope.Pagenation = PagenationService;
        $scope.Search = '';

        KartuKeluargaService.source().then(function (response) {
            $scope.KartuKeluarga = $scope.Pagenation.Load(response, $scope.Search, 10); 
            StrukturKelurahanService.source().then(function (response) {
                $scope.Strukturs = response.data;
            });
        });
      
        $scope.SimpanKK = function (data,penduduk) {
            try {
                $scope.IsBusy = true;
                data.Id = 0;
                data.RTId = data.RT.Id;
                data.DaftarKeluarga = [];
                penduduk.Id = 0;
                data.DaftarKeluarga.push(penduduk);
                KartuKeluargaService.Insert(data).then(function (response) { })
            } catch (e) {
                alert(e.message);
            } finally {
                $scope.IsBusy = false;
            }



        }

      

        $scope.SaveEditRT = function (item, selected) {
            StrukturKelurahanService.putRT(item, selected).then(function (response) { });

        };

        $scope.DeleteRT = function (item, daftar) {
            var deleteUser = $window.confirm("Anda Yakin Menghapus " + "' RT " + item.Nama + "'?");
            if (deleteUser) {
                StrukturKelurahanService.deleteRT(item, daftar).then(function (response) { });
            }

        };


        $scope.GotoDetails = function (kk)
        {
            $rootScope.SelectedKK = kk;
        }

    })

    .controller("LaporanController", function ($scope, $window, Helpers, $rootScope) {

        $scope.Strukturs = [];
        $scope.IsBusy = false;
        $scope.Kepercayaan = Helpers.Kepercayaan();
        $scope.JenisKelamin = Helpers.JenisKelamin();
        $scope.Kewarganegaraan = Helpers.Kewarganegaraan();
        $scope.Hubungan = Helpers.Hubungan();
        $scope.Pendidikan = Helpers.Pendidikan();
        $scope.StatusPerkawinan = Helpers.StatusPerkawinan();
        $scope.KartuKeluarga = $rootScope.SelectedKK;

        $scope.SimpanAnggota = function(model)
        {
            KartuKeluargaService.postanggota(model, $scope.KartuKeluarga ).then(function (response) { })
        }
        $scope.SelectPerson = function(item)
        {
            $scope.SelectedPerson = item;
            $scope.Person = angular.copy(item);
            $scope.Person.TanggalLahir = new Date(item.TanggalLahir);

        }
        $scope.SimpanEditAnggota = function (person)
        {
            KartuKeluargaService.putperson(person, $scope.SelectedPerson).then(function (response) { });
        }

    })

    ;