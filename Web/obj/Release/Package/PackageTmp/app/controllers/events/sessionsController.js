(function () {

    var SessionController = function ($rootScope, $scope, $routeParams, dataService, modalService, validationService, appConfig) {

        var id = ($scope.$parent.modalOptions.eventId) || ""

        var views = appConfig.views + "events/";
        $scope.title = ($scope.edit) ? "Edit" : "Add";
        $scope.buttonText = ($scope.edit) ? "Save" : "Add";
        $scope.updateStatus = false;
        $scope.sessionsLoaded = false;
        $scope.ticketsLoaded = false;

        init();

        $scope.save = function () {
            var sessionToSave = angular.copy($scope.model);

            if (!this.edit) {
                dataService.eventsService.insertSession(sessionToSave);
            }
            else {
                dataService.eventsService.updateSession(id,sessionToSave);
            }
            
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
                Session: [],
                Ticket: []
            }
            if (id != "") {
                dataService.eventsService.getEventSessions(id).then(function (ret) {
                    $scope.Session = angular.copy(ret.data.result);
                    $scope.sessionsLoaded = true;
                });
                dataService.eventsService.getEventTickets(id).then(function (ret) {
                    $scope.Ticket = angular.copy(ret.data.result);
                    $scope.ticketsLoaded = true;
                });
            }
            
        }
        
        $scope.navigate = function (url) {
            $location.path(url);
        };

        $scope.addSession = function () {
            $scope.openEditSessionModal();
        };

        $scope.openEditSessionModal = function (session) {
            var name = "";
            if (session) {
                name = session.name;
                session = angular.copy(session);
            } else {
                session = {};
            }

            var modalOpts = {
                // backdrop: true,
                keyboard: true,
                modalFade: true,
                templateUrl: views+'sessionEdit.html'
            };

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Aceptar',
                headerText: 'Editing ' + name,
                bodyText: '',
                session: session,
                tickets: $scope.Ticket,
                eventId:id
            };

            var modal = modalService.showModal(modalOpts, modalOptions).then(function (result) {
                if (result) {
                    dataService.eventsService.insertSession(result);
                    $scope.model.Session.push(result);
                }
            });
        };

        

    };

    SessionController.$inject = ["$rootScope", "$scope", "$routeParams",
                                       "dataService", "modalService", "validationService", "appConfig"];

    angular.module("ticketsApp").controller("SessionController", SessionController);

}());