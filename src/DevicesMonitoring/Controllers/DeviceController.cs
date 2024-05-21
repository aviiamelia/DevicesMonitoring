using DevicesMonitoring.Comunications.Request;
using DevicesMonitoring.filters;
using DevicesMonitoring.useCases.CreateDevice;
using DevicesMonitoring.useCases.CreateUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevicesMonitoring.Controllers;
[Route("api/device")]
[ApiController]
public class DeviceController : ControllerBase
{
    [HttpPost]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult Create([FromBody] RequestCreateDevice request, [FromServices] CreateDeviceUseCase useCase )
    {
        try
        {
            var device = useCase.Execute(request);

            return Created(string.Empty, new {device});

        }
        catch (Exception ex)
        {

            Console.WriteLine($"An error occurred: {ex}");

            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the user.{ex}");
        }
    }
    [HttpGet]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public IActionResult List([FromServices] ListDeviceUseCase useCase)
    {
        try
        {
            var devices = useCase.Execute();

            return Ok(devices);

        }
        catch (Exception ex)
        {

            Console.WriteLine($"An error occurred: {ex}");

            return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating the user.{ex}");
        }

    }
}
