using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.DataUtility;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student
        public List<Student> Get()
        {
            return StudentUtility.GetAllStudent();
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public string Post(Student value)
        {
            return StudentUtility.CreateStudent(value);
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
