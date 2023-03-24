using System.Linq.Expressions;


namespace ASP.Repository
{
    public class InMemoryRepository<T> : IRepositoryService<T> where T : class, IEntity<Guid>
    {
        protected static List<T> _set = new List<T>();
        public virtual IQueryable<T> GetAllRecords()
        {
            return _set.AsQueryable();
        }
        public virtual T GetSingle(Guid id)
        {
            var result = _set.FirstOrDefault(r => r.Id == id);
            return result; ;
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _set.AsQueryable().Where(predicate);
            return query;
        }
        public virtual RepositoryServiceResult Add(T o)
        {
            _set.Add(o);
            return RepositoryServiceResult.CommonResults["OK"];
        }
        public virtual RepositoryServiceResult Delete(T obj)
        {
            var toDelete = _set.SingleOrDefault(r => r.Id == obj.Id);
            if (toDelete != null)
                _set.Remove(toDelete);
            return RepositoryServiceResult.CommonResults["OK"];
        }
        public virtual RepositoryServiceResult Edit(T obj)
        {
            var toUpdate = _set.SingleOrDefault(r => r.Id == obj.Id);

            return RepositoryServiceResult.CommonResults["OK"];
        }

        public RepositoryServiceResult Save()
        {
            return RepositoryServiceResult.CommonResults["OK"];
        }
    }
}