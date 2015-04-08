angular.module('MyApp')
.controller('LoginController', function ($scope, LoginService, $window) {
    $scope.IsLoggedIn = false;
    $scope.Message = '';
    $scope.Submitted = false;
    $scope.IsFormValid = false;
    $scope.UserName = '';
    $scope.Password = '';
    $scope.$watch('f1.$valid', function(newVal) {
        $scope.IsFormValid = newVal;
    });

    $scope.Login = function () {
        var LoginData = {
            UserName: $scope.UserName,
            Password: $scope.Password,
            RememberMe: false
        };
        $scope.Submitted = true;
        LoginService.GetUser(LoginData).then(function (d) {
           if (d.data.Id != undefined) {
                $scope.IsLoggedIn = true;
                $window.location = '/Home/Index';
                $scope.Message = "Successfully logged in. Welcome";
            }
            else
                alert("Invalid credentials");
                    });

    };
})
.factory('LoginService', function ($http) {
    var fac = {};
    fac.GetUser = function (d) {
            return $http({
                url: '/Account/Login',
                method: 'POST',
                data: JSON.stringify(d)
            });
    };
    return fac;
});