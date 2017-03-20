//publisher-list.component.js
(function () {

    var module = angular.module('shared.components');

    function controller($http, $uibModal) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            $http.get('api/publisher').then(function (r) {
                $ctrl.publishers = r.data;
            }).catch(function (err) {
                console.log(err.message);
            });
        }

        $ctrl.create = function () {
            $uibModal.open({
                component: 'publisherEdit',
                bindings: {
                    modalInstance: "<"
                },
                size: 'lg'
            }).result.then(function (result) {
                console.info("I was closed, so do what I need to do myContent's controller now.  Result was->");
                console.info('returning result', result);
                $ctrl.publishers.unshift(result);
                $ctrl.id = result.id;
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }

        $ctrl.edit = function () {

            $uibModal.open({
                component: 'publisherEdit',
                bindings: {
                    modalInstance: "<"
                },
                resolve: {
                    id: $ctrl.id
                },
                size: 'lg'
            }).result.then(function (result) {
                angular.forEach($ctrl.publishers, function (item) {
                    if (item.id === $ctrl.id) {
                        angular.extend(item, result);
                        $ctrl.id = item.id;
                    }
                });

            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }
    }

    module.component('publisherSelect',
    {
        bindings: {
            id: '='
        },
        templateUrl: 'app/common/publisher-select.component.html',
        controller: ['$http', '$uibModal', controller]
    });


}
)();