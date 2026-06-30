namespace VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel
{
    public class Diploma
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Grade { get; set; } //todo make enum grade
    }
}
