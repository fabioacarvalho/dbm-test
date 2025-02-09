using Microsoft.AspNetCore.Mvc;
using Dbm.Api.Products.Dtos;
using Dbm.Api.Products.Services;

namespace Dbm.Api.Products.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet(Name = "FindAllProducts")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<ProductResponse>))]
    public IActionResult FindAll()
    {
        var body = _productService.FindAll();
        return Ok(body);
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        var body = _productService.FindById(id);
        return Ok(body);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductRequest product)
    {
        var body = _productService.Create(product);
        return CreatedAtAction(nameof(FindById), new { id = body.Id }, body);
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] ProductRequest product)
    {
        var body = _productService.Update(id, product);
        return Ok(body);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _productService.DeleteById(id);
        return NoContent();
    }
}