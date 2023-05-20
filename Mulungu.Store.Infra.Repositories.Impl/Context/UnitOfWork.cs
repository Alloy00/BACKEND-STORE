using Microsoft.EntityFrameworkCore;
using Mulungu.Loja.Domain.Contracts;
using Mulungu.Loja.Infra.Repositories.Impl.Repositories;

namespace Mulungu.Loja.Infra.Repositories.Impl.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly DbContext _dbContext;

    //private IProductRepository _productRepository = new ProductRepository(_dbContext);
    
    public IProductRepository ProductRepository { get ; }
    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}