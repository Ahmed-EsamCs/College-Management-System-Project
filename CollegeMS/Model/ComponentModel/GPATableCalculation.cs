using CollegeMS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.Model.ComponentModel
{
    public class GPATableCalculation
    {
        public Course Course { get; set; }
        public string GradePercentage { get; 
            set; }
        public double GradePoints { get; set;}
        public string LetterGrade { get; set; }
    }
}
