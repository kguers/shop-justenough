using System.ComponentModel.DataAnnotations;

namespace JustEnough.Dto;
public class CustomerDto
{
    public int Id { get; set; }

    [Required, MinLength(4), MaxLength(20)]
    public string? UserName { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    [Required, EmailAddress]
    public string? Email { get; set; }
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    [RegularExpression("^\\d{5}")]
    public string ZipCode { get; set; } = string.Empty;
}