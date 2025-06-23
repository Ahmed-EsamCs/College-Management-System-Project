using CollegeMS.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.Model.Data
{
    public class Student : Person, BaseDataModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Password { get; set;} 
        public int Level { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string Role { get; set; } = "Student";
        public string ParentPhone { get; set; }
        public double F_GPA { get; set; } = 0.0;

    }
}
