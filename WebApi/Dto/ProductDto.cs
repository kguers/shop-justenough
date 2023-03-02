using System.ComponentModel.DataAnnotations;

namespace JustEnough.Dto;

public class ProductDto
{
    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }

    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public byte[]? Image { get; set; }

    [Required]
    public decimal Price { get; set; }
    public decimal Rating { get; set; }
    public bool InStock { get; set; }
    public string Brand { get; set; } = string.Empty;

}