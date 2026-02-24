using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.api.models.domain;
using NZWalks.api.models.DTO;
using NZWalks.api.Repositories;

namespace NZWalks.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task <IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);
            
            if (ModelState.IsValid)
            {
                var imageDomainMOdel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription

                };
                await imageRepository.Upload(imageDomainMOdel);
                return Ok(imageDomainMOdel);
            }
            
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("File", "Unsupported file extension");
            }
            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("File", "Filesize is more than 10MB");
            }
        }
    }
}
