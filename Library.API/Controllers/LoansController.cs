using Library.Application.Loans.Commands.CreateLoan;
using Library.Application.Loans.Commands.ReturnLoan;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoansController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLoan([FromBody] CreateLoanCommand loan)
    {
        var result = await mediator.Send(loan);

        if (!result.isSuccess)
        {
            return BadRequest(result.message);
        }

        return Ok();
    }

    [HttpPut("return")]
    public async Task<IActionResult> ReturnLoan([FromBody] ReturnLoanCommand command)
    {
        var isSuccess = await mediator.Send(command);

        if (!isSuccess)
        {
            return BadRequest();
        }

        return Ok();
    }
}
