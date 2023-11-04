﻿using HW2;
using Microsoft.Data.SqlClient;

namespace HW3;

public class Courses : Store, IRepository
{
    private const string ID_NAME = "CourseID";
    private const string GETS_SQL = $"SELECT * FROM {TABLE_NAME}";
    private const string GET_SQL = $"SELECT * FROM {TABLE_NAME} WHERE {ID_NAME} = '{{0}}' ";
    private const string CREATE_SQL = $"INSERT INTO {TABLE_NAME} ({ID_NAME}, Title) VALUES ('{{0}}', '{{1}}') ";
    private const string EDIT_SQL = $"UPDATE {TABLE_NAME} SET Title = '{{1}}' WHERE {ID_NAME} = '{{0}}' ";
    private const string DELETE_SQL = $"DELETE FROM {TABLE_NAME} WHERE {ID_NAME} = '{{0}}' ";

    public const string TABLE_NAME = "Courses";

    public string NameTable { get { return TABLE_NAME; }}

    public string GetsFromDB()
    {
        var result = string.Empty;

        using var sqlConnection = new SqlConnection(ConnectionString);

        var sqlCommand = new SqlCommand(GETS_SQL, sqlConnection);

        sqlConnection.Open();

        using var sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            result += sqlDataReader["CourseID"];
            result += " ";
            result += sqlDataReader["Title"];
            result += "\n";
        }

        return result;
    }

    public string GetFromDB(Guid courseID)
    {
        var result = string.Empty;

        using var sqlConnection = new SqlConnection(ConnectionString);

        var formatedSQL = string.Format(GET_SQL, courseID);
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();

        using var sqlDataReader = sqlCommand.ExecuteReader();
        while (sqlDataReader.Read())
        {
            result += sqlDataReader["CourseID"];
            result += " ";
            result += sqlDataReader["Title"];
            result += "\n";
        }

        return result;
    }

    public void CreateFromDB(Guid courseID, string title)
    {
        using var sqlConnection = new SqlConnection(ConnectionString);

        var formatedSQL = string.Format(CREATE_SQL, courseID.ToString(), title);

        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);
        
        sqlConnection.Open();

        sqlCommand.ExecuteNonQuery();
    }

    public void EditFromDB(Guid courseID, string title)
    {
        using var sqlConnection = new SqlConnection(ConnectionString);

        var formatedSQL = string.Format(EDIT_SQL, courseID, title);
        
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        
        sqlCommand.ExecuteNonQuery();
    }

    public void DeleteFromDB(Guid courseID)
    {
        using var sqlConnection = new SqlConnection(ConnectionString);

        var formatedSQL = string.Format(DELETE_SQL, courseID);
        
        var sqlCommand = new SqlCommand(formatedSQL, sqlConnection);

        sqlConnection.Open();
        
        sqlCommand.ExecuteNonQuery();
    }

    public string GetColumns()
    {
        return "Guid CoursesID, string Title";
    }

    public string Gets()
    {
        return GetsFromDB();
    }

    public string Get()
    {
        DesignedMenu.WriteServiceMessages("coursesID ");

        Guid coursesID = CorrectInput.GetGuid();

        return GetFromDB(coursesID);
    }

    public void Create()
    {
        DesignedMenu.WriteServiceMessages("coursesID ");

        Guid coursesID = CorrectInput.GetGuid();

        DesignedMenu.WriteServiceMessages("title ");

        string title = Console.ReadLine();

        CreateFromDB(coursesID, title);
    }

    public void Edite()
    {
        DesignedMenu.WriteServiceMessages("coursesID ");

        Guid coursesID = CorrectInput.GetGuid();

        DesignedMenu.WriteServiceMessages("title ");
        
        string title = Console.ReadLine();

        CreateFromDB(coursesID, title);
    }

    public void Delete()
    {
        DesignedMenu.WriteServiceMessages("coursesID ");

        Guid coursesID = CorrectInput.GetGuid();

        DeleteFromDB(coursesID);
    }
}