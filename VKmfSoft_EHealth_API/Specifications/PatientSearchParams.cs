namespace VKmfSoft_EHealth_API.Specifications
{
    public record PatientSearchParams
    (
        string? Lastname,
        string? Firstname,
        string? Email,
        DateOnly? DateOfBirth,
        string Sort,
        int PageSize,
        int PageNumber
    );
}
