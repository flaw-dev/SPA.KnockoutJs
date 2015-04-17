using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SPA.KnockoutJs.Service.Models
{
    [DataContract]
    public partial class Student
    {
        [DataMember]
        public int StudentID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Class { get; set; }
        [DataMember]
        public string EnrollYear { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Country { get; set; }
    }
}
