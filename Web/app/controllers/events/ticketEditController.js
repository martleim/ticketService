(function () {

    var TicketEditController = function ($rootScope, $scope, $routeParams, $timeout, dataService, modalService, validationService) {

        var id = ($routeParams.id) ? $routeParams.id : "",
            timer,
            onRouteChangeOff;

        $scope.validationLoaded = false;
        $scope.formconfig = false;
        validationService.getValidation("Ticket", "model").then(function (ret) {
            $scope.validationLoaded = true;
            $scope.formconfig = ret.data;
        });

        $scope.edit = (id && id != "");
        $scope.title = ($scope.edit) ? "Edit" : "Add";
        $scope.buttonText = ($scope.edit) ? "Save" : "Add";
        $scope.updateStatus = false;
        $scope.errorMessage = "";

        init();

        $scope.save = function () {
            var ticketToSave = angular.copy($scope.model);
            $scope.$close(ticketToSave);
            processSuccess();
        };

        $scope.delete = function () {
            var name = $scope.model.name;

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete Ticket',
                headerText: 'Delete ' + name + '?',
                bodyText: 'Are you sure you would like to delete this  Ticket?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    dataService.eventsService.deleteTicket(name);
                    $scope.updateTickets();
                }
            });
        };

        function init() {
            $scope.model = {};
			dataService.eventsService.getTicket(id).then(function(ret){
				
				if (id != "") {
					$scope.model = angular.copy(ret.data.result);
				}
				
			})
            
        }
        
        $scope.navigate = function (url) {
            $location.path(url);
        };

        $scope.addTicket = function () {
            $scope.openEditTicketModal();
        };

        function processSuccess() {
//            $scope.editForm.$dirty = false;
            $scope.updateStatus = true;
            $scope.title = "Editar";
            $scope.buttonText = "Guardar";
            $scope.edit=true;
            startTimer();
        }

        function startTimer() {
            timer = $timeout(function () {
                $timeout.cancel(timer);
                $scope.errorMessage = '';
                $scope.updateStatus = false;
                
            }, 1000);
        }

    };

    TicketEditController.$inject = ["$rootScope", "$scope", "$routeParams",
                                      "$timeout", "dataService", "modalService", "validationService"];

    angular.module("ticketsApp").controller("TicketEditController", TicketEditController);

}());