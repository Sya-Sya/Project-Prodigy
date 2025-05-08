using CollegeApp.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    //[HttpGet]
    //public IActionResult GetBook()
    //{
    //    var books = _bookService.GetAsync(id);
    //    return Ok(books);
    //}
}

