using JustEnough.Data;
using JustEnough.Models;
using JustEnough.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustEnough.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<bool> CustomerExists(int customerId)
    {
        return await _context.Customers.AnyAsync(c => c.Id == customerId);
    }

    public async Task<ICollection<Customer>> GetAll()
    {
        return await _context.Customers
                    .OrderBy(c => c.Id)
                    .AsNoTracking()
                    .ToListAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _context.Customers.
                    Where(c => c.Id == id)
                    .FirstOrDefaultAsync();
    }

    public async Task<Customer> GetNameTrimLower(string uname)
    {
        return await _context.Customers
            .Where(c => c.UserName.Trim().ToLower() == uname.Trim().ToLower())
            .FirstOrDefaultAsync();
    }

    public async Task<bool> Login(string username, string password)
    {
        var customer = await GetNameTrimLower(username);

        if(customer is null)
            throw new ArgumentException("Username was not found");


        if(customer.Password.Equals(password))
            return true;
        else
            return false;  
    }

    public async Task<bool> Register(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        return await Save();
    }

    public async Task<bool> Save()
    {
        var saved = await _context.SaveChangesAsync();
        return saved > 0 ? true : false;
    }
}