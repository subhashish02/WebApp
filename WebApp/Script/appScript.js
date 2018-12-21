/// <reference path="angular.min.js" />
/// <reference path="angular-route.min.js" />

var app = angular.module("myModule", ['ngRoute']);

app.controller("myController", function ($scope, $http, $log, $route) {

    $http
        ({
            method: 'GET',
            url: 'http://localhost/WebApp/api/Student'
        }).then(function successCallback(response) {

            $scope.students = response.data;
            $log.info(response);
        },
            function errorCallback(response) {
                alert("No Response To GET");
            });

    $scope.selectedStudent = {};

    $scope.create = function () {
        debugger;
        $http({
            method: 'POST',
            url: 'http://localhost/WebApp/api/Student',
            data: $scope.selectedStudent
        }).then(function successCallback(response) {
           
            alert("Created");
           
        }, function errorCallback(response) {
            alert("No Response To POST");
        });


    }

});

app.config(function ($routeProvider) {
    debugger;
    $routeProvider
        .when('/view1',
            {
                controller: '',
                templateUrl: 'View1.html'
            })
        .otherwise({ redirectTo: '/view1' });
});