(function () {

	
    var app = angular.module("ticketsApp", ["ngRoute", "ui.bootstrap", "aa.formExtensions", "aa.formExternalConfiguration", 'aa.notify', 'ui.bootstrap.datetimepicker'])
    .constant("appConfig", appConfig)
    .config(function ($routeProvider, appConfig) {
        var viewBase = appConfig.views;
		
        $routeProvider
			.when("/events", {
                controller: "EventsController",
                templateUrl: viewBase + "events/events.html"
            })
			.when("/tickets", {
                controller: "TicketsController",
                templateUrl: viewBase + "tickets/tickets.html"
            })
			.otherwise({ redirectTo: "/events" });

    })
	.controller("navBarController", function($scope, $location){
		$scope.isActive = function (viewLocation) { 
			return viewLocation === $location.path();
		};
	})
	.run(
    function ($rootScope, $location) {

        $rootScope.$on("serviceError", function (event, next, current) {
            alert(next.message);
        });

    });

}());

