using CollegeApp.Domain;
using CollegeApp.Domain.BookModels;

namespace CollegeApp.Application.Interface;
public interface IBookService
{
    Task<PagedResult<BookCommonModel>> GetListAsync(BookFilter input);
    Task<BookCommonModel> GetAsync(Guid id);
    Task<BookCommonModel> CreateAsync(BookCommonModel input);
    Task<BookCommonModel> UpdateAsync(Guid id, BookCommonModel input);
    Task DeleteAsync(Guid id);
}