using VKmfSoft_EHealth_API.Models.Domain.Messages;

namespace VKmfSoft_EHealth_API.Models.Domain.General
{
    public class Medication
    {
        public int Id { get; set; }
        public int PatientMedicationId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int Doses { get; set; }
        public int TimesADay { get; set; }
        public List<MedicationSideEffect>? SideEffects { get; set; }
    }
}
