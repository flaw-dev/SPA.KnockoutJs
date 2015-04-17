/// <reference path="../angular.min.js" />  
/// <reference path="Modules.js" />  

app.service("StudentService", function ($http) {
    //Create new record  
    this.post = function (Student) {
        var request = $http({
            method: "post",
            url: "http://localhost:27321/StudentService.svc/AddNewStudent",
            data: Student
        });
        return request;
    }

    //Update the Record  
    this.put = function (StudentID, Student) {
        debugger;
        var request = $http({
            method: "put",
            url: "http://localhost:27321/StudentService.svc/UpdateStudent",
            data: Student
        });
        return request;
    }

    this.getAllStudent = function () {
        return $http.get("/Home/GetAllStudent/");
    };

    //Get Single Records  
    this.get = function (StudentID) {
        return $http.get("http://localhost:27321/StudentService.svc/GetStudentDetails/" + StudentID);
    }

    //Delete the Record  
    this.delete = function (StudentID) {
        var request = $http({
            method: "delete",
            url: "http://localhost:27321/StudentService.svc/DeleteStudent/" + StudentID
        });
        return request;
    }
});