using BlogApp.RazorPages.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogApp.RazorPages.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImagesController : Controller
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository ImageRepository)
        {
            imageRepository = ImageRepository;
        }
        [HttpGet]
        public IActionResult Index() 
        {
            return Ok("This needs to appear in the Postman!");
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        { 
           var imageUrl = await imageRepository.UploadAsync(file);
            if (imageUrl == null) 
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }
            return Json(new { link = imageUrl });
        }
    }
}
