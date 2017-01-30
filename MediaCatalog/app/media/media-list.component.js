//media-list.component.js
(function () {
    'use strict';

    var module = angular.module('media');

    function controller($uibModal, service) {
        var $ctrl = this;
        var pageSizeDefault = 10;
        var tableStateRef;

        $ctrl.searchModel = {
            page: 1,
            pageSize: pageSizeDefault
        };

        $ctrl.$onInit = function () {
        }

        $ctrl.search = function (tableState) {
            tableStateRef = tableState;

            service.getAllMedia($ctrl.searchModel).then(function (r) {
                $ctrl.media = r.results;
                $ctrl.searchModel = r;
                delete $ctrl.searchModel.results;
            });
        }

        $ctrl.paged = function () {
            $ctrl.search(tableStateRef);
        }

        $ctrl.showDetails = function (id) {
            $uibModal.open({
                component: 'mediaSummary',
                bindings: {
                    modalInstance: "<"
                },
                resolve: {
                    id: id,
                    asModal: true
                },
                size: 'lg'
            }).result.then(function (result) {
                console.info("I was closed, so do what I need to do myContent's controller now.  Result was->");
                console.info(result);
            }, function (reason) {
                console.info("I was dimissed, so do what I need to do myContent's controller now.  Reason was->" + reason);
            });
        }
    }

    module.component('list',
    {
        templateUrl: 'app/media/media-list.component.html',
        controller: ['$uibModal', 'MediaService', controller]
    });

}
)();