using AutoMapper;
using JustEnough.Dto;
using JustEnough.Models;
using JustEnough.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustEnough.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PurchaseController : ControllerBase 
{
    private readonly IPurchaseRepository _repo;
    private readonly IMapper _map;
    public PurchaseController(IPurchaseRepository repo, IMapper map)
    {
        _repo = repo;
        _map = map;
    }
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Purchase>))]
    public async Task<IActionResult> GetAll()
    { 
        var taskPurchases = await _repo.GetAll();
        var purchases = _map.Map<List<PurchaseDto>>(taskPurchases);

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(purchases);
    }
}