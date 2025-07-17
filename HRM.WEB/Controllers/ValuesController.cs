using HRM.WEB.Data;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppDbContext _context;


        public ValuesController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Get()
        {
            return Ok();
        }
    }
}
