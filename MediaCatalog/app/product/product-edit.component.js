//product-edit.component.js
(function () {
    var module = angular.module('app');

    function controller(service) {
        var $ctrl = this;

        $ctrl.dateOptions = {
            dateDisabled: false,
            formatYear: 'yy'
        };
        $ctrl.dateFormat = "MM/DD/YYYY";

        $ctrl.$onInit = function () {
            $ctrl.title = 'New Media';
            if ($ctrl.resolve) {
                $ctrl.id = $ctrl.resolve.id;
            }
            if ($ctrl.id) {
                service.getProduct($ctrl.id).then(function (r) {
                    $ctrl.product = r;
                    $ctrl.title = r.title;
                    $ctrl.product.receiptDate = new Date(r.receiptDate);
                });
            }
        }

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        }

        $ctrl.save = function () {
            if ($ctrl.product.category === '') $ctrl.product.category = null;
            return service.save($ctrl.product).then(function (r) {
                angular.extend($ctrl.product, r);
                $ctrl.modalInstance.close($ctrl.product);
            }).catch(function (err) {
                console.log('Error saving product', err.message);
            }).finally(function () {
            });
        }

        $ctrl.publisherChanged = function () {
            console.log('publisher changed');
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
            controller: ['Product', controller]
        });
})();
