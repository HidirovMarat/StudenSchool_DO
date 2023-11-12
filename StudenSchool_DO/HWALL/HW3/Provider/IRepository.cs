namespace Provider;

public interface IRepository
{
    public string NameTable { get; }

    public string GetColumns();

    public string GetAll();

    public string Get();

    public void Create();

    public void Edit();

    public void Delete();
}
