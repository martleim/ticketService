(function () {

    var TicketEditController = function ($rootScope, $scope, $routeParams, dataService, modalService, validationService) {

        var id = ($routeParams.id) ? $routeParams.id : "",
            timer,
            onRouteChangeOff;

        $scope.validationLoaded = false;
        $scope.formconfig = false;
        

        $scope.edit = (id && id != "");
        $scope.title = ($scope.edit) ? "Edit" : "Add";
        $scope.buttonText = ($scope.edit) ? "Save" : "Add";
        $scope.updateStatus = false;
        $scope.errorMessage = "";

        init();

        $scope.save = function () {
            var ticketToSave = angular.copy($scope.model);
            $scope.$close(ticketToSave);
            
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
            $scope.model = {
                Id:null
            };
            /*dataService.eventsService.getTicket(id).then(function (ret) {

                if (id != "") {
                    $scope.model = angular.copy(ret.data.result);
                }

            });*/

            validationService.getValidation("Ticket", "model").then(function (ret) {
                $scope.validationLoaded = true;
                $scope.formconfig = ret.data;
            });
            
        }
        
        $scope.navigate = function (url) {
            $location.path(url);
        };

        $scope.addTicket = function () {
            $scope.openEditTicketModal();
        };

        

    };

    TicketEditController.$inject = ["$rootScope", "$scope", "$routeParams",
                                       "dataService", "modalService", "validationService"];

    angular.module("ticketsApp").controller("TicketEditController", TicketEditController);

}());