using JustEnough.Models;

namespace JustEnough.Interfaces;

public interface ICustomerRepository 
{
    Task<bool> Login(string username, string password);
    Task<bool> Register(Customer customer);
    Task<ICollection<Customer>> GetAll();
    Task<Customer> GetById(int id);
    Task<bool> CustomerExists(int id);
    Task<Customer> GetNameTrimLower(string uname);
    Task<bool> Save();

}