namespace Provider;

public interface IBaseRepository<T>
{
    public T Get(Guid id);

    public IQueryable<T> GetAll();

    public void Create(T entity);

    public void Edit(T entity);

    public void Delete(Guid id);
}
