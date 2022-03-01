var app = angular.module('myApp', ['uiMapgoogle-maps']);
app.controller('IncidentsController', function ($scope, $http) {
    //this is for default map focus when load first time
    $scope.map = { center: { latitude: 22.590406, longitude: 88.366034 }, zoom: 15 }
    $scope.markers = [];
    $scope.locations = [];

    //populate all location
    $http.get('Incidents/GetAllLocation').then(function (data) {
        $scope.locations = data.data;
    }, function () {
        alert('Error');
    });
    //get marker info
    $scope.ShowLocation = function (IdMap) {
        $http.get('Incidents/GetMarkerInfo', {
            params: {
                IdMap: IdMap
            }
        }).then(function (data) {
            //clear markers
            $scope.markers = [];
            $scope.markers.push({
                id: data.data.IdMap,
                coords: { latitude: data.data.Lat, longitude: data.data.Long },
                address: data.data.Address
            });
            //set map focus center
            $scope.map.center.latitude = data.data.Lat;
            $scope.map.center.longitude = data.data.Long;
        }, function () {
            alert('Error');
        });
    }
    //show hide marker on map
    $scope.windowOptions = {
        show=true
    };
});