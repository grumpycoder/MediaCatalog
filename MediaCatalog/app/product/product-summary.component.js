//product-summary.component.js
(function () {
    var module = angular.module('app');

    function controller(service) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            console.log('summary active');
            if ($ctrl.resolve) {
                $ctrl.id = $ctrl.resolve.id;
                $ctrl.asModal = $ctrl.resolve.asModal;
                $ctrl.addStaffVisible = false;
            }

            service.getMedia($ctrl.id).then(function (r) {
                $ctrl.media = r;
            });
        }

        $ctrl.createStaff = function() {
            console.log('add staff modal');
        }

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        };
    }

    module.component('mediaSummary',
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