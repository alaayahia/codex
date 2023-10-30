using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class EmployeeCompensation
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public Employee Employee { get; set; }
        public int CompId { get; set; }
        public Compensation Compensation { get; set; }
        public double CompValue { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModify { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }


        
    }
}