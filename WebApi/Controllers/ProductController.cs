using AutoMapper;
using JustEnough.Dto;
using JustEnough.Models;
using JustEnough.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustEnough.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase 
{
    private readonly IProductRepository _productRepo;
    private readonly IMapper _map;
    public ProductController(IProductRepository productRepo, IMapper map)
    {
        _productRepo = productRepo;
        _map = map;
    }
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
    public async Task<IActionResult> GetAll()
    { 
        var taskProds = await _productRepo.GetAll();
        var prods = _map.Map<List<ProductDto>>(taskProds);

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(prods);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var exists = await _productRepo.ProductExists(id);
        if(!exists)
            return NotFound();
        
        var prod = _map.Map<ProductDto>(await _productRepo.GetById(id));

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(prod);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDto newProd)
    {
        if(newProd is null)
            return BadRequest(ModelState);

        var prods = await _productRepo.GetTitleTrimLower(newProd.Title);

        if(prods is not null)
        {
            ModelState.AddModelError("", "Product already exists!");
            return StatusCode(422, ModelState);
        }

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var prodMap = _map.Map<Product>(newProd);

        var prod = await _productRepo.Create(prodMap);

        if(!prod)
        {
            ModelState.AddModelError("", "Something went wrong saving model");
            return StatusCode(500, ModelState);
        }

        return Ok("Product created successfully");
    }
}