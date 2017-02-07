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
                service.getMedia($ctrl.id).then(function (r) {
                    $ctrl.media = r;
                });
            }
            console.log('media edit active', $ctrl);
        }

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        }

        $ctrl.save = function () {
            return service.save($ctrl.media).then(function (r) {
                angular.extend($ctrl.media, r);
            }).catch(function (err) {
                console.log('Error saving product', err.message);
            }).finally(function () {
                $ctrl.modalInstance.close($ctrl.media);
            });
        }

    }

    module.component('mediaEdit',
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
    