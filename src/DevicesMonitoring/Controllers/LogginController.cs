using DevicesMonitoring.Comunications.Request;
using DevicesMonitoring.useCases.Loggin;
using Microsoft.AspNetCore.Mvc;

namespace DevicesMonitoring.Controllers;
[Route("api/loggin")]
[ApiController]
public class LogginController : ControllerBase
{
    [HttpPost]
    public IActionResult loggin([FromBody]RequestLoggin request, [FromServices] LogginUseCase useCase)
    {
        try
        {
            var token = useCase.execute(request);
            return Ok(new {token});
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);

        }
    }
}
