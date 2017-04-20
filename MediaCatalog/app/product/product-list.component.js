//product-list.component.js
(function () {
    'use strict';

    var module = angular.module('app');

    function controller($modal, $ngConfirm, toastr, product) {
        var $ctrl = this;
        var pageSizeDefault = 10;
        var tableStateRef;

        $ctrl.searchModel = {
            page: 1,
            pageSize: pageSizeDefault, 
            filteredCount: 0, 
            totalCount: 0, 
            totalPages: 0
        };

        $ctrl.$onInit = function () {
            console.log('product list init');
            $ctrl.title = 'Media Library';
            $ctrl.loading = true;
        }

        $ctrl.search = function (tableState) {
            $ctrl.loading = true;
            tableStateRef = tableState;
            product.getAllProducts($ctrl.searchModel).then(function (r) {
                $ctrl.products = r.results;
                $ctrl.searchModel = r;
                delete $ctrl.searchModel.results;
                $ctrl.loading = false;
            }).catch(function (err) {
                $ctrl.loading = false;
            }).finally(function () {
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
                toastr.info('Created ' + result.title);
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }

        $ctrl.edit = function (item) {
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
                toastr.info('Saved ' + result.title);
            }, function (reason) {
            });
        }

        $ctrl.delete = function (item) {
            $ngConfirm({
                title: 'Delete',
                content: 'Are you sure you want to delete <br /><strong>' + item.title + '</strong>?',
                type: 'red',
                buttons: {
                    yes: {
                        keys: ['y'],
                        action: function (scope, button) {
                            product.remove(item.id).then(function (r) {
                                var idx = $ctrl.products.indexOf(item);
                                $ctrl.products.splice(idx, 1);
                                toastr.warning('Deleted ' + item.title);
                            });
                        }
                    },
                    no: {
                        keys: ['N'],
                        action: function (scope, button) {
                        }
                    }
                }
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
            controller: ['$uibModal', '$ngConfirm', 'toastr', 'Product', controller]
        });

}
)();