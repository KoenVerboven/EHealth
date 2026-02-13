namespace VKmfSoft_EHealth_API.Models.DTO.Hospital
{
    public class OnePersonPatientRoomUpdateDTO
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public decimal DayPrice { get; set; }
        public decimal SupplementCostForOnePersonRoom { get; set; }
        public int PatientId { get; set; }
        //public Patient.Patient? Patient { get; set; }
    }
}
