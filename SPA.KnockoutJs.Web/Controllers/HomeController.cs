using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SPA.KnockoutJs.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Student()
        {
            return View();
        }
        public JsonResult GetAllStudent()
        {
            List<StudentServiceReference.Student> lstStudent = null;
            string message = string.Empty;
            bool status = false;
            try
            {
                StudentServiceReference.StudentServiceClient studentService = new StudentServiceReference.StudentServiceClient();
                lstStudent = studentService.GetAllStudentDetail();
                if (lstStudent == null)
                {
                    status = false;
                    lstStudent = new List<StudentServiceReference.Student>();
                    message = "Due to some error data in not binding!";
                }
                else
                {
                    status = true;
                    message = "Get all student information from database.";
                }

            }
            catch (Exception ex)
            {
                lstStudent = null;
                message = "Due to some error data in not bunding!";
            }
            return Json(new { resultData = lstStudent, outcome = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStudentDetail(int id)
        {
            bool status = false;
            string message = string.Empty;
            StudentServiceReference.Student studentObj = null;
            StudentServiceReference.StudentServiceClient studentService = new StudentServiceReference.StudentServiceClient();
            if (id > 0)
            {
                studentObj = studentService.GetStudentDetail(id);
            }
            return Json(new { resultData = studentObj, outcome = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateStudentDetail(StudentServiceReference.Student student)
        {
            bool status = false;
            string message = string.Empty;
            StudentServiceReference.Student studentObj = null;
            IList<StudentServiceReference.Student> lstStudent = null;
            StudentServiceReference.StudentServiceClient studentService = new StudentServiceReference.StudentServiceClient();
            studentObj = studentService.SaveStudentDetail(student.StudentID, student);
            if(studentObj != null && studentObj.StudentID > 0)
            {
                lstStudent = studentService.GetAllStudentDetail();
            }
            return Json(new { resultData = lstStudent, outcome = status, message = message }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult SaveStudentDetail(StudentServiceReference.Student student)
        {
            bool status = false;
            string message = string.Empty;
            StudentServiceReference.Student studentObj = null;
            StudentServiceReference.StudentServiceClient studentService = new StudentServiceReference.StudentServiceClient();
            studentObj = studentService.SaveStudentDetail(student.StudentID, student);

            return Json(new { resultData = studentObj, outcome = status, message = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteStudentDetail(int id)
        {
            bool status = false;
            string message = string.Empty;
            StudentServiceReference.StudentServiceClient studentService = new StudentServiceReference.StudentServiceClient();
            status = studentService.DeleteStudentDetail(id);
            return Json(new { outcome = status, message = message}, JsonRequestBehavior.AllowGet);

        }
    }
}
