//publisher-edit.component.js
(function () {
    var module = angular.module('app');

    function controller($http) {
        var $ctrl = this;

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        }

        $ctrl.save = function () {
            return $http.post('api/publisher', $ctrl.publisher).then(function (r) {
                angular.extend($ctrl.publisher, r.data);
            }).catch(function (err) {
                console.log('Error saving publisher', err.message);
            }).finally(function () {
                console.log('edit publisher', $ctrl.publisher);
                $ctrl.modalInstance.close($ctrl.publisher);
            });
        }

    }

    module.component('publisherEdit',
    {
        bindings: {
            resolve: '<',
            close: '&',
            dismiss: '&',
            modalInstance: '<'
        },
        templateUrl: 'app/publisher/publisher-edit.component.html',
        controller: ['$http', controller]
    });

}
)();