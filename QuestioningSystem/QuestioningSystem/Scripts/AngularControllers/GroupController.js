var app = angular.module('MyApp');
var controller = app.controller('GroupController', function ($scope, GroupCreationService, CheckUserService, $window) {
    $scope.titleOfGroup = '';
    $scope.Message1 = '';
    $scope.Message2 = '';
    $scope.maxNumberOfMembers = '';
    $scope.awesomeData;
    $scope.addUser;
    $scope.Submitted = false;
    $scope.userValid = false;
    $scope.$watch('f3.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });
    $scope.Clear = function () {
        $scope.titleOfGroup = '';
        $scope.Message1 = '';
        $scope.Message2 = '';
        $scope.maxNumberOfMembers = 0;
        $scope.addUser = '';
        $scope.userValid = false;
        $scope.Saved = false;
    };
    $scope.CreateGroup = function () {
        $scope.Message = '';
        var groupData = {
            Title: $scope.titleOfGroup,
            MaxNumberOfMembers: $scope.maxNumberOfMembers,
            GroupMember: $scope.addUser
        };
        $scope.Submitted = true;
        GroupCreationService.CreateGroup(groupData).then(function (d) {
            if (d.data.ID != undefined) {
                $scope.Message = "Group successfully saved."
                $scope.Saved = true;
            }
            else {
                $scope.Message = "Group could not be saved."
                $scope.Saved = false;
            }
        });
    };

    $scope.CheckUser = function () {
        var userData = {
            UserName: $scope.addUser
        };
        CheckUserService.CheckUser(userData).then(function (d) {
            if (d.data != undefined && !d.data) {
                $scope.Message = "User could not be found!";
                $scope.userValid = false;
            }
            else {
                $scope.Message = "User " + $scope.addUser + " will be added in this group on submit.";
                $scope.userValid = true;
            }
        });
    };
});
controller.factory('GroupCreationService', function ($http) {
    var fac = {};
    fac.CreateGroup = function (d) {
        return $http({
            url: '/Group/SaveGroup',
            method: 'POST',
            data: JSON.stringify(d)
        });
    };
    return fac;
});

controller.factory('CheckUserService', function ($http) {
    var fac = {};
    fac.CheckUser = function (d) {
        return $http({
            url: '/Group/CheckUser',
            method: 'POST',
            data: d
        });
    };
    return fac;
});