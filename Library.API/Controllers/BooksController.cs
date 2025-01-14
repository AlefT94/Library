using Library.Application.Books.Commands.CreateBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[ApiController]
[Route("api/books")]
public class BooksController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateBookCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
