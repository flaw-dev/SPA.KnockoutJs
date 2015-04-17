/// <reference path="../angular.min.js" />  
/// <reference path="Modules.js" />  
/// <reference path="Services.js" />  

app.controller("StudentController", function ($scope, StudentService) {

    $scope.OperType = 1;
    //1 Mean New Entry  

    GetAllRecords();
    //To Get All Records  
    function GetAllRecords() {
        var resultPromise = StudentService.getAllStudent();
        resultPromise.then(function (pl) {
            //resultPromise.success(function (data) {
            //console.log(pl);
            $scope.Students = pl.data.resultData;
        });
    }

    //To Clear all input controls.  
    function ClearModels() {
        $scope.OperType = 1;
        $scope.StudentID = "";
        $scope.Name = "";
        $scope.Email = "";
        $scope.Class = "";
        $scope.EnrollYear = "";
        $scope.City = "";
        $scope.Country = "";
    }

    //To Create new record and Edit an existing Record.  
    $scope.save = function () {
        var Student = {
            Name: $scope.Name,
            Email: $scope.Email,
            Class: $scope.Class,
            EnrollYear: $scope.EnrollYear,
            City: $scope.City,
            Country: $scope.Country
        };
        if ($scope.OperType === 1) {
            var promisePost = StudentService.post(Student);
            promisePost.then(function (pl) {
                $scope.StudentID = pl.data.StudentID;
                GetAllRecords();

                ClearModels();
            }, function (err) {
                console.log("Some error Occured" + err);
            });
        } else {
            //Edit the record      
            //debugger;
            Student.StudentID = $scope.StudentID;
            var promisePut = StudentService.put($scope.StudentID, Student);
            promisePut.then(function (pl) {
                $scope.Message = "Student Updated Successfuly";
                GetAllRecords();
                ClearModels();
            }, function (err) {
                console.log("Some Error Occured." + err);
            });
        }
    };

    //To Get Student Detail on the Base of Student ID  
    $scope.get = function (Student) {
        var promiseGetSingle = StudentService.get(Student.StudentID);
        promiseGetSingle.then(function (pl) {
            var res = pl.data;
            $scope.StudentID = res.StudentID;
            $scope.Name = res.Name;
            $scope.Email = res.Email;
            $scope.Class = res.Class;
            $scope.EnrollYear = res.EnrollYear;
            $scope.City = res.City;
            $scope.Country = res.Country;
            $scope.OperType = 0;
        },
                  function (errorPl) {
                      console.log('Some Error in Getting Details', errorPl);
                  });
    }

    //To Delete Record  
    $scope.delete = function (Student) {
        var promiseDelete = StudentService.delete(Student.StudentID);
        promiseDelete.then(function (pl) {
            $scope.Message = "Student Deleted Successfuly";
            GetAllRecords();
            ClearModels();
        }, function (err) {
            console.log("Some Error Occured." + err);
        });
    }
});