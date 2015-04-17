using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using SPA.KnockoutJs.Service.Models;

namespace SPA.KnockoutJs.Service
{    
    [ServiceContract]
    public interface IStudentService
    {
        /// <summary>
        /// This method is used to give all student information from database.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Student> GetAllStudentDetail();

        [OperationContract]
        Student GetStudentDetail(int id);

        [OperationContract]
        Student SaveStudentDetail(int? id, Student student);

        [OperationContract]
        bool DeleteStudentDetail(int id);

    }
}
