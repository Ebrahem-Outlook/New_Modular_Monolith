using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monolith.API.Contracts.Users;
using Monolith.Application.Users.Commands.CreateUser;

namespace Monolith.API.Controllers;

[Route("V1/[Controller]")]
[ApiController]
public sealed class UsersController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request) =>
        Ok(await sender.Send(
            new CreateUserCommand(
                request.Name,
                request.Bio,
                request.UserName, 
                request.Email, 
                request.Password)));

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest request) =>
        Ok();
   
}
