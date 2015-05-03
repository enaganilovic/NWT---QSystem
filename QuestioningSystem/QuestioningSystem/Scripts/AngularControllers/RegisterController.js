angular.module('MyApp')
.controller('RegisterController', function ($scope, RegistrationService, $window) {
    $scope.UserName = '';
    $scope.Password= '';
    $scope.Email = '';
    $scope.ConfirmedPassword = '';
    $scope.FirstName = '';
    $scope.LastName = '';
    $scope.PhoneNumber = '';
    $scope.Age = 0;
    $scope.Submitted = false;
    $scope.Message = '';
    $scope.$watch('f2.$valid', function(newVal) {
        $scope.IsFormValid = newVal;
    });
    $scope.Register = function () {
        var RegistrationData = {
            UserName: $scope.UserName,
            Password: $scope.Password,
            ConfirmPassword: $scope.ConfirmedPassword,
            Email: $scope.Email,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            PhoneNumber: $scope.PhoneNumber,
            Age: $scope.Age
        };
        $scope.Submitted = true;
        RegistrationService.GetUser(RegistrationData).then(function (d) {

            $window.location = '/Account/Confirm';
            $scope.Message = "Successfully logged in. Welcome";
    
    });

    };
})
.factory('RegistrationService', function ($http) {
    var fac = {};
    fac.GetUser = function (d) {
        return $http({
            url: '/Account/Register',
            method: 'POST',
            data: JSON.stringify(d)
        });
    };
    return fac;
});