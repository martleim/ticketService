(function () {

    var EventsController = function ($scope, $location, $filter, dataService, modalService, appConfig) {

        var views = appConfig.views + "events/";

        $scope.events = [];
        $scope.unFilteredEvents = [];
        
        $scope.addressSearchText = null;
        $scope.nameSearchText = null;
        
        $scope.eventsGridConfig={
            data:"events",
            columns:[{name:"Name",label:"Name", width:"40%", sortable:true, sortFunction:function(a,b) { return a.name<b.name; }},
                    { name: "Description", label: "Description", width: "40%" },
                    { name: "name", label: "", width: "10%", cellRenderer: "<button type='button' class='btn btn-primary' style='margin-right:8px;height:30px' ng-click='manageSession(row)'>Sessions</button>" },
                    {name:"name",label:"", width:"10%",cellRenderer:"<button type='button' class='btn btn-danger glyphicon glyphicon-remove-sign' style='margin-right:8px;height:30px' ng-click='delete(row)'></button><button type='button' class='btn btn-primary glyphicon glyphicon-pencil' style='margin-right:8px;height:30px' ng-click='editEvent(row)'></button>"}]
        };
		

        //paging
        $scope.totalRecords = 0;
        $scope.pageSize = 10;
        $scope.currentPage = 0;
        $scope.navigatablePages=[];
        $scope.totalShownPages=6;
        $scope.totalPages=0;

        $scope.pageChanged = function (page) {
            if(page>=0 && page<$scope.totalPages){
                $scope.currentPage = page;
                $scope.updateEvents();
            }
        };
        
        $scope.nextPage = function () {
            $scope.pageChanged($scope.currentPage+1);
        };
        
        $scope.lastPage = function () {
            $scope.pageChanged($scope.currentPage-1);
        };

        $scope.delete = function (event) {
            
            var name = event.name;

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
        
        $scope.editEvent=function(event){
            $location.path("/eventedit/"+event.name);
        };

        $scope.navigate = function (url) {
            $location.path(url);
        };

        $scope.searchTextChanged = function () {
            this.filterEvents($scope.nameSearchText);
        };

        $scope.updateEvents = function(){
            dataService.eventsService.getEvents(this.currentPage,this.pageSize).then(function(res){
				res=res.data;
				$scope.events=res.result;
				$scope.unFilteredEvents=$scope.events;

				$scope.totalRecords=res.totalRecords;
				$scope.setNavigatablePages();	
			});
        }
        
        $scope.setNavigatablePages = function () {
            var pages = [];
            if (this.totalRecords > 0) {
                $scope.totalPages = Math.ceil(this.totalRecords / this.pageSize);
                var start = this.currentPage - ($scope.totalShownPages / 2);
                start = (start < 1) ? 1 : start;
                var totalShownPages = ($scope.totalPages > $scope.totalShownPages) ? $scope.totalShownPages : $scope.totalPages;
                var end = start + (totalShownPages - 1);
                if (end > $scope.totalPages) {
                    start -= (end - $scope.totalPages);
                }
                
                for (var i = 0; i < totalShownPages; i++) {
                    pages.push(start + i);
                }
            }
            $scope.navigatablePages=pages;
        }
        
        

        $scope.filterEvents=function(name) {
            var filteredEvents = $filter("nameFilter")($scope.unFilteredEvents, name);
            $scope.events=filteredEvents;
            
        }

        $scope.addEvent = function () {
            $scope.openEditModal();
        };

        $scope.editEvent = function (event) {
            $scope.openEditModal(event);
        };

        $scope.openEditModal = function (event) {
            var name = "";
            if (event) {
                name = event.name;
                event = angular.copy(event);
            } else {
                event = {};
            }

            var modalOpts = {
                // backdrop: true,
                keyboard: true,
                modalFade: true,
                templateUrl: views + 'eventEdit.html'
            };

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Ok',
                headerText: 'Editing ' + name,
                bodyText: '',
                event: event
            };

            modalService.showModal(modalOpts, modalOptions).then(function (result) {
                $scope.updateEvents();
            });
        };

        $scope.manageSession = function (event) {
            var name = "";
            if (event) {
                name = event.name;
                event = angular.copy(event);
            } else {
                event = {};
            }

            var modalOpts = {
                // backdrop: true,
                keyboard: true,
                modalFade: true,
                templateUrl: views + 'sessions.html'
            };

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Ok',
                headerText: 'Editing ' + name,
                bodyText: '',
                eventId: event.Id
            };

            modalService.showModal(modalOpts, modalOptions).then(function (result) {
                if (result === 'ok') {
                    if (name == "") {
                        dataService.createCategory(modalOptions.category.category, modalOptions.category.description, modalOptions.category.image).then($scope.refreshCategories);
                    } else {
                        dataService.updateCategory(modalOptions.category.id, modalOptions.category.category, modalOptions.category.description, modalOptions.category.image).then($scope.refreshCategories());
                    }
                }
            });
        }

        function init() {
            //dataService.eventsService.initialize().then(function(p) {
                $scope.updateEvents();
            //});
        }   
        init();
    };

    EventsController.$inject = ['$scope', '$location', '$filter', 'dataService', 'modalService', 'appConfig'];

    angular.module('ticketsApp').controller('EventsController', EventsController);

}());
