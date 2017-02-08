//product-edit.component.js
(function () {
    var module = angular.module('app');

    function controller(service) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            if ($ctrl.resolve) {
                $ctrl.id = $ctrl.resolve.id;
            }
            if ($ctrl.id) {
                service.getProduct($ctrl.id).then(function (r) {
                    $ctrl.product = r;
                });
            }
        }

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        }

        $ctrl.save = function () {
            return service.save($ctrl.product).then(function (r) {
                angular.extend($ctrl.product, r);
            }).catch(function (err) {
                console.log('Error saving product', err.message);
            }).finally(function () {
                $ctrl.modalInstance.close($ctrl.product);
            });
        }

    }

    module.component('productEdit',
    {
        templateUrl: 'app/product/product-edit.component.html',
        bindings: {
            id: '<',
            resolve: '<',
            close: '&',
            dismiss: '&',
            modalInstance: '<'
        },
        controller: ['ProductService', controller]
    });
})();
    