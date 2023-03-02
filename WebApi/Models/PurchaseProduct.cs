using System.ComponentModel.DataAnnotations;

namespace JustEnough.Models;

public class PurchaseProduct {
    public int PurchaseId { get; set; }
    public int ProductId { get; set; }
    public Purchase? Purchase { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
}