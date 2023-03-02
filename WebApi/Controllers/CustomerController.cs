using AutoMapper;
using JustEnough.Dto;
using JustEnough.Models;
using JustEnough.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustEnough.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase 
{
    private readonly ICustomerRepository _custRepo;
    private readonly IMapper _map;
    public CustomerController(ICustomerRepository custRepo, IMapper map)
    {
        _custRepo = custRepo;
        _map = map;
    }
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
    public async Task<IActionResult> GetAll()
    { 
        var taskCusts = await _custRepo.GetAll();
        var custs = _map.Map<List<CustomerDto>>(taskCusts);

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(custs);
    }

    [HttpGet("{customerId}")]
    [ProducesResponseType(200, Type = typeof(Customer))]
    public async Task<IActionResult> GetById(int customerId) 
    {
        var exists = await _custRepo.CustomerExists(customerId);

        if(!exists)
            return NotFound();

        var cust = _map.Map<CustomerDto>(await _custRepo.GetById(customerId));

        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(cust);
    }

    [HttpGet("login")]
    [ProducesResponseType(200, Type = typeof(Customer))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Login([FromQuery] string username, [FromQuery] string password)
    {
        if(username is null || password is null)
            return BadRequest();

        var account = await _custRepo.GetNameTrimLower(username);

        if(account is null)
            return NotFound();

        bool successful = false;
        try
        {
           successful = await _custRepo.Login(username, password);
        }
        catch(ArgumentException e)
        {
            return NotFound(e);
        }

        if(!successful)
            return Unauthorized();
        
        var customer = _map.Map<CustomerDto>(await _custRepo.GetNameTrimLower(username));
        if(customer is null)
        {
            ModelState.AddModelError("", "Something went wrong retrieving model");
            return StatusCode(500, ModelState);
        }
        return Ok(customer);
    }

    [HttpPost("register")]
    [ProducesResponseType(204, Type = typeof(int))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Register([FromBody] CustomerDto newCust)
    {
        if(newCust is null)
            return BadRequest();

        var customers = await _custRepo.GetNameTrimLower(newCust.UserName);

        if(customers is not null)
        {
            ModelState.AddModelError("", "Customer already exists!");
            return StatusCode(422, ModelState);
        }
            
        if(!ModelState.IsValid)
            return BadRequest();

        var customerMap = _map.Map<Customer>(newCust);
        var cust = await _custRepo.Register(customerMap);

        if(!cust)
        {
            ModelState.AddModelError("", "Something went wrong saving model");
            return StatusCode(500, ModelState);
        }

        //Now that customer is created, we can retrieve it, and return it to the client
        var customer = await _custRepo.GetNameTrimLower(customerMap.UserName);

        if(customer is null) 
        {
            ModelState.AddModelError("", "Something went wrong retrieving model");
            return StatusCode(500, ModelState);
        }
        return CreatedAtAction(nameof(_custRepo.Register), customer.Id);
    }


}