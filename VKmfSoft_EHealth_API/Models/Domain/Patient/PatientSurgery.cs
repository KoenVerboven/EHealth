using System.ComponentModel.DataAnnotations;
using VKmfSoft_EHealth_API.Models.Domain.Other;

namespace VKmfSoft_EHealth_API.Models.Domain.Patient
{
    public class PatientSurgery
    {
        [Key]
        public int Id { get; set; }

        #region Info about Patient
        public int PatientId { get; set; }
        public int PatientMedicalHistoryId { get; set; }//FK to PatientMedicalHistory
        [Required(ErrorMessage = "SurgeryType is required.")]
        public required int PatientAdmissionId { get; set; } //FK to PatientAdmission
        #endregion

        #region Info about surgery
        public required int SurgeryTypeId { get; set; }
        public DateTime SurgeryDate { get; set; }
        #endregion

        #region Info about Medcalworkers present during surgery
        public int ChiefOfSurgeryId { get; set; }
        public  List<MedicalWorker> MediacalWorkers { get; set; }
        #endregion

        #region Info where surgery was performed
        public int HospitalNameId { get; set; }
        public int ChurgeryRoomNumber { get; set; }
        #endregion

        #region  Info info about surgery
        public string? Notes { get; set; }
        public int StatusId { get; set; } 
        public DateTime CreatedAt { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }
        #endregion
    }
}
