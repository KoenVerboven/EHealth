namespace VKmfSoft_EHealth_API.Models.Domain.Medical
{
    public class Allergy //todo : koppel met patientallery-tabel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
