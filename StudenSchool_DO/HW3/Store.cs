using Microsoft.Data.SqlClient;

namespace HW3;

public abstract class Store
{
    protected const string ConnectionString = @"Server=localhost\sqlexpress;Database=Store;Trusted_Connection=True;Encrypt=False;";
}
