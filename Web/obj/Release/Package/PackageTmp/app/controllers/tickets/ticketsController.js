(function () {

    var TicketsController = function ($scope, $location, $filter, dataService, modalService) {

        $scope.tickets = [];
        $scope.unFilteredTickets = [];
        
        $scope.addressSearchText = null;
        $scope.nameSearchText = null;
        
        $scope.ticketsGridConfig={
            data:"tickets",
            columns:[{name:"name",label:"Nombre", width:"30%", sortable:true, sortFunction:function(a,b) { return a.name<b.name; }},
                    {name:"address",label:"Direccion", width:"30%"},
                    {name:"phone",label:"Telefono", width:"20%" },
					{name:"gender",label:"Sexo", width:"10%" ,cellRenderer:function(row){ 
                        return (row.gender=='f')?'Mujer':'Hombre';
                    } },
                    {name:"name",label:"", width:"10%",cellRenderer:"<button type='button' class='btn btn-danger glyphicon glyphicon-remove-sign' style='margin-right:8px;height:30px' ng-click='delete(row)'></button><button type='button' class='btn btn-primary glyphicon glyphicon-pencil' style='margin-right:8px;height:30px' ng-click='editTicket(row)'></button>"}]
        };
		

        //paging
        $scope.totalRecords = 0;
        $scope.pageSize = 10;
        $scope.currentPage = 1;
        $scope.navigatablePages=[];
        $scope.totalShownPages=6;
        $scope.totalPages=0;

        $scope.pageChanged = function (page) {
            if(page>=1 && page<=$scope.totalPages){
                $scope.currentPage = page;
                $scope.updateTickets();
            }
        };
        
        $scope.nextPage = function () {
            $scope.pageChanged($scope.currentPage+1);
        };
        
        $scope.lastPage = function () {
            $scope.pageChanged($scope.currentPage-1);
        };

        $scope.delete = function (ticket) {
            
            var name = ticket.name;

            var modalOptions = {
                closeButtonText: 'Cancel',
                actionButtonText: 'Delete Tickete',
                headerText: 'Delete ' + name + '?',
                bodyText: 'Are you sure you would like to delete this  Tickete?'
            };

            modalService.showModal({}, modalOptions).then(function (result) {
                if (result === 'ok') {
                    dataService.ticketsService.deleteTicket(name);
                    $scope.updateTickets();
                }
            });
        };
        
        $scope.editTicket=function(ticket){
            $location.path("/ticketedit/"+ticket.name);
        };

        $scope.navigate = function (url) {
            $location.path(url);
        };

        $scope.searchTextChanged = function () {
            this.filterTickets($scope.nameSearchText, $scope.addressSearchText);
        };

        $scope.updateTickets = function(){
            dataService.ticketsService.getTickets(this.currentPage,this.pageSize).then(function(res){
				res=res.data;
				$scope.tickets=res.result;
				$scope.unFilteredTickets=$scope.tickets;

				$scope.totalRecords=res.totalRecords;
				$scope.setNavigatablePages();	
			});
        }
        
        $scope.setNavigatablePages = function(){
            $scope.totalPages=Math.ceil(this.totalRecords/this.pageSize)-1;
            var start=this.currentPage-($scope.totalShownPages/2);
            start=(start<1)?1:start;
            var end=start+($scope.totalShownPages-1);
            if(end>$scope.totalPages){
                start-=(end-$scope.totalPages);
            }
            var pages=[];
            for(var i=0;i<$scope.totalShownPages;i++){
                pages.push(start+i);
            }
            $scope.navigatablePages=pages;
        }
        
        

        $scope.filterTickets=function(name,address) {
            var filteredTickets = $filter("nameAddressFilter")($scope.unFilteredTickets, name, address);
            $scope.tickets=filteredTickets;
            
        }

        function init() {
            dataService.ticketsService.initialize().then(function(p) {
                $scope.updateTickets();
            });
        }
            
        init();
    };

    TicketsController.$inject = ['$scope', '$location', '$filter', 'dataService', 'modalService'];

    angular.module('ticketsApp').controller('TicketsController', TicketsController);

}());
