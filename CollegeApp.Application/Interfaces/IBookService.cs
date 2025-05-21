using CollegeApp.Domain;
using CollegeApp.Domain.BookModels;

namespace CollegeApp.Application.Interface;
public interface IBookServices
{
    BaseResponseModel<BookCommonModel> AddBook(BookCommonModel book);
    BaseResponseModel<IEnumerable<BookCommonModel>> GetAllBooks();
    BaseResponseModel<BookCommonModel> GetBookById(int id);
    BaseResponseModel<BookCommonModel> DeleteBook(int id);
    BaseResponseModel<BookCommonModel> UpdateBook(BookCommonModel book);
}