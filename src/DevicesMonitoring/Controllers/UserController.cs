using DevicesMonitoring.Comunications.Request;
using DevicesMonitoring.Entities;
using DevicesMonitoring.Repositories;
using DevicesMonitoring.useCases.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevicesMonitoring.Controllers;
[Route("api/createuser")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromBody] RequestCreateUser request, [FromServices] CreateUserUseCase useCase)
    {


        try
        {
        var newUser = useCase.Execute(request);
       
        return Created(string.Empty, newUser);

        }catch (Exception ex)
        {

            Console.WriteLine($"An error occurred: {ex}");

            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the user.{ex}");
        }
    }
}
