(function () {

    var ticketsService = function ($http) {
        var modelUrl = appConfig.baseUrl+appConfig.models.tickets,
			pageSize= appConfig.pageSize,
            factory = {};
			
		factory.tickets=[];
        
        factory.getTickets = function (pageIndex) {
            return $http.get(modelUrl+"/page?limit="+pageSize+"&start="+pageIndex);
        };
        
        factory.insertTicket = function (ticket) {
            return $http.post(modelUrl, ticket);
        };

        factory.updateTicket = function (name,ticket) {
            return $http.put(modelUrl+"/"+name, ticket);
        };

        factory.deleteTicket = function (name) {
            return $http.delete(modelUrl+"/"+name);
        };

        factory.getTicket = function (name) {
            return $http.get(modelUrl+"/"+name);
        };
        
        factory.initialize = function(){
        	return this.getTickets(0);
        }
		
		factory.getPagedTickets = function(pageIndex, pageSize) {
            var tickets=(this.filteredTickets&&this.filteredTickets.length>0)?this.filteredTickets:this.tickets;
            return { totalRecords:tickets.length , results:tickets.slice((pageIndex * pageSize), ((pageIndex+1) * pageSize)) }
        }

        return factory;
    };

    ticketsService.$inject = ["$http"];

    angular.module("ticketsApp").factory("ticketsService", ticketsService);

}());