//confrmation-modal.component.js
(function () {
    var module = angular.module('app');

    function controller() {
        var $ctrl = this; 

        $ctrl.$onInit = function() {
            console.log('modal', $ctrl);
        }

    }

    module.component('confirmationModal',
        {
            bindings: {
            },
            template: 'yes or no',
            controller: [controller]
        });
}
)();