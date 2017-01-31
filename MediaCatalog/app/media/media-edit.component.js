//media-edit.component.js
(function () {
    var module = angular.module('media');

    function controller(service) {
        var $ctrl = this;

        $ctrl.$onInit = function () {
            if ($ctrl.resolve) {
                $ctrl.id = $ctrl.resolve.id;
            }
            service.getMedia($ctrl.id).then(function(r) {
                $ctrl.media = r; 
            });
            console.log('media edit active', $ctrl);
        }

        $ctrl.cancel = function()
        {
            $ctrl.dismiss();
        }

        $ctrl.save = function () {
            service.save($ctrl.media).then(function(r) {
                angular.extend($ctrl.media, r);
            }).catch(function(err) {

            });
            this.modalInstance.close($ctrl.media);
        }

    }

    module.component('mediaEdit',
    {
        templateUrl: 'app/media/media-edit.component.html',
        bindings: {
            id: '<',
            resolve: '<',
            close: '&',
            dismiss: '&',
            modalInstance: '<'
        },
        controller: ['MediaService', controller]
    });
})();
