using CollegeApp.Application.Interface;
using CollegeApp.Domain;
using CollegeApp.Domain.BookModels;

namespace CollegeApp.Infrastructure.Services;
public class BookService : IBookService
{
    public async Task<BookCommonModel> CreateAsync(BookCommonModel input)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<BookCommonModel> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResult<BookCommonModel>> GetListAsync(BookFilter input)
    {
        throw new NotImplementedException();
    }

    public async Task<BookCommonModel> UpdateAsync(Guid id, BookCommonModel input)
    {
        throw new NotImplementedException();
    }
}
