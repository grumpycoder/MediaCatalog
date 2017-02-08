//product-list.component.js
(function () {
    'use strict';

    var module = angular.module('app');

    function controller($uibModal, service) {
        var $ctrl = this;
        var pageSizeDefault = 10;
        var tableStateRef;

        $ctrl.searchModel = {
            page: 1,
            pageSize: pageSizeDefault
        };

        $ctrl.$onInit = function () {}

        $ctrl.search = function (tableState) {
            tableStateRef = tableState;

            service.getAllProducts($ctrl.searchModel).then(function (r) {
                $ctrl.products = r.results;
                $ctrl.searchModel = r;
                delete $ctrl.searchModel.results;
            });
        }

        $ctrl.paged = function () {
            $ctrl.search(tableStateRef);
        }

        $ctrl.edit = function(item) {
            $uibModal.open({
                component: 'productEdit',
                bindings: {
                    modalInstance: "<"
                },
                resolve: {
                    id: item.id
                },
                size: 'lg'
            }).result.then(function (result) {
                angular.extend(item, result);
            }, function (reason) {
            });
        }

        $ctrl.create = function () {
            $uibModal.open({
                component: 'productEdit',
                bindings: {
                    modalInstance: "<"
                },
                size: 'lg'
            }).result.then(function (result) {
                $ctrl.products.unshift(result);
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }

        $ctrl.showDetails = function (id) {
            $uibModal.open({
                component: 'productSummary',
                bindings: {
                    modalInstance: "<"
                },
                resolve: {
                    id: id,
                    asModal: true
                },
                size: 'lg'
            }).result.then(function (result) {
                console.info("I was closed, so do what I need to do myContent's controller now.  Result was->");
                console.info(result);
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }

    }

    module.component('list',
    {
        templateUrl: 'app/product/product-list.component.html',
        controller: ['$uibModal', 'ProductService', controller]
    });

}
)();