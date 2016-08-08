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
        

        factory.getEventSessions = function (eventId) {
            return $http.get(sessionsUrl + "/Event/" + eventId);
        };

        factory.getSession = function (sessionId) {
            return $http.get(sessionsUrl + "/" + sessionId);
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

        factory.getSessionTickets = function (id) {
            return $http.get(ticketsUrl + "/Session/" + id);
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

        factory.getEventTickets = function (id) {
            return $http.get(ticketsUrl + "/Event/" + id);
        };

        factory.getEvent = function (id) {
            return $http.get(ticketsUrl + "/" + id);
        };





        factory.initialize = function(){
        	
        }
		
        return factory;
    };

    eventsService.$inject = ["$http"];

    angular.module("ticketsApp").factory("eventsService", eventsService);

}());