using CollegeApp.Application.Interface;
using CollegeApp.Domain;
using CollegeApp.Domain.BookModels;
using CollegeApp.Domain.Helpers;
using CollegeApp.Domain.BookModels;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CollegeApp.Infrastructure.Services;
public class BookService : IBookServices
{
    private readonly IDbConnection _dbConnection;

    public BookService(
        IDbConnection dbConnection
        )
    {
        _dbConnection = dbConnection;
    }

    public BaseResponseModel<BookCommonModel> AddBook(BookCommonModel book)
    {
        string query = @"INSERT INTO Books 
                            (Title, ISBN, Description, PublicationDate, Language, Price, Stock, Popularity, PublisherID, FormatID) 
                         VALUES 
                            (@Title, @ISBN, @Description, @PublicationDate, @Language, @Price, @Stock, @Popularity, @PublisherID, @FormatID); 
                         SELECT CAST(SCOPE_IDENTITY() AS int);";

        try
        {
            int newBookId = _dbConnection.ExecuteScalar<int>(query, book);
            book.BookId = newBookId;

            return ResponseFactory.Success(book, $"Book '{book.Title}' was successfully added with ID {newBookId}.");
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<BookCommonModel>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<BookCommonModel>(ex.Message);
        }
    }

    public BaseResponseModel<BookCommonModel> DeleteBook(int id)
    {
        BookCommonModel SCM = new BookCommonModel();
        string query = "DELETE FROM Books WHERE BookID = @Id";
        string mesage = "";
        try
        {
            int rowsAffected = _dbConnection.Execute(query, new { Id = id });

            if (rowsAffected > 0)
            {
                mesage = $"Book with ID {id} was successfully deleted.";
                return ResponseFactory.Success<BookCommonModel>(SCM, mesage);
            }
            else
            {
                mesage = $"No book found with ID {id}.";
                return ResponseFactory.Success<BookCommonModel>(SCM, mesage);

            }
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<BookCommonModel>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<BookCommonModel>(ex.Message);
        }
    }

    public BaseResponseModel<IEnumerable<BookCommonModel>> GetAllBooks()
    {
        string query = "SELECT * FROM Books";

        try
        {
            var books = _dbConnection.Query<BookCommonModel>(query).ToList();
            return ResponseFactory.SuccessList(books);
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<IEnumerable<BookCommonModel>>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<IEnumerable<BookCommonModel>>(ex.Message);
        }
    }

    public BaseResponseModel<BookCommonModel> GetBookById(int id)
    {
        string query = "SELECT * FROM Books WHERE BookID = @Id";
        try
        {
            var book = _dbConnection.QuerySingleOrDefault<BookCommonModel>(query, new { Id = id });
            return ResponseFactory.Success(book);
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<BookCommonModel>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<BookCommonModel>(ex.Message);
        }
    }

    public BaseResponseModel<BookCommonModel> UpdateBook(BookCommonModel book)
    {
        string query = "UPDATE Book SET FullName = @FullName, Email = @Email WHERE BookId = @BookId";
        string mesage = "";
        try
        {
            int rowsAffected = _dbConnection.Execute(query, book);

            if (rowsAffected > 0)
            {
                mesage = $"Book with Name {book.Title} was successfully deleted.";
                return ResponseFactory.Success<BookCommonModel>(book, mesage);
            }
            else
            {
                mesage = $"No book found with Name {book.Title}.";
                return ResponseFactory.Success<BookCommonModel>(book, mesage);
            }
        }
        catch (SqlException sqlEx)
        {
            return ResponseFactory.SqlError<BookCommonModel>(sqlEx.Message);
        }
        catch (Exception ex)
        {
            return ResponseFactory.Error<BookCommonModel>(ex.Message);
        }
    }
}
