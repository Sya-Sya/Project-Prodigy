//using CollegeApp.Application.Interface;
//using CollegeApp.Domain;
//using CollegeApp.Domain.BookModels;
//using Dapper;
//using Microsoft.Extensions.Logging;
//using System.Data;

//namespace CollegeApp.Infrastructure.Services;
//public class BookService : IBookService
//{
//    private readonly IDbConnection _dbConnection;

//    public BookService(IDbConnection dbConnection,
//        ILogger logger)
//    {
//        _dbConnection = dbConnection;
//    }
//    public async Task<int> CreateAsync(BookCommonModel input)
//    {
//        var query = "INSERT INTO Books (Name) VALUES (@Name)";

//        var book = await _dbConnection.ExecuteScalarAsync<int>(query, input);

//        return book;

//        throw new NotImplementedException();
//    }

//    public async Task DeleteAsync(Guid id)
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<BookCommonModel> GetAsync(Guid id)
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<PagedResult<BookCommonModel>> GetListAsync(BookFilter input)
//    {
//        throw new NotImplementedException();
//    }

//    public async Task<BookCommonModel> UpdateAsync(Guid id, BookCommonModel input)
//    {
//        throw new NotImplementedException();
//    }
//}
