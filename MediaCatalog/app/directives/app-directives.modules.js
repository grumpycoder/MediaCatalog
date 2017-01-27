//app-directives.modules.js
(function() {

    angular.module('app.directives', []).directive('stSubmitSearch', ['stConfig', '$timeout', '$parse', function (stConfig, $timeout, $parse) {
        return {
            require: '^stTable',
            link: function (scope, element, attr, ctrl) {
                return element.bind('click',
                    function () {
                        var tableCtrl = ctrl;
                        tableCtrl.pipe();
                    });

            }
        };
    }]);


})();