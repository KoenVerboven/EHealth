using System.ComponentModel.DataAnnotations;

namespace VKmfSoft_EHealth_API.Models.Domain.Other
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }
        
        //todo rijksregisternummer unique

        [Required(ErrorMessage = "LastName is required.")]
        [StringLength(40, ErrorMessage = "LastName cannot longer than 40 characters")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [StringLength(40, ErrorMessage = "FirstName cannot longer than 40 characters")]
        public required string FirstName { get; set; }
        
        [StringLength(40, ErrorMessage = "MiddleName cannot longer than 40 characters")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "DateOfBirth is required.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public required byte Gender { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public required string Address { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required.")]
        public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(45, ErrorMessage = "Email cannot longer than 45 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }

        public int FirstLanguageID { get; set; }

        public byte[]? Photo { get; set; }//todo add photo

        public DateTime CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
