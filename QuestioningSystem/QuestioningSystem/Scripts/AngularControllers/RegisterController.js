﻿angular.module('MyApp')
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
    $scope.Success = false;
    $scope.showSuccessAlert = false;
    $scope.showFailureAlert = false;
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
                if (d.data) {
                    $window.location = '/Account/Confirm';
                    $scope.Message = "Successfully logged in. Welcome";
                    $scope.Success = true;
                }
                else {
                    $scope.Message = "Please fill in all required fields to complete registration."
                    $scope.showSuccessAlert(false);
                    $scope.Success = false;
                }
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