//product-list.component.js
(function () {
    'use strict';

    var module = angular.module('app');

    function controller($modal, product, user) {
        var $ctrl = this;
        var pageSizeDefault = 10;
        var tableStateRef;

        $ctrl.searchModel = {
            page: 1,
            pageSize: pageSizeDefault
        };

        $ctrl.$onInit = function () {
            console.log('product list init');
            $ctrl.title = 'Product List';
            user.getToken();
        }

        $ctrl.search = function (tableState) {
            tableStateRef = tableState;
            console.log('search');
            product.getAllProducts($ctrl.searchModel).then(function (r) {
                $ctrl.products = r.results;
                $ctrl.searchModel = r;
                delete $ctrl.searchModel.results;
            });
        }

        $ctrl.paged = function () {
            $ctrl.search(tableStateRef);
        }

        $ctrl.create = function () {
            $modal.open({
                component: 'productEdit',
                bindings: {
                    modalInstance: "<"
                },
                size: 'md'
            }).result.then(function (result) {
                $ctrl.products.unshift(result);
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }

        $ctrl.edit = function(item) {
            $modal.open({
                component: 'productEdit',
                bindings: {
                    modalInstance: "<"
                },
                resolve: {
                    id: item.id
                },
                size: 'md'
            }).result.then(function (result) {
                angular.extend(item, result);
            }, function (reason) {
            });
        }

        $ctrl.delete = function (item) {

            console.log('delete', item);
            product.remove(item.id).then(function(r) {
                var idx = $ctrl.products.indexOf(item);
                $ctrl.products.splice(idx, 1);
            });
        }   
        
        $ctrl.showDetails = function (item) {
            $modal.open({
                component: 'productSummary',
                bindings: {
                    modalInstance: "<"
                },
                resolve: {
                    id: item.id,
                    asModal: true
                },
                size: 'md'
            }).result.then(function (result) {
                console.info("I was closed, so do what I need to do myContent's controller now.  Result was->");
                angular.extend(item, result);
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }
    }

    module.component('productList',
        {
            templateUrl: 'app/product/product-list.component.html',
            controller: ['$uibModal', 'Product', 'User', controller]
        });

}
)();