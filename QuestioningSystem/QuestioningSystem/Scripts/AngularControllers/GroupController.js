var app = angular.module('MyApp');
var controller = app.controller('GroupController', function ($scope, GroupCreationService, GetAllDataService, $window) {
    $scope.titleOfGroup = '';
    $scope.Message1 = '';
    $scope.Message2 = '';
    $scope.maxNumberOfMembers = '';
    $scope.awesomeData;
    $scope.$watch('f3.$valid', function (newVal) {
        $scope.IsFormValid = newVal;
    });

    $scope.CreateGroup = function () {
        var groupData = {
            Title: $scope.titleOfGroup,
            MaxNumberOfMembers: $scope.maxNumberOfMembers
        };
        GroupCreationService.CreateGroup(groupData).then(function (d) {
            if (d.data.ID != undefined) {
                $scope.Message = "Group successfully saved."
            }
            else
                $scope.Message = "Group could not be saved."
        });
    };
    
    $scope.GetAllData = function () {
        GetAllDataService.GetGroupData().then(function (d) {
            $scope.awesomeData = successData;
        });
    };
    
})
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

controller.factory('GetAllDataService', function ($http) {
    var fac = {};
    fac.GetGroupData = function (d) {
        return $http({
            url: '/Group/GetAllData',
            method: 'Get'
        });
    };
    return fac;
});