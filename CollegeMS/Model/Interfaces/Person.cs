using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeMS.Model.Interfaces
{
    internal interface Person
    {
        int id { get; set; }    
        string Name { get; set; }
        string Email { get; set; }
        DateTime BirthDate { get; set; }
        string Role { get; set; }   
    }
}
