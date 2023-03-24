namespace ASP.Repository
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

}