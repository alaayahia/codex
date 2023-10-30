
namespace API.DTOs
{
    public class CompensationDto
    {
        public int Id { get; set; }
        public string CompName { get; set; }
        public string CompMethod { get; set; }
        public string CompType { get; set; }
        public string? Equation { get; set; }
        public bool IsAffected { get; set; }
        
    }
}