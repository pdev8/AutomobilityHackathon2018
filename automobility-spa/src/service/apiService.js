(function () {

    angular.module(AppName).factory("apiService", ApiService);
    ApiService.$inject = ["$http", "$q"];

    function ApiService($http, $q) {

        var srv = {
            RequestResponse :_requestResponse
        }

        return srv;

        function _requestResponse(method, endpoint, model) {

            //forces method to caps so gET and Get are the same
            method = method.toUpperCase();
            //object containing 4 keys. each with different http functions
            var type = {
                POST: $http.post,
                PUT: $http.put,
                GET: $http.get,
                DELETE: $http.delete
            };
            var returnType = type[method];
            //toggle to make sure if valid verb was provided
            var relevantVerb = false;
            var returnFunction;
            ////CHECKS AND SEE'S IF A VALID HTTP VERB WAS PROVIDED
            for (var i in type) {
                if (method == i) {
                    relevantVerb = true;
                    break;
                }
            }
            if (!endpoint) {
                //simple error handling
                return $q.reject("Endpoint provided is either null, empty or undefined.");
            } else if (relevantVerb === false) {
                return $q.reject("Not a valid request verb. Please check spelling.");
            } else {
                //if it had post or put, the function is going to expect a model to send.
                //if it isnt post or put, the function is not going to expect a model to send.
                if (method === "POST" || method === "PUT") {
                    returnFunction = returnType(endpoint, model, { withCredentials: true });
                } else {
                    returnFunction = returnType(endpoint, { withCredentials: true });
                }
                //runs the promise
                return returnFunction
                .then(function (response) {
                    return response.data;
                })
                .catch(function (err) {
                    return $q.reject(err);
                });

            }
        }
    }
})();