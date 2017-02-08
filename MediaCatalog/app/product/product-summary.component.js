//product-summary.component.js
(function () {
    var module = angular.module('app');

    function controller(service) {
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

        $ctrl.createStaff = function() {
            console.log('add staff modal');
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
        controller: ['ProductService', controller]
    });

}
)();