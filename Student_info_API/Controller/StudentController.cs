using Student_info_API.Filters;
using Student_info_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Student_info_API.Controller
{
    public class StudentController : ApiController
    {
        DBstudent_InformationEntities2 db = new DBstudent_InformationEntities2();
        String data;
        [CustomActionFilter]
        public IHttpActionResult PostData(Tbl_student_information student)
        {
           
                if (student != null)
                {
                    db.Tbl_student_information.Add(student);
                    db.SaveChanges();
                    return Ok("Data is Inserted..!!!");
                }

                else
                {
                    return BadRequest("Provide Proper Data..!!");
                }
                
        }

        public IHttpActionResult GetByID(int Student_Id)
        {
           
           Tbl_student_information Student = db.Tbl_student_information.Find(Student_Id);
            if (Student != null)
            {
                return Content(HttpStatusCode.OK, Student);
            }

            else
            {
                return BadRequest("Provide Proper Data..!!"+ Student_Id);
            }


        }
        [CustomException]
        public IHttpActionResult Update(Tbl_student_information Student,int Student_id)
        {
       
                Tbl_student_information Student1 = db.Tbl_student_information.Find(Student_id);

            //    if (Student1 != null)
            //    {
                    Student1.Sname = Student.Sname;
                    Student1.Degree = Student.Degree;
                    Student1.City = Student.City;
                    Student1.Gender = Student.Gender;
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data Updated Succesfully..!!");
              //  }
                //else
                //{
                //    return Content(HttpStatusCode.NotFound, "No DATA FOUND To this id " + Student_id);
                //}

            

        }
        [CustomException]
        public IHttpActionResult Delete(int Student_Id)
        {
            try
            {
                Tbl_student_information Student = db.Tbl_student_information.Find(Student_Id);

                if (Student != null)
                {
                    db.Tbl_student_information.Remove(Student);
                    db.SaveChanges();
                    return Content(HttpStatusCode.OK, "Data Deleted Succesfully..!!");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "No DATA FOUND To this id " + Student_Id);
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }

        public IHttpActionResult GetAllData()
        {
            try
            {
                List<Tbl_student_information> Data = db.Tbl_student_information.ToList();
                if (Data.Count > 0)
                {
                    return Content(HttpStatusCode.OK, Data);
                }
                else
                {
                    return Content(HttpStatusCode.NoContent, "No DATA FOUND");
                }

            }
            catch
            {
                return Content(HttpStatusCode.NoContent, "PLEASE TRY AGAIN..!!");
            }
        }
    }
}
