using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace BlogApp.RazorPages.Repositories
{
    //Cloudinary

    public class ImageRepository : IImageRepository
    {
        private readonly Account account;
        public ImageRepository(IConfiguration configuration)
        {
            account = new Account(configuration.GetSection("Cloudinary")["CloudName"], 
                configuration.GetSection("Cloudinary")["ApiKey"], 
                configuration.GetSection("Cloudinary")["ApiSecret"]);
        }
        public async Task<string> UploadAsync(IFormFile file)
        {

            var cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                PublicId = file.FileName
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);
            if (uploadResult != null && uploadResult.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                return uploadResult.SecureUri.ToString();
            }
            return null;
        }
    }
}
