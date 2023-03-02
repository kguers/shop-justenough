using JustEnough.Models;

namespace JustEnough.Interfaces;

public interface IPurchaseRepository 
{
    Task<ICollection<Purchase>> GetAll();
    Task<ICollection<Purchase>> GetCart(int purchaseId);
    Task<bool> CreateOrder(int productId, int customerId);
    Task<bool> AddToCart(int purchaseId, Product product);
    Task<bool> RemoveFromCart(int purchaseId, int productId);
    Task<bool> Checkout(int purchaseId);
    Task<bool> AdjustQuantity(int purchaseId, int productId);
    Task<bool> OrderExists(int id);
    Task<bool> Save();

}