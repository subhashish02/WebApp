using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Student
    {
        public int rollno { get; set; }
        public string sname { get; set; }
        public int sage { get; set; }
        public string sgender { get; set; }
        public DateTime sdob { get; set; }
        public int maxmarks { get; set; }
        public int marksobt { get; set; }
        public int phy { get; set; }
        public int chem { get; set; }
        public int math { get; set; }
        public int bio { get; set; }
    }
}