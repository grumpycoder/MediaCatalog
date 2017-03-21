﻿//staff-list.component.js
(function () {
    var module = angular.module('app');

    function controller($http, $modal) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            console.log('staff list init');
        }

        $ctrl.edit = function(member) {
            $modal.open({
                component: 'staffEdit',
                bindings: {
                    modalInstance: "<", 
                    staff: member
                },
                resolve: {
                    staff: member
                },
                size: 'md'
            }).result.then(function (result) {
                console.info("I was closed, so do what I need to do myContent's controller now.  Result was->");
                
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }

        $ctrl.delete = function(member) {
            $http.delete('api/staff/' + member.id).then(function(r) {
                var idx = $ctrl.staff.indexOf(member);
                $ctrl.staff.splice(idx, 1);
            }).catch(function(err) {
                console.log('error', err.message);
            });

        }
    }

    module.component('staffList',
        {
            bindings: {
                staff: '<'
            },
            templateUrl: 'app/staff/staff-list.component.html',
            controller: ['$http', '$uibModal', controller]
        });
}
)();