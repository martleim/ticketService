(function () {

    var nameFilter = function () {

        return function (elements, name) {
            if (!name && name!="") return elements;

            var matches = [];
            name = (name)?name.toLowerCase():"";
            for (var i = 0; i < elements.length; i++) {
                var delivery = elements[i];
                if ((delivery.name.toLowerCase().indexOf(name) > -1 || name=="") ) {

                    matches.push(delivery);
                }
            }
            return matches;
        };
    };

    angular.module('ticketsApp').filter('nameFilter', nameFilter);

}());