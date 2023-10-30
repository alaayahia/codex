
namespace API.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; } 
        public string? EmpName { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }   
        public string? JopDescription { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime AppointmentDate { get; set; }


        
    }
}