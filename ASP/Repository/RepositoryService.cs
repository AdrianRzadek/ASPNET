using ASP.Repository;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Principal;
namespace ASP.Repository
{
    public class RepositoryService<T> : IRepositoryService<T> where T : class, IEntity<Guid>
    {
        

        protected DbContext _context;
        protected DbSet<T> _set;

        public RepositoryService(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual RepositoryServiceResult Add(T entity)
        {
            RepositoryServiceResult result = new RepositoryServiceResult();
            try
            {
                _set.Add(entity);
                result = Save();
            }
            catch (Exception e)
            {
                result.Result = ServiceResultStatus.Error;
                result.Messages.Add(e.Message);
            }

            return result;
        }
        public virtual RepositoryServiceResult Delete(T entity)
        {
            RepositoryServiceResult result = new RepositoryServiceResult();
            try
            {
                _set.Remove(entity);
                result = Save();
            }
            catch (Exception e)
            {
                result.Result = ServiceResultStatus.Error;
                result.Messages.Add(e.Message);
            }
            return result;
        }

        public virtual RepositoryServiceResult Edit(T entity)
        {
            RepositoryServiceResult result = new RepositoryServiceResult();
            try
            {
                _context.Entry(entity).State = EntityState.Modified;

                result = Save();
            }
            catch (Exception e)
            {
                result.Result = ServiceResultStatus.Error;
                result.Messages.Add(e.Message);
            }
            return result;
        }


        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _set.Where(predicate);
            return query;
        }

        public IQueryable<T> GetAllRecords()
        {
            return _set;
        }
        public virtual T GetSingle(Guid id)
        {

            var result = _set.FirstOrDefault(r => r.Id == id);

            return result; ;
        }
        public virtual RepositoryServiceResult Save()
        {
            RepositoryServiceResult result = new RepositoryServiceResult();
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                result.Result = ServiceResultStatus.Error;
                result.Messages.Add(e.Message);
            }
            return result;

        }
    }
}