using DbModels;

namespace Provider;

public interface IRepository
{
    public T Get<T>();

    public T Get<T>(Guid id);

    public void Create<T>(T entity);

    public void Edit<T>(T entity);

    public void Delete(Guid id);

    public bool IsData(Guid id);
}
