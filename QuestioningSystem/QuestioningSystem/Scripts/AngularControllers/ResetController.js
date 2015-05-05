angular.module('MyApp')
.controller('ResetController', function ($scope, ResetService, $window) {
    $scope.Password = '';
    $scope.NewPassword = '';
    $scope.ConfirmedPassword = '';
    $scope.Submitted = false;
    $scope.Message = '';
    $scope.$watch('f4.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });
    $scope.Reset = function () {
        var ResetData = {
            Password: $scope.Password,
            NewPassword: $scope.NewPassword,
            ConfirmPassword: $scope.ConfirmedPassword
        };
        $scope.Submitted = true;
        ResetService.GetUser(ResetData).then(function (d) {
            if (d.data) {
                $window.location = '/Account/ChangePasswordPartial';
                $scope.Message = "Successfully logged in. Welcome";
            }
            else
                $scope.Message = "Please fill in all required fields to complete registration."
        });

    };
})
.factory('ResetService', function ($http) {
    var fac = {};
    fac.GetUser = function (d) {
        return $http({
            url: '/Account/Manage',
            method: 'POST',
            data: JSON.stringify(d)
        });
    };
    return fac;
});