//media-summary.component.js
(function () {
    var module = angular.module('media');

    function controller(service) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            console.log('summary active');
            if ($ctrl.resolve) {
                $ctrl.id = $ctrl.resolve.id;
                $ctrl.asModal = $ctrl.resolve.asModal;
            }

            service.getMedia($ctrl.id).then(function (r) {
                $ctrl.media = r;
            });
        }

        $ctrl.cancel = function () {
            $ctrl.dismiss();
        };
    }

    module.component('mediaSummary',
    {
        bindings: {
            id: '<',
            asModal: '<',
            resolve: '<',
            close: '&',
            dismiss: '&'
        },
        templateUrl: 'app/media/media-summary.component.html',
        controller: ['MediaService', controller]
    });

}
)();