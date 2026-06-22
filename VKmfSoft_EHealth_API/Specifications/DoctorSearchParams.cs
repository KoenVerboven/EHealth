namespace VKmfSoft_EHealth_API.Specifications
{
    public record DoctorSearchParams
    (
        string? Lastname,
        string? Firstname,
        string? Email,
        int? Specialization,
        string Sort,
        int PageSize,
        int PageNumber
    );
    
}
