using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Medical
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string InstructionsForUse { get; set; }
        public List<MedicationSideEffect>? SideEffects { get; set; }
        public byte MinimumAge { get; set; }
    }
}