using Microsoft.Data.SqlClient;

namespace Provider;

public class StudentRepository
{
    private const string CONNECTION_STRING = @"Server=localhost\sqlexpress;Database=Store;Trusted_Connection=True;Encrypt=False;";
    private const string ID_NAME = "StudentID";
    private const string GET_ALL_SQL = $"SELECT * FROM {TABLE_NAME}";
    private const string GET_SQL = $"SELECT * FROM {TABLE_NAME} WHERE {ID_NAME} = '{{0}}' ";
    private const string CREATE_SQL = $"INSERT INTO {TABLE_NAME} ({ID_NAME}, Name, Age) VALUES ('{{0}}', '{{1}}', {{2}}) ";
    private const string EDIT_SQL = $"UPDATE {TABLE_NAME} SET Name = '{{1}}', Age = {{2}} WHERE {ID_NAME} = '{{0}}' ";
    private const string DELETE_SQL = $"DELETE FROM {TABLE_NAME} WHERE {ID_NAME} = '{{0}}' ";

    public const string TABLE_NAME = "Students";

    public string NameTable { get { return TABLE_NAME; } }

    public string GetAll()
    {
        using var sqlConnection = new SqlConnection(CONNECTION_STRING);

        var sqlCommand = new SqlCommand(GET_ALL_SQL, sqlConnection);

        sqlConnection.Open();

        var result = string.Empty;

        using var sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            result += $"{sqlDataReader[ID_NAME]} {sqlDataReader["Name"]} {sqlDataReader["Age"]}\n";
        }

        return result;
    }

    public string Get(Guid studentID)
    {
        var result = string.Empty;

        using var sqlConnection = new SqlConnection(CONNECTION_STRING);
        var formatedSQL = string.Format(GET_SQL, studentID);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        using var sqlDataReader = sqlCommand.ExecuteReader();

        while (sqlDataReader.Read())
        {
            result = $"{sqlDataReader[ID_NAME]} {sqlDataReader["Name"]} {sqlDataReader["Age"]}\n";
        }

        return result;
    }

    public void Create(Guid studentID, string name, int age)
    {
        using var sqlConnection = new SqlConnection(CONNECTION_STRING);
        var formatedSQL = string.Format(CREATE_SQL, studentID.ToString(), name, age);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
    }

    public void Edit(Guid studentID, string name, int age)
    {
        using var sqlConnection = new SqlConnection(CONNECTION_STRING);
        var formatedSQL = string.Format(EDIT_SQL, studentID, name, age);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
    }

    public void Delete(Guid studentID)
    {
        using var sqlConnection = new SqlConnection(CONNECTION_STRING);
        var formatedSQL = string.Format(DELETE_SQL, studentID);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
    }
}
