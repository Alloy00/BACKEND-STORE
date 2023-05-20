using Mulungu.Loja.Domain.Contracts;
using Mulungu.Loja.Domain.Entities;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Mulungu.Loja.Infra.Repositories.Impl.Context;

namespace Mulungu.Loja.Infra.Repositories.Impl.Repositories;

public abstract class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;
    private readonly DbContext _dbContext;

    protected Repository(StoreDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public T? FindById(Guid Id)
    {
        return _dbSet.FirstOrDefault(e => e.Id == Id);
    }

    public IList<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).ToList();
    }

    public IList<T> FindAll()
    {
        return _dbSet.ToList();
    }

    public T Save(T objectToSave)
    {
        /*var entity = _dbSet.Attach(objectToSave).Entity;
        if (entity != null)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
        }
        try
        {
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            Console.WriteLine(ex.Message);
        }*/
        _dbSet.Attach(objectToSave);
        return objectToSave;
        //return _dbSet.Attach(objectToSave).Entity;
        // Inserir save aqui (não tenho certeza onde)
    }

    public void Delete(Guid Id)
    {
        var entity = _dbSet.FirstOrDefault(e => e.Id == Id);
        if (entity != null)
        {
            _dbSet.Attach(entity).State = EntityState.Deleted;
        }
        _dbContext.SaveChanges();
    }
}