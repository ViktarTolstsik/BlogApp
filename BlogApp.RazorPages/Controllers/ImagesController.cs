using Microsoft.AspNetCore.Mvc;

namespace BlogApp.RazorPages.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Images get");
        }
    }
}
