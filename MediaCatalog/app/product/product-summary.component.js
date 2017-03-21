﻿//product-summary.component.js
(function () {
    var module = angular.module('app');

    function controller($modal, service) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            if ($ctrl.resolve) {
                $ctrl.id = $ctrl.resolve.id;
                $ctrl.asModal = $ctrl.resolve.asModal;
                $ctrl.addStaffVisible = false;
            }

            service.getProduct($ctrl.id).then(function (r) {
                $ctrl.product = r;
            });
        }

        $ctrl.showNewStaff = function() {
            $modal.open({
                component: 'staffEdit',
                bindings: {
                    modalInstance: "<"
                },
                resolve: {
                    productId: $ctrl.id
                },
                size: 'md'
            }).result.then(function (result) {
                console.info("I was closed, so do what I need to do myContent's controller now.  Result was->");
                $ctrl.product.staff.unshift(result);
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        };
    }

    module.component('productSummary',
    {
        bindings: {
            id: '<',
            asModal: '<',
            resolve: '<',
            close: '&',
            dismiss: '&'
        },
        templateUrl: 'app/product/product-summary.component.html',
        controller: ['$uibModal', 'Product', controller]
    });

}
)();