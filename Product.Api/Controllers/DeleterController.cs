using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Api.Services;

namespace Product.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DeleterController : ControllerBase
{
    private readonly IAsyncProductService _service;

    public DeleterController(IAsyncProductService service)
    {
        _service = service;
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAllProductsAsync()
    {
        var product = await _service.DeleteAllProductsAsync();
        return Ok(product);
    }
}