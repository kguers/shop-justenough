using System.ComponentModel.DataAnnotations;

namespace JustEnough.Dto;

public class PurchaseDto
{
    public int Id { get; set; }

    public DateTime Date { get; set; }
    public bool CheckedOut { get; set; } = false;
    public decimal Total { get; set; } = 0.0m;
    
}