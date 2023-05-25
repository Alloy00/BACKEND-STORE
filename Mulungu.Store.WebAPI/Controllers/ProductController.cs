using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mulungu.Loja.Domain.Contracts;
using Mulungu.Loja.Domain.Entities;
using Mulungu.Store.Domain.Service.Impl;

namespace Mulungu.Store.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    private readonly IUnitOfWork _unitOfWork;
    
    public ProductController(IUnitOfWork unitOfWork, ProductService productService)
    {
        _unitOfWork = unitOfWork;
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productService.FindProducts();
        return Ok(products);
    }
    
    [HttpPost]
    [Route("/Add")]
    public IActionResult CreateProduct(Product prod)
    {
        _productService.SaveProduct(prod);
        //_unitOfWork.Commit();
        return Ok($"Product created successfully {prod.Name} - {prod.Id} - {prod.Price}");
    }
    
    [HttpDelete]
    [Route("/Delete/{id}")]
    public IActionResult DeleteProduct(Guid id)
    {
        _productService.DeleteProduct(id);

        return Ok($"Product with ID {id} deleted successfully");
    }
    [HttpPut]
    [Route("/Update/{id}")]
    public IActionResult UpdateProduct(Product product)
    {
        _productService.UpdateProduct(product);

        return Ok($"Product with ID {product.Id} updated successfully");
    }
}