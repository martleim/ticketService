(function () {

    var dataService = function (eventsService, ticketsService) {
        this.eventsService = eventsService;
        this.ticketsService = ticketsService;
        return this;
    };

    dataService.$inject = ['eventsService', 'ticketsService'];

    angular.module('ticketsApp').factory('dataService', dataService);

}());

