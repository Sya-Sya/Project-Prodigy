using CollegeApp.Application.Interface;
using CollegeApp.Domain;
using CollegeApp.Domain.BookModels;

namespace CollegeApp.Infrastructure.Services;
public class BookService : IBookService
{
    public Task<BookCommonModel> CreateAsync(BookCommonModel input)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<BookCommonModel> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<PagedResult<BookCommonModel>> GetListAsync(BookFilter input)
    {
        throw new NotImplementedException();
    }

    public Task<BookCommonModel> UpdateAsync(Guid id, BookCommonModel input)
    {
        throw new NotImplementedException();
    }
}
