using JustEnough.Models;

namespace JustEnough.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    Task<Product> GetById(int id);
    Task<Product> GetByTitle(string title);
    Task<bool> Create(Product newProd);
    Task<bool> ProductExists(int prodId);
    Task<Product> GetTitleTrimLower(string title);
    Task<bool> Save();
}