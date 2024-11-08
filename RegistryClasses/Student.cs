using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.RegistryClasses
{
    public class Student
    {
        public int? StudentId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? City { get; set; }

        public StudentClass StudentClass { get; set; }

        public override string ToString()
        {
            return string.Format("{0, -8}{1,-15}{2,-25}{3,-10}", StudentId, FirstName, LastName, City);
        }
    }
}
