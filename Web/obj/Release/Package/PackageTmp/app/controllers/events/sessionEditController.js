(function () {

    var SessionEditController = function ($rootScope, $scope, $routeParams, dataService, modalService, validationService) {

        var id = ($routeParams.id) ? $routeParams.id : "";

        $scope.validationLoaded = false;
        $scope.formconfig = false;

        $scope.EventTickets = $scope.$parent.modalOptions.tickets;
        $scope.edit = (id && id != "");
        $scope.title = ($scope.edit) ? "Edit" : "Add";
        $scope.buttonText = ($scope.edit) ? "Save" : "Add";
        $scope.updateStatus = false;
        $scope.errorMessage = "";

        var eventId = $scope.$parent.modalOptions.eventId;

        init();

        $scope.save = function () {
            var sessionToSave = angular.copy($scope.model);
            sessionToSave.Ticket = [];
            function getTicketById(id) {
                for (var i = 0; i < $scope.EventTickets.length; i++) {
                    if ($scope.EventTickets[i].Id == id) {
                        return angular.copy($scope.EventTickets[i]);
                    }
                }
            }
            for (var i = 0; i < sessionToSave.TicketIds.length; i++) {
                var ticket = getTicketById(sessionToSave.TicketIds[i]);
                if(ticket)
                    sessionToSave.Ticket.push(ticket);
            }
            $scope.$close(sessionToSave);
            
            
        };

        $scope.delete = function () {
            var name = $scope.model.name;

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete Session',
                headerText: 'Delete ' + name + '?',
                bodyText: 'Are you sure you would like to delete this  Session?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    dataService.eventsService.deleteSession(name);
                    $scope.updateSessions();
                }
            });
        };

        function init() {
            $scope.model = {
                DateStart: new Date(),
                DateEnd: new Date(),
                EventId: eventId
            };
            /*dataService.eventsService.getSession(id).then(function (ret) {
                if (id != "") {
                    $scope.model = angular.copy(ret.data.result);
                }
            });
            */
            validationService.getValidation("Session", "model").then(function (ret) {
                $scope.formconfig = ret.data;
                $scope.validationLoaded = true;
            });

            
        }
        
        $scope.navigate = function (url) {
            $location.path(url);
        };

        $scope.addSession = function () {
            $scope.openEditSessionModal();
        };



    };

    SessionEditController.$inject = ["$rootScope", "$scope", "$routeParams",
                                       "dataService", "modalService", "validationService"];

    angular.module("ticketsApp").controller("SessionEditController", SessionEditController);

}());