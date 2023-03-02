using JustEnough.Models;
using JustEnough.Data;
using JustEnough.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustEnough.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly DataContext _context;
    public PurchaseRepository(DataContext context)
    {
        _context = context;
    }

    public Task<bool> AddToCart(int purchaseId, Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AdjustQuantity(int purchaseId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Checkout(int purchaseId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateOrder(int productId, int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Purchase>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Purchase>> GetCart(int purchaseId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> OrderExists(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveFromCart(int purchaseId, int productId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Save()
    {
        throw new NotImplementedException();
    }
}