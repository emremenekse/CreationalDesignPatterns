using Microsoft.AspNetCore.Mvc;
using SingletonAspNetCore.Services;

namespace SingletonAspNetCore.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController: ControllerBase
    {
        [HttpGet]
        public IActionResult X()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connection();
            databaseService.Disconnect();
            return Ok(databaseService.Count);
        }
        [HttpGet]
        public IActionResult Y()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connection();
            databaseService.Disconnect();
            return Ok(databaseService.Count);
        }
    }
}
