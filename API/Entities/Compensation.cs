using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Compensation
    {
        public int Id { get; set; }
        public string CompName { get; set; }
        public string CompMethod { get; set; }
        public string CompType { get; set; }
        public string? CompEquation { get; set; }
        public bool IsAffected { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModify { get; set; } = DateTime.Now;
        public bool IsActive { get; set; }


        public ICollection<EmployeeCompensation> EmployeeCompensations { get; set; }

        
    }
}