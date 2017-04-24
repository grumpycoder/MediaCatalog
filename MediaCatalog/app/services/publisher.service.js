//product.service.js
(function () {
    'use strict';
    var module = angular.module('app'); 
    
    module.factory('Publisher', ['$http', 'toastr', serviceController]);

    function serviceController($http, log) {

        return {
            get: get,
            getAllPublishers: getAllPublishers,
            remove: remove, 
            save: save
        };

        function get(id) {
            return $http.get('api/publisher/' + id).then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log('Oops. Something happened getting publisher');
                log.error('Oops. Somthing happened getting publisher: ' + err.data.message);
            });
        }

        function getAllPublishers() {
            return $http.get('api/publisher').then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }

        function remove(id) {
            return $http.delete('api/publisher/' + id).then(function(r) {
                return r.data;
            }).catch(function(err) {
                console.log(err.message);
            }); 
        }

        function save(product) {
            if (product.id) {
                return $http.put('api/publisher', product).then(function(r) {
                    return r.data;
                }, function (err) {
                    return err;
                });
            } else {
                console.log('posting');
                return $http.post('api/product', product).then(_success, _failure);
                //return $http.post('api/product', product).then(function (r) {
                //    console.log('success', r);
                //    return r.data;
                //}, function (err) {
                //    console.log('error', err);
                //    return err;
                //});
            }
        }


        function _success(result) {
            console.log('success', result);
            return result.data; 
        }

        function _failure(err) {
            console.log('error', err);
            return err.data; 
        }
    }

}
)();