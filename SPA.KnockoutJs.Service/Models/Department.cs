using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SPA.KnockoutJs.Service.Models
{
    [DataContract]
    public partial class Department
    {
        [DataMember]
        public int DepartmentID { get; set; }
        [DataMember]
        public string DepartmentName { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
