using WorkWithUser;
using Microsoft.Data.SqlClient;

namespace Provider;

public class Students : Store, IRepository
{
    private const string ID_NAME = "StudentID";
    private const string GET_ALL_SQL = $"SELECT * FROM {TABLE_NAME}";
    private const string GET_SQL = $"SELECT * FROM {TABLE_NAME} WHERE {ID_NAME} = '{{0}}' ";
    private const string CREATE_SQL = $"INSERT INTO {TABLE_NAME} ({ID_NAME}, Name, Age) VALUES ('{{0}}', '{{1}}', {{2}}) ";
    private const string EDIT_SQL = $"UPDATE {TABLE_NAME} SET Name = '{{1}}', Age = {{2}} WHERE {ID_NAME} = '{{0}}' ";
    private const string DELETE_SQL = $"DELETE FROM {TABLE_NAME} WHERE {ID_NAME} = '{{0}}' ";

    public const string TABLE_NAME = "Students";

    public string NameTable { get { return TABLE_NAME; } }

    public string GetAllFromDB()
    {
        var result = string.Empty;

        using var sqlConnection = new SqlConnection(ConnectionString);
        var sqlCommand = new SqlCommand(GET_ALL_SQL, sqlConnection);

        sqlConnection.Open();
        using var sqlDataReader = sqlCommand.ExecuteReader();

        while (sqlDataReader.Read())
        {
            result = $"{sqlDataReader[ID_NAME]} {sqlDataReader["Name"]} {sqlDataReader["Age"]}\n";
        }

        return result;
    }

    public string GetFromDB(Guid studentID)
    {
        var result = string.Empty;

        using var sqlConnection = new SqlConnection(ConnectionString);
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

    public void CreateFromDB(Guid studentID, string name, int age)
    {
        using var sqlConnection = new SqlConnection(ConnectionString);
        var formatedSQL = string.Format(CREATE_SQL, studentID.ToString(), name, age);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
    }

    public void EditeFromDB(Guid studentID, string name, int age)
    {
        using var sqlConnection = new SqlConnection(ConnectionString);
        var formatedSQL = string.Format(EDIT_SQL, studentID, name, age);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
    }

    public void DeleteFromDB(Guid studentID)
    {
        using var sqlConnection = new SqlConnection(ConnectionString);
        var formatedSQL = string.Format(DELETE_SQL, studentID);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
    }

    public string GetColumns()
    {
        return "Guid StudentID, string Name, int Age";
    }

    public string GetAll()
    {
        return GetAllFromDB();
    }

    public string Get()
    {
        DesignedMenu.WriteServiceMessages("studentsID ");

        Guid studentID = CorrectInput.GetGuidFromUser();

        return GetFromDB(studentID);
    }

    public void Create()
    {
        DesignedMenu.WriteServiceMessages("studentsID ");

        Guid studentID = CorrectInput.GetGuidFromUser();

        DesignedMenu.WriteServiceMessages("name ");

        string name = Console.ReadLine();

        DesignedMenu.WriteServiceMessages("age ");

        int age = CorrectInput.GetNumberFromUser(x => x > 0);

        CreateFromDB(studentID, name, age);
    }

    public void Edit()
    {
        DesignedMenu.WriteServiceMessages("studentsID ");

        Guid studentID = CorrectInput.GetGuidFromUser();

        DesignedMenu.WriteServiceMessages("name ");

        string name = Console.ReadLine();

        DesignedMenu.WriteServiceMessages("age ");

        int age = CorrectInput.GetNumberFromUser(x => x > 0);

        EditeFromDB(studentID, name, age);
    }

    public void Delete()
    {
        DesignedMenu.WriteServiceMessages("studentsID ");

        Guid studentID = CorrectInput.GetGuidFromUser();

        DeleteFromDB(studentID);
    }
}
