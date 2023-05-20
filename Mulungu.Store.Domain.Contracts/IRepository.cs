using System.Linq.Expressions;
using Mulungu.Loja.Domain.Entities;

namespace Mulungu.Loja.Domain.Contracts;

public interface IRepository<T> where T : BaseEntity
{
    T? FindById(Guid Id);
    IList<T> FindBy(Expression<Func<T, bool>> predicate);
    IList<T> FindAll();
    T Save(T objectToSave);
    void Delete(Guid Id);
    
    
}