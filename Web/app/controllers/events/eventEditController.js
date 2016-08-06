(function () {

    var EventEditController = function ($rootScope, $scope, $routeParams, $timeout, dataService, modalService, validationService) {

        var id = ($routeParams.id) ? $routeParams.id : "",
            timer,
            onRouteChangeOff;

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
                dataService.eventsService.insertEvent(eventToSave);
            }
            else {
                dataService.eventsService.updateEvent(id,eventToSave);
            }
            processSuccess();
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
                tickets: [],
                sessions: []
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
                templateUrl: 'ticketEdit.html'
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
                    /*if (!result.Id) {
                        dataService.createCategory(modalOptions.category.category, modalOptions.category.description, modalOptions.category.image).then($scope.refreshCategories);
                    } else {
                        dataService.updateCategory(modalOptions.category.id, modalOptions.category.category, modalOptions.category.description, modalOptions.category.image).then($scope.refreshCategories());
                    }*/
                    $scope.model.tickets.push(result);
                }
            });
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
                templateUrl: 'sessionEdit.html'
            };

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Aceptar',
                headerText: 'Editing ' + name,
                bodyText: '',
                session: session
            };

            var modal = modalService.showModal(modalOpts, modalOptions).then(function (result) {
                if (result) {   
                    /*if (!result.Id) {
                        dataService.createCategory(modalOptions.category.category, modalOptions.category.description, modalOptions.category.image).then($scope.refreshCategories);
                    } else {
                        dataService.updateCategory(modalOptions.category.id, modalOptions.category.category, modalOptions.category.description, modalOptions.category.image).then($scope.refreshCategories());
                    }*/
                    $scope.model.sessions.push(result);
                }
            });
        };

        

        function processSuccess() {
            $scope.editForm.$dirty = false;
            $scope.updateStatus = true;
            $scope.title = "Editar";
            $scope.buttonText = "Guardar";
            $scope.edit=true;
            startTimer();
            $scope.$close();
        }

        function startTimer() {
            timer = $timeout(function () {
                $timeout.cancel(timer);
                $scope.errorMessage = '';
                $scope.updateStatus = false;
                
            }, 1000);
        }

    };

    EventEditController.$inject = ["$rootScope", "$scope", "$routeParams",
                                      "$timeout", "dataService", "modalService", "validationService"];

    angular.module("ticketsApp").controller("EventEditController", EventEditController);

}());