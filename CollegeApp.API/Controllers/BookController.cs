//using CollegeApp.Application.Interface;
//using CollegeApp.Domain.BookModels;
//using Microsoft.AspNetCore.Mvc;

//namespace CollegeApp.API.Controllers;
//[ApiController]
//[Route("api/[controller]")]
//public class BookController : Controller
//{
//    private readonly IBookService _bookService;

//    public BookController(IBookService bookService)
//    {
//        _bookService = bookService;
//    }

//    [HttpPost("books")]
//    public IActionResult CreateBook(BookCommonModel input)
//    {
//        var books = _bookService.CreateAsync(input);
//        return Ok(books);
//    }
//}

