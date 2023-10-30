using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpName { get; set; }
        public DateTime DateOfBirth { get; set; }   
        public string? Gender { get; set; }
        public string? EmpPhone { get; set; }
        public string? JopDescription { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModify { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }


        public ICollection<EmployeeCompensation> EmployeeCompensations { get; set; }
        public ICollection<EmployeeDocument> EmployeeDocuments { get; set; }
        
    }
}