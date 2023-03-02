using System.ComponentModel.DataAnnotations;

namespace JustEnough.Models;

public class Purchase 
{
    public int Id { get; set; }

    [Required]
    public Customer Customer { get; set; }
    public DateTime Date { get; set; }
    public bool CheckedOut { get; set; } = false;
    public decimal Total { get; set; } = 0.0m;
    public List<PurchaseProduct>? PurchaseProducts { get; set;}

}