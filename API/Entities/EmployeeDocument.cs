using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class EmployeeDocument
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public Employee Employee { get; set; }
        public string DocName { get; set; }
        public string? DocType { get; set; }
        public string? DocUrl { get; set; }
        public DateTime Created { get; set; }   
        public DateTime LastModify { get; set; }
        public bool IsActive { get; set; }
        
    }
}