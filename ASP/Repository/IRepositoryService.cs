using System.Linq.Expressions;
using System.Security.Principal;


namespace ASP.Repository
{
    public interface IRepositoryService<T> where T : IEntity<Guid>
    {
        IQueryable<T> GetAllRecords();
        T GetSingle(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        ServiceResult Add(T entity);
        ServiceResult Delete(T entity);
       // ServiceResult Edit(T entity);
        //ServiceResult Save();
    }

}
