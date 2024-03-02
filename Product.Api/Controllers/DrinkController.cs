using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Data;
using Product.Api.DTOs;
using Product.Api.Services;

namespace Product.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DrinkController(ProductContext context, IMapper mapper) : ControllerBase
{
    private readonly IAsyncProductService _service = new ProductService(context);

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
        var products = await _service.GetProductsAsync();

        return Ok(mapper.Map<IEnumerable<ProductDto>>(products));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _service.GetProductByIdAsync(id);
        if (product is null)
        {
            return NotFound();
        }

        return Ok(mapper.Map<ProductDto>(product));
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] AddProductRequestDto request)
    {
        var product = mapper.Map<Models.Product>(request);
        var newProduct = await _service.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, mapper.Map<ProductDto>(newProduct));
    }
}