(function () {

    var EventEditController = function ($rootScope, $scope, $routeParams, dataService, modalService, validationService, appConfig) {

        var id = ($routeParams.id) ? $routeParams.id : "",
            timer,
            onRouteChangeOff;

        var views = appConfig.views + "events/";
        $scope.validationLoaded = false;
        $scope.formconfig = false;
        validationService.getValidation("Event", "model").then(function (ret) {
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
            var eventToSave = angular.copy($scope.model);

            if (!this.edit) {
                dataService.eventsService.insertEvent(eventToSave).then(function () {
                    $scope.$close();
                });
            }
            else {
                dataService.eventsService.updateEvent(id, eventToSave).then(function () {
                    $scope.$close();
                });
            }
            
        };


        $scope.delete = function () {
            var name = $scope.model.name;

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete Event',
                headerText: 'Delete ' + name + '?',
                bodyText: 'Are you sure you would like to delete this  Event?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    dataService.eventsService.deleteEvent(name);
                    $scope.updateEvents();
                }
            });
        };
        
        function parseTimeToDate(time){
            var splited=time.split(":");
            var d=new Date();
            d.setHours(splited[0]);
            d.setMinutes(splited[1]);
            return d;
        }
        

        function init() {
            $scope.model = {
                Id:null,
                Ticket: []
            }
            if (id != "") {
                dataService.eventsService.getEvent(id).then(function (ret) {
                    $scope.model = angular.copy(ret.data.result);
                });
            }
            
        }
        
        $scope.navigate = function (url) {
            $location.path(url);
        };

        $scope.addTicket = function () {
            $scope.openEditTicketModal();
        };

        $scope.openEditTicketModal = function (ticket) {
            var Name = "";
            if (ticket) {
                name = ticket.Name;
                ticket = angular.copy(ticket);
            } else {
                ticket = {};
            }

            var modalOpts = {
                // backdrop: true,
                keyboard: true,
                modalFade: true,
                templateUrl: views+'ticketEdit.html'
            };

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Aceptar',
                headerText: 'Editing ' + name,
                bodyText: '',
                ticket: ticket
            };

            var modal=modalService.showModal(modalOpts, modalOptions).then(function (result) {
                if (result) {
                    $scope.model.Ticket.push(result);
                }
            });
        };


    };

    EventEditController.$inject = ["$rootScope", "$scope", "$routeParams",
                                       "dataService", "modalService", "validationService", "appConfig"];

    angular.module("ticketsApp").controller("EventEditController", EventEditController);

}());