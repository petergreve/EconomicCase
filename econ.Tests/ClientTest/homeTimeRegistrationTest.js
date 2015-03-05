/// <reference path="../scripts/jasmine.js" />
/// <reference path="../../econ/scripts/angular.js" />
/// <reference path="../../econ/scripts/angular-mocks.js" />
/// <reference path="../../econ/js/time-registration.js" />

describe("homeTimeRegistration Test", function () {

    beforeEach(function () {
        module(homeTimeRegistration);
    });

    var $httpBackend;

    beforeEach(inject(function ($injector) {

        $httpBackend = $injector.get("$httpBackend")

        $httpBackend.when("GET", "/api/projects?includeReplies=false")
            .respond([{
                id: 1,
                name: "Test Project 1",
                created: "01032015"
            },
            {
                id: 2,
                name: "Test Project 2",
                created: "01032015"
            },
            {
                id: 3,
                name: "Test Project 3",
                created: "01032015"
            }]);

    }));


    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequests();
    });

    describe("dataService", function () {

        it("can load projects", inject(function (dataService) {

            expect(dataService.projects).toEqual([]);


            $httpBackend.expectGET("/api/projects?includeReplies=false");
            dataService.getProjects();
            $httpBackend.flush();
            expect(dataService.projects.length).toBeGreaterThan(0);
            expect(dataService.projects.length).toEqual(3);

        }));
    });

});