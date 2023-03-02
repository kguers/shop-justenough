using JustEnough.Models;
using JustEnough.Data;
using JustEnough.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustEnough.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _context.Products
                    .OrderBy(p => p.Id)
                    .AsNoTracking()
                    .ToListAsync();
    }

    public async Task<Product> GetById(int id)
    {
        var prod = await _context.Products
        .Where(p => p.Id == id)
        .AsNoTracking()
        .FirstOrDefaultAsync();

        return prod;
    }

    public async Task<Product> GetByTitle(string title)
    {
        var prod = await _context.Products
        .Where(p => p.Title == title)
        .AsNoTracking()
        .FirstOrDefaultAsync();

        return prod;
    }

    public async Task<bool> Create(Product newProd)
    {
        await _context.Products.AddAsync(newProd);
        return await Save();
    }

    public async Task<bool> ProductExists(int prodId)
    {
        return await _context.Products.AnyAsync(p => p.Id == prodId);
    }

    public async Task<Product> GetTitleTrimLower(string title)
    {
        return await _context.Products
            .Where(t => t.Title.Trim().ToLower() == title.Trim().ToLower())
            .FirstOrDefaultAsync();
    }

    public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
}