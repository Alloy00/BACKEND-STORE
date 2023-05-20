using Microsoft.EntityFrameworkCore;
using Mulungu.Loja.Domain.Contracts;
using Mulungu.Loja.Domain.Entities;

namespace Mulungu.Store.Domain.Service.Impl;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbContext _dbContext;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _productRepository = unitOfWork.ProductRepository;
        _unitOfWork = unitOfWork;
    }

    public Product CreateProduct(Product prod)
    {
        // Map the DTO to your domain entity or create a new entity instance
        var product = new Product
        {
            Id = prod.Id, // Generate a new GUID for the product
            Name = prod.Name,
            Price = prod.Price
        };
        return product;
    }

    public void SaveProduct(Product prod)
    {
        /*var test = prod;
        Console.WriteLine(prod);*/
        var entity = CreateProduct(prod);
        _productRepository.Save(entity);
       /* try
        {
            _dbContext.Entry(entity).State = EntityState.Added;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            Console.WriteLine(ex.Message);
        }*/

       /* try
        {
            _unitOfWork.Commit();
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            Console.WriteLine(ex.Message);
        }*/
    }

    /*public void CreateProduct(Product prod)
    {
        // Map the DTO to your domain entity or create a new entity instance
        var product = new Product
        {
            Id = Guid.NewGuid(), // Generate a new GUID for the product
            Name = prod.Name,
            Price = prod.Price
        };

        // Save the product to the database using the repository
        _productRepository.Save(product);
        
        _unitOfWork.Commit();

        // Return a response indicating success
    }*/
}