//product.service.js
(function () {
    'use strict';
    var module = angular.module('app'); 
    
    module.factory('Product', ['$http', serviceController]);

    function serviceController($http) {

        return {
            getProduct: getProduct,
            getAllProducts: getAllProducts,
            remove: remove, 
            save: save
        };

        function getProduct(id) {
            return $http.get('api/product/' + id).then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }

        function getAllProducts(searchModel) {
            return $http.get('api/product', { params: searchModel }).then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }

        function remove(id) {
            return $http.delete('api/product/' + id).then(function(r) {
                return r.data;
            }).catch(function(err) {
                console.log(err.message);
            }); 
        }

        function save(product) {
            if (product.id) {
                return $http.put('api/product', product).then(function(r) {
                    return r.data;
                }).catch(function(err) {
                    return err.message;
                });
            } else {
                return $http.post('api/product', product).then(function (r) {
                    return r.data;
                }).catch(function (err) {
                    return err.message;
                });
            }
        }

    }

}
)();