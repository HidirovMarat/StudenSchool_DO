namespace Provider;

public interface IRepository
{
    public string NameTable { get; }

    public string GetColumns();

    public string Gets();

    public string Get();

    public void Create();

    public void Edite();

    public void Delete();
}
