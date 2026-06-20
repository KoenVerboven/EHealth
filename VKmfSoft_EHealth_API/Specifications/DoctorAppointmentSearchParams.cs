namespace VKmfSoft_EHealth_API.Specifications
{
    public record DoctorAppointmentSearchParams
    (
        int? PatientId,
        int? DoctorId,
        DateTime? StartDate,
        DateTime? EndDate,
        string Sort,
        int PageSize,
        int PageNumber
    );
}
