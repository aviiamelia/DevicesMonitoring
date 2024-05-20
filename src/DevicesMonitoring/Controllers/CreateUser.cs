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
public class CreateUser : ControllerBase
{
    private readonly MyDbContext _context;
    public CreateUser(MyDbContext context)
    {
        _context = context;
    }
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

            // Return a custom error message
            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the user.{ex}");
        }
    }
}
