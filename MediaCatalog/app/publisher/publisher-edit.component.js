//publisher-edit.component.js
(function () {
    var module = angular.module('app');

    function controller($http) {
        var $ctrl = this;

        $ctrl.$onInit = function() {
            if ($ctrl.resolve) {
                $ctrl.id = $ctrl.resolve.id;
            }
            if ($ctrl.id) {
                $http.get('api/publisher/' + $ctrl.id).then(function(r) {
                    $ctrl.publisher = r.data; 
                }).catch(function(err) {
                    console.log('Error retriving publisher', err.message);
                }).finally(function() {

                });
            }
            console.log('$ctrl', $ctrl);
            

        }

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
            id: '<', 
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