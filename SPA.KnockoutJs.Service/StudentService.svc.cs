using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SPA.KnockoutJs.Service.Models;
using SPA.KnockoutJs.Service.DAL;

namespace SPA.KnockoutJs.Service
{
    
    public class StudentService : IStudentService
    {
        public List<Student> GetAllStudentDetail()
        {
            List<Student> lstStudent = null;
            SampleDatabaseContext db = new SampleDatabaseContext();
            lstStudent = db.Students.ToList();
            
            return lstStudent;
        }

        public Student GetStudentDetail(int id)
        {
            Student studentObj = null;
            if(id > 0)
            {
                SampleDatabaseContext db= new SampleDatabaseContext();
                studentObj = db.Students.Where(a => a.StudentID == id).FirstOrDefault();
            }
            return studentObj;
        }

        public Student SaveStudentDetail(int? id, Student student)
        {
            SampleDatabaseContext db = new SampleDatabaseContext();
            try
            {
                if (id != null && id.Value > 0)
                {
                    db.Entry<Student>(student).State = EntityState.Modified;
                }
                else
                {
                    db.Entry<Student>(student).State = EntityState.Added;
                }
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return student;
        }

        public bool DeleteStudentDetail(int id)
        {
            try
            {
                if(id > 0)
                {
                    SampleDatabaseContext db = new SampleDatabaseContext();
                    Student studentObj = db.Students.Where(a => a.StudentID == id).FirstOrDefault();
                    if (studentObj != null)
                    {
                        db.Entry<Student>(studentObj).State = EntityState.Deleted;
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
