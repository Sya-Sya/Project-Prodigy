using CollegeApp.Application.Interface;
using CollegeApp.Domain;
using CollegeApp.Domain.BookModels;
using CollegeApp.Domain.Helpers;
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

    #region Student CURD
    public BaseResponseModel<StudentCommonModel> AddStudent(StudentCommonModel student)
    {
        string query = @"INSERT INTO Students (Name, Age, Department) 
                     VALUES (@Name, @Age, @Department); 
                     SELECT CAST(SCOPE_IDENTITY() AS int);";

        try
        {
            int newStudentId = _dbConnection.ExecuteScalar<int>(query, student);
            student.StudentId = newStudentId.ToString();

            return ResponseFactory.Success(student, $"Student '{student.FullName}' was successfully added with ID {newStudentId}.");
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<StudentCommonModel>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<StudentCommonModel>(ex.Message);
        }
    }
    public BaseResponseModel<StudentCommonModel> UpdateStudent(StudentCommonModel student)
    {
        string query = "UPDATE Student SET FullName = @FullName, Email = @Email WHERE StudentId = @StudentId";
        string mesage = "";
        try
        {
            int rowsAffected = _dbConnection.Execute(query, student);

            if (rowsAffected > 0)
            {
                mesage = $"Student with Name {student.FullName} was successfully deleted.";
                return ResponseFactory.Success<StudentCommonModel>(student, mesage);
            }
            else
            {
                mesage = $"No student found with Name {student.FullName}.";
                return ResponseFactory.Success<StudentCommonModel>(student, mesage);
            }
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<StudentCommonModel>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<StudentCommonModel>(ex.Message);
        }
    }
    public BaseResponseModel<IEnumerable<StudentCommonModel>> GetAllStudents()
    {
        string query = "SELECT * FROM Student";

        try
        {
            var students = _dbConnection.Query<StudentCommonModel>(query).ToList();
            return ResponseFactory.SuccessList(students);
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<IEnumerable<StudentCommonModel>>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<IEnumerable<StudentCommonModel>>(ex.Message);
        }
    }
    public BaseResponseModel<StudentCommonModel> GetStudentById(int id)
    {
        string query = "SELECT * FROM Student WHERE StudentId = @Id";
        try
        {
            var student = _dbConnection.QuerySingleOrDefault<StudentCommonModel>(query, new { Id = id });
            return ResponseFactory.Success(student);
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<StudentCommonModel>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<StudentCommonModel>(ex.Message);
        }
    }
    public BaseResponseModel<StudentCommonModel> DeleteStudent(int id)
    {
        StudentCommonModel SCM = new StudentCommonModel();
        string query = "DELETE FROM Student WHERE StudentId = @Id";
        string mesage = "";
        try
        {
            int rowsAffected = _dbConnection.Execute(query, new { Id = id });

            if (rowsAffected > 0)
            {
                mesage = $"Student with ID {id} was successfully deleted.";
                return ResponseFactory.Success<StudentCommonModel>(SCM, mesage);
            }
            else
            {
                mesage = $"No student found with ID {id}.";
                return ResponseFactory.Success<StudentCommonModel>(SCM, mesage);

            }
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<StudentCommonModel>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<StudentCommonModel>(ex.Message);
        }
    }
    #endregion

    #region Using Stored Procedure 
    //public string DeleteStudent(int id)
    //{
    //    try
    //    {
    //        string spName = "DeleteStudent";
    //        var message = _dbConnection.QueryFirstOrDefault<string>(
    //            spName,
    //            new { StudentId = id },
    //            commandType: CommandType.StoredProcedure
    //        );

    //        return message ?? "No response from stored procedure.";
    //    }
    //    catch (SqlException sqlEx)
    //    {
    //        return $"SQL Error: {sqlEx.Message}";
    //    }
    //    catch (Exception ex)
    //    {
    //        return $"Error: {ex.Message}";
    //    }
    //}
    #endregion
}