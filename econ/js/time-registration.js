//time-registration.js

var module = angular.module("homeTimeRegistration", ["ngRoute"]);
 
module.config(function ($routeProvider) {
    $routeProvider.when("/", {
        controller: "projectsController",
        templateUrl: "/templates/projectsView.html"
    });

    $routeProvider.when("/newProject", {
        controller: "newProjectController",
        templateUrl: "/templates/newProjectView.html"
    });

    $routeProvider.when("/project/:id", {
        controller: "singleProjectController",
        templateUrl: "/templates/singleProjectView.html"

    });

    $routeProvider.when("/projects/:id/newRegistration", {
        controller: "newRegistrationController",
        templateUrl: "/templates/newRegistrationView.html"
    });

    $routeProvider.otherwise({ redirectTo: "/"});
})


module.factory("dataService", function($http, $q) {

    var _projects = [];
    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    }
    var _getProjects = function () {

        var deferred = $q.defer();

        $http.get("/api/projects?includeRegistrations=true")
            .then(function (result) {
                //success
                angular.copy(result.data, _projects);
                _isInit = true;
                deferred.resolve();
            },
            function () {
                //error
                deferred.reject();
            });

        return deferred.promise;
    }

    function _findProject(id) {
        var found = null;

        $.each(_projects, function (i, item) {
            if (item.id == id) {
                found = item;
                return false;
            }
        })

        return found;
    }


    var _addProject = function (newProject) {
        var deferred = $q.defer();

        $http.post("/api/projects", newProject)
            .then(function (result) {
                //success
                var newlyCreatedProject = result.data;
                _projects.splice(0, 0, newlyCreatedProject);
                deferred.resolve(newlyCreatedProject);
            },
            function () {
                //error
                deferred.reject();
            });

        return deferred.promise;

    }

    var _getProjectById = function (id) {
        var deferred = $q.defer();

        if (_isReady()) {
            var project = _findProject(id);
            if (project) {
                deferred.resolve(project)
            } else {
                deferred.reject();
            }
        } else {
            _getProjects()
            .then(function () {
                //success
                var project = _findProject(id);
                if (project) {
                    deferred.resolve(project)
                } else {
                    deferred.reject();
                }
            },
            function () {
                //error
                deferred.reject();
            });
        }
        return deferred.promise;

    }


    var _saveRegistration = function (project,newRegistration) {
        var deferred = $q.defer();

        $http.post("/api/projects/" + project.id + "/registrations", newRegistration)
            .then(function (result) {
                //success
                if (project.registrations == null) project.registrations = [];
                project.registrations.push(result.data);
                deferred.resolve(result.data);
            }, function () {
                //error
                deferred.reject();
            });

        return deferred.promise;
    }

    return {
        projects: _projects,
        getProjects: _getProjects,
        addProject: _addProject,
        isReady: _isReady,
        getProjectById: _getProjectById,
        saveRegistration: _saveRegistration
    };
})

module.controller("projectsController", function ($scope,$http, dataService) {
    $scope.dataCount = 0;
    $scope.data = dataService;
    $scope.isBusy = false;

    if (dataService.isReady() == false) {
        $scope.isBusy = false;
    dataService.getProjects()
        .then(function () {
            //success
        },
        function() {
            //error
            alert("Could not load projects");
        })
        .then(function () {
            $scope.isBusy = false;
        });
    }
});

module.controller("newProjectController", function ($scope, $http, $window, dataService) {
    $scope.newProject = {};

    $scope.save = function () {

        dataService.addProject($scope.newProject)
            .then(function () {
                //success
                $window.location = "#/";
            },
            function () {
                //error
                alert("could not save new project");
            });
    };
});

module.controller("singleProjectController", function ($scope, $http, $window, dataService,$routeParams) {

    $scope.project = null;
    $scope.newRegistration = {};

    dataService.getProjectById($routeParams.id)
        .then(function (project) {
            //sucess
            $scope.project = project;
        },
        function() {
            //error
            $window.location = "#/";
            alert("could not find project");
        });

    $scope.getTotal = function () {
        var total = 0;
        if ($scope.project.registrations.length > 0) {
            for (var i = 0; i < $scope.project.registrations.length; i++) {
                var registration = $scope.project.registrations[i];
                total += registration.hours;
            }
        }
        return total;
    }

});

module.controller("newRegistrationController", function ($scope, $http, $window, dataService, $routeParams) {
    $scope.newRegistration = {};
    $scope.save = function () {

    dataService.getProjectById($routeParams.id)
        .then(function (project) {
            //sucess
            dataService.saveRegistration(project, $scope.newRegistration)
                .then(function () {
                    //success
                    $window.location = "#/project/" + $routeParams.id;
                },
                function () {
                    //error
                    alert("could not save new registration");
                });
        },
        function () {
            //error
            $window.location = "#/";
            alert("could not find project");
        });
    };
});