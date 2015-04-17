using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace SPA.KnockoutJs.Service.Models
{
    [DataContract]
    public partial class Employee
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
        [DataMember]
        public decimal BasicSalary { get; set; }
        [DataMember]
        public System.DateTime DateOfJoining { get; set; }
        [DataMember]
        public System.DateTime DateOfBirth { get; set; }
        [DataMember]
        public string ProjectName { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
