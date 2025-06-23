using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.Model.Data
{
    public class Course
    {
        private string name;
        public string Name { get; set; }
        public int CreditHour { get; set; }
        public int Level {  get; set; }
    }
}
