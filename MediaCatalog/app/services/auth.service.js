//auth.service.js
(function () {
    var module = angular.module('app');

    function service($http, $localStorage) {
        return {
            getToken: getToken
        }

        function getToken() {
            if ($localStorage.currentUser) {
                var currentUser = $localStorage.currentUser;
                $http.post('api/auth/authenticate?user=' +
                    currentUser.user +
                    '&password=' +
                    currentUser.password).then(function (r) {
                        currentUser.token = r.data;
                        $localStorage.currentUser = currentUser;
                    }).catch(function (err) {
                    });
            }
        }
    }

    module.service('User', ['$http', '$localStorage', service]);
}
)();