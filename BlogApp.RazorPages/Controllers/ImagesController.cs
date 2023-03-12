using Microsoft.AspNetCore.Mvc;

namespace BlogApp.RazorPages.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        { 

        }
    }
}
