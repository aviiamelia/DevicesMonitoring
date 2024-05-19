using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevicesMonitoring.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CreateUser : ControllerBase
{
    [HttpGet]
    public IActionResult create()
    {
        return Ok("teste");
    }
}
