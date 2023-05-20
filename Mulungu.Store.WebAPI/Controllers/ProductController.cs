using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mulungu.Loja.Domain.Contracts;
using Mulungu.Loja.Domain.Entities;
using Mulungu.Loja.Infra.Repositories.Impl.Context;
using Mulungu.Store.Domain.Service.Impl;

namespace Mulungu.Store.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]


public class ProductController : ControllerBase
{
    private readonly DbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ProductService _productService;
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productRepository.FindAll();
        return Ok(products);
    }
    
    [HttpPost]
    [Route("/Add")]
    public IActionResult CreateProduct(Product prod)
    {
        // Map the DTO to your domain entity or create a new entity instance
            var product = new Product
            {
                Id = prod.Id, // Generate a new GUID for the product
                Name = prod.Name,
                Price = prod.Price
            };

            _dbContext.Entry(product).State = EntityState.Added;
            try
        {
            _unitOfWork.Commit();
            return Ok("Product created successfully");
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            Console.WriteLine(ex.Message);
            return StatusCode(500, "An error occurred while saving the product");
        }
    }

    
    /*public IActionResult CreateProduct(Product prod)
    {
        _productService.SaveProduct(prod);
        
        
        // Map the DTO to your domain entity or create a new entity instance
        /*var product = new Product
        {
            Id = Guid.NewGuid(), // Generate a new GUID for the product
            Name = prod.Name,
            Price = prod.Price
        };

        // Save the product to the database using the repository
        //_productRepository.Save(prod);
        

        // Return a response indicating success
        return Ok("Product created successfully");
    }*/
}