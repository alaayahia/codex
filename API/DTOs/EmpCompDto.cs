
namespace API.DTOs
{
    public class EmpCompDto
    {
        public int Id { get; set; }
       public string EmpName { get; set; }
        public int EmpId { get; set; }
        public string CompName { get; set; }
        public int CompId { get; set; }
        public double CompValue { get; set; }
        public DateTime StartFrom { get; set; }
    }
}