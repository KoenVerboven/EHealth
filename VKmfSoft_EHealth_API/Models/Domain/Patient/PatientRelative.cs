using VKmfSoft_EHealth_API.Models.Domain.Other;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientRelative : Person // This class represents a relative of a patient, such as a family member or caregiver.
    {
        public int RelationType { get; set; }
    }
}
