using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Data;
using Product.Api.DTOs;
using Product.Api.Models;
using Product.Api.Services;

namespace Product.Api.Controllers;

[Authorize]
[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class VegetableController(ProductContext context, IMapper mapper) : ControllerBase
{
    private readonly IAsyncProductService _service = new ProductService(context);

    [HttpGet]
    public async Task<IActionResult> GetVegetablesAsync()
    {
        var vegetables = await _service.GetVegetablesAsync();

        return Ok(mapper.Map<IEnumerable<ProductDto>>(vegetables));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetVegetableById(Guid id)
    {
        var vegetable = await _service.GetProductByIdAsync(id);
        if (vegetable is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<ProductDto>(vegetable));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateVegetable([FromBody] AddProductRequestDto request)
    {
        var vegetable = mapper.Map<Vegetables>(request);
        var newVegetable = await _service.CreateVegetableAsync(vegetable);
        return CreatedAtAction(nameof(GetVegetableById), new { id = newVegetable.Id }, mapper.Map<ProductDto>(newVegetable));
    }
}