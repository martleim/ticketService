(function () {

    var eventsService = function ($http) {
        var modelUrl = appConfig.baseUrl+appConfig.controllers.events,
			pageSize = appConfig.pageSize,
            eventsUrl = modelUrl + appConfig.models.events,
            sessionsUrl = modelUrl + appConfig.models.sessions,
            ticketsUrl = modelUrl + appConfig.models.tickets,
            factory = {};
			
		factory.events=[];
        
        factory.getEvents = function (pageIndex) {
            return $http.get(eventsUrl + "?limit=" + pageSize + "&start=" + pageIndex);
        };
        
        factory.insertEvent = function (event) {
            return $http.post(eventsUrl, event);
        };

        factory.updateEvent = function (id,event) {
            return $http.put(eventsUrl + "/" + id, event);
        };

        factory.deleteEvent = function (id) {
            return $http.delete(eventsUrl + "/" + id);
        };

        factory.getEvent = function (id) {
            return $http.get(eventsUrl + "/" + id);
        };
        

        factory.getSessions = function (eventId) {
            return $http.get(sessionsUrl + "/" + eventId);
        };

        factory.insertSession = function (session) {
            return $http.post(sessionsUrl, session);
        };

        factory.updateSession = function (id, session) {
            return $http.put(sessionsUrl + "/" + id, session);
        };

        factory.deleteSession = function (id) {
            return $http.delete(sessionsUrl + "/" + id);
        };

        factory.getSession = function (id) {
            return $http.get(sessionsUrl + "/" + id);
        };


        factory.getTickets = function (eventId) {
            return $http.get(ticketsUrl + "/0/" + eventId);
        };

        factory.insertTicket = function (ticket) {
            return $http.post(ticketsUrl, ticket);
        };

        factory.updateTicket = function (id, ticket) {
            return $http.put(ticketsUrl + "/" + id, ticket);
        };

        factory.deleteTicket = function (id) {
            return $http.delete(ticketsUrl + "/" + id);
        };

        factory.getTicket = function (id) {
            return $http.get(ticketsUrl + "/0/" + id);
        };





        factory.initialize = function(){
        	return this.getEvents(0);
        }
		
        return factory;
    };

    eventsService.$inject = ["$http"];

    angular.module("ticketsApp").factory("eventsService", eventsService);

}());