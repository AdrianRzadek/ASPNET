using System.Linq.Expressions;
using System.Security.Principal;


namespace ASP.Repository
{
    public interface IRepositoryService<T> where T : IEntity<Guid>
    {
        IQueryable<T> GetAllRecords();
        T GetSingle(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        RepositoryServiceResult Add(T entity);
        RepositoryServiceResult Delete(T entity);
        RepositoryServiceResult Edit(T entity);
        RepositoryServiceResult Save();
    }

}
