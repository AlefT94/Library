using Azure;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Books.Commands.DeleteBook;
using Library.Application.Books.Queries.GetAllBooks;
using Library.Application.Books.Queries.GetBookById;
using Library.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[ApiController]
[Route("api/books")]
public class BooksController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllBooksQuery();
        var response = await mediator.Send(query);

        return response.IsSuccess ? Ok(response) : NotFound(response);
        
        /*return response.Map<IActionResult>(
            onSuccess: response => Ok(response),
            onFailure: error => NotFound(error));*/
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetBookByIdQuery(id);
        var response = await mediator.Send(query);

        return response.IsSuccess ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateBookCommand command)
    {
        var result = await mediator.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteBookCommand(id);
        var response = await mediator.Send(command);

        if (response)
        {
            return Ok();
        }

        return NotFound();
    }
}
