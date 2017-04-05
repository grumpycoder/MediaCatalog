//staff-edit.component.js
(function () {
    var module = angular.module('app');

    function controller($http) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            console.log('staff edit init');
            $ctrl.title = 'New Staff';

            if ($ctrl.resolve) $ctrl.productId = $ctrl.resolve.productId;

            if ($ctrl.resolve.staff) {
                $ctrl.staff = $ctrl.resolve.staff;
                $ctrl.title = $ctrl.staff.firstname + ' ' + $ctrl.staff.lastname;
            }
        }

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        };

        $ctrl.save = function () {
            if ($ctrl.productId) {
                $http.post('api/staff/' + $ctrl.productId, $ctrl.staff).then(function (r) {
                    angular.extend($ctrl.staff, r.data);
                    $ctrl.modalInstance.close(r.data);
                }).catch(function (err) {
                    console.log('something went wrong', err.message);
                });
            } else {
                $http.post('api/staff', $ctrl.staff).then(function (r) {
                    angular.extend($ctrl.staff, r.data);
                    $ctrl.modalInstance.close(r.data);
                }).catch(function (err) {
                    console.log('something went wrong', err.message);
                });
            }
        };
    }

    module.component('staffEdit',
        {
            bindings: {
                resolve: '<',
                close: '&',
                dismiss: '&',
                staff: '<',
                productId: '<',
                modalInstance: '<'
            },
            templateUrl: 'app/staff/staff-edit.component.html',
            controller: ['$http', controller]
        });
}
)();