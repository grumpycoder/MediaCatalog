//media-list.component.js
(function () {
    'use strict';

    var module = angular.module('media');

    function controller(service) {
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

        $ctrl.paged = function() {
            $ctrl.search(tableStateRef);
        }
    }

    module.component('list',
    {
        templateUrl: 'app/media/media-list.component.html',
        controller: ['MediaService', controller]
    });


    //module.directive('stSubmitSearch', ['stConfig', '$timeout', '$parse', function (stConfig, $timeout, $parse) {
    //    return {
    //        require: '^stTable',
    //        link: function (scope, element, attr, ctrl) {
    //            return element.bind('click',
    //                function () {
    //                    var tableCtrl = ctrl;
    //                    tableCtrl.pipe();
    //                });

    //        }
    //    };
    //}]);

}
)();