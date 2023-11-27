using Microsoft.Data.SqlClient;

namespace Provider;

public class CourseRepository
{
    private const string CONNECTION_STRING = @"Server=localhost\sqlexpress;Database=Store;Trusted_Connection=True;Encrypt=False;";
    private const string ID_NAME = "CourseID";
    private const string GET_ALL_SQL = $"SELECT * FROM {TABLE_NAME}";
    private const string GET_SQL = $"SELECT * FROM {TABLE_NAME} WHERE {ID_NAME} = '{{0}}' ";
    private const string CREATE_SQL = $"INSERT INTO {TABLE_NAME} ({ID_NAME}, Title) VALUES ('{{0}}', '{{1}}') ";
    private const string EDIT_SQL = $"UPDATE {TABLE_NAME} SET Title = '{{1}}' WHERE {ID_NAME} = '{{0}}' ";
    private const string DELETE_SQL = $"DELETE FROM {TABLE_NAME} WHERE {ID_NAME} = '{{0}}' ";

    public const string TABLE_NAME = "Courses";

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
            result += $"{sqlDataReader["CourseID"]} {sqlDataReader["Title"]}\n";
        }

        return result;
    }

    public string Get(Guid courseID)
    {
        using var sqlConnection = new SqlConnection(CONNECTION_STRING);

        var formatedSQL = string.Format(GET_SQL, courseID);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();

        var result = string.Empty;

        using var sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            result = $"{sqlDataReader["CourseID"]} {sqlDataReader["Title"]}\n";
        }

        return result;
    }

    public void Create(Guid courseID, string title)
    {
        using var sqlConnection = new SqlConnection(CONNECTION_STRING);

        var formatedSQL = string.Format(CREATE_SQL, courseID.ToString(), title);

        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();

        sqlCommand.ExecuteNonQuery();
    }

    public void Edit(Guid courseID, string title)
    {
        using var sqlConnection = new SqlConnection(CONNECTION_STRING);

        var formatedSQL = string.Format(EDIT_SQL, courseID, title);

        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();

        sqlCommand.ExecuteNonQuery();
    }

    public void Delete(Guid courseID)
    {
        using var sqlConnection = new SqlConnection(CONNECTION_STRING);

        var formatedSQL = string.Format(DELETE_SQL, courseID);

        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();

        sqlCommand.ExecuteNonQuery();
    }
}