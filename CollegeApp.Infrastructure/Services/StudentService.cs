using CollegeApp.Application.Interface;
using CollegeApp.Domain.BookModels;
using CollegeApp.Domain.StudentModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CollegeApp.Infrastructure.Services;

public class StudentService : IStudentServices
{
    private readonly IDbConnection _dbConnection;

    public StudentService(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public int AddStudent(StudentCommonModel student)
    {
        string query = "INSERT INTO Students (Name, Age, Department) VALUES (@Name, @Age, @Department); SELECT CAST(SCOPE_IDENTITY() as int);";
        try
        {
            return _dbConnection.ExecuteScalar<int>(query);
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine($"SQL Error: {sqlEx.Message}");
            return -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
            return -1;
        }
    }

    public int DeleteStudent(int id)
    {
        string query = "DELETE FROM Student WHERE StudentId = @Id";
        try
        {
            return _dbConnection.Execute(query, new { Id = id });
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine($"SQL Error: {sqlEx.Message}");
            return -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
            return -1;
        }
    }

    public IEnumerable<StudentCommonModel> GetAllStudents()
    {
        string query = "SELECT * FROM Student";

        try
        {
            return _dbConnection.Query<StudentCommonModel>(query).ToList();
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine($"SQL Error: {sqlEx.Message}");
            return Enumerable.Empty<StudentCommonModel>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
            return Enumerable.Empty<StudentCommonModel>();
        }
    }

    public StudentCommonModel GetStudentById(int id)
    {
        string query = "SELECT * FROM Student WHERE StudentId = @Id";
        try
        {
            return _dbConnection.QuerySingleOrDefault<StudentCommonModel>(query, new { Id = id });
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine($"SQL Error: {sqlEx.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
            return null;
        }
    }

    public int UpdateStudent(StudentCommonModel student)
    {
        string query = "UPDATE Student SET FullName = @FullName, Email = @Email WHERE StudentId = @StudentId";
        try
        {
            return _dbConnection.Execute(query, student);
        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine($"SQL Error: {sqlEx.Message}");
            return -1;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"General Error: {ex.Message}");
            return -1;
        }        
    }
}