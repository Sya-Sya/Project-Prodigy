using CollegeApp.Application.Interface;
using CollegeApp.Domain.BookModels;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookServices _bookServices;

    public BookController(IBookServices bookServices)
    {
        _bookServices = bookServices;
    }

    [HttpPost("addBook")]
    public IActionResult AddBook(BookCommonModel model)
    {
        var books = _bookServices.AddBook(model);
        return Ok(books);
    }

    [HttpGet("books")]
    public IActionResult GetBookList()
    {
        var books = _bookServices.GetAllBooks();
        return Ok(books);
    }

    [HttpPost("GetById")]
    public IActionResult GetSpeceficBook(int id)
    {
        var books = _bookServices.GetBookById(id);
        return Ok(books);
    }

    [HttpPost("delete")]
    public IActionResult DeleteBook(int id)
    {
        var books = _bookServices.DeleteBook(id);
        return Ok(books);
    }

    [HttpPost("update")]
    public IActionResult Updatedata(BookCommonModel model)
    {
        var agent = _bookServices.UpdateBook(model);
        return Ok(agent);
    }
}

