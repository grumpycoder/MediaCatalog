//product.service.js
(function () {
    'use strict';
    var module = angular.module('app.services').factory('ProductService', mediaService);

    function mediaService($http) {

        return {
            getMedia: getMedia,
            getAllMedia: getAllMedia,
            save: save
        };

        function getMedia(id) {
            return $http.get('api/product/' + id).then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }

        function getAllMedia(searchModel) {
            return $http.get('api/product', { params: searchModel }).then(function (r) {
                return r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }

        function save(media) {
            if (media.id) {
                return $http.put('api/product', media).then(function(r) {
                    return r.data;
                }).catch(function(err) {
                    return err.message;
                });
            } else {
                return $http.post('api/product', media).then(function (r) {
                    return r.data;
                }).catch(function (err) {
                    return err.message;
                });
            }
        }

    }

}
)();