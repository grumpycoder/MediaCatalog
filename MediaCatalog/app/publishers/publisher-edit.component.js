//publisher-edit.component.js
(function () {
    var module = angular.module('app');

    function parseErrors(response) {
        var errors = [];
        var key;

        for (key in response.modelState) {
            if (response.modelState.hasOwnProperty(key)) {
                for (var i = 0; i < response.modelState[key].length; i++) {
                    errors.push(response.modelState[key][i]);
                }
            }
        }
        return errors;
    }

    function controller(service, toastr, $http) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            console.log('publisher edit init', $ctrl);
            $ctrl.title = 'New Publisher';
            $ctrl.publisher = {};

            if ($ctrl.resolve) {
                $ctrl.id = $ctrl.resolve.id;
            }
            if ($ctrl.id) {
                service.get($ctrl.id).then(function (r) {
                    $ctrl.publisher = r;
                    $ctrl.title = r.name;
                });
            }
        }

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        }

        $ctrl.save = function () {
            
            if ($ctrl.publisher.id) {
                $http.put('api/publisher', $ctrl.publisher).then(function (r) {
                    angular.extend($ctrl.publisher, r.data);
                    toastr.success('Saved Publisher ', $ctrl.publisher.name);
                    $ctrl.modalInstance.close($ctrl.publisher);
                }).catch(function (err) {
                    console.log('Oops. Something went wrong', err);
                    toastr.error('Oops. Something happened: ' + err.data.message);
                    $ctrl.errors = parseErrors(err.data);
                });
            } else {
                $http.post('api/publisher', $ctrl.publisher).then(function (r) {
                    angular.extend($ctrl.publisher, r.data);
                    toastr.success('Saved ', $ctrl.publisher.name);
                    $ctrl.modalInstance.close($ctrl.publisher);
                }).catch(function (err) {
                    console.log('Oops. Something went wrong', err);
                    toastr.error('Oops. Something happened: ' + err.data.message);
                    $ctrl.errors = parseErrors(err.data);
                });
            }

        }

    };

    module.component('publisherEdit',
        {
            bindings: {
                id: '<',
                resolve: '<',
                close: '&',
                dismiss: '&',
                modalInstance: '<'
            },
            templateUrl: 'app/publishers/publisher-edit.component.html',
            controller: ['Publisher', 'toastr', '$http', controller]
        });

}
)();