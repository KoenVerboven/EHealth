namespace VKmfSoft_EHealth_API.Specifications
{
    public record PatientSearchParams
    (
        string? Lastname,
        string? Firstname,
        string? Email,
        string Sort,
        int PageSize,
        int PageNumber
    );
}
