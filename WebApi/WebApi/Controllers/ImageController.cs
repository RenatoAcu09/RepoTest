using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : Controller
    {

        private readonly IAmazonS3 amazonS3;
        public ImageController(IAmazonS3 amazonS3)
        {
            this.amazonS3 = amazonS3;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] IFormFile file)
        {
            var putRequest = new PutObjectRequest() {
                BucketName = "",
                Key = file.FileName,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType,
            };

            var result =  await this.amazonS3.PutObjectAsync(putRequest);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string imageName)
        {
            var request = new GetObjectRequest()
            {
                BucketName = "",
                Key = imageName,
            };

            using GetObjectResponse response =  await this.amazonS3.GetObjectAsync(request);
            using Stream responseStream = response.ResponseStream;
            var stream = new MemoryStream();

            await responseStream.CopyToAsync(stream);
            stream.Position = 0;

            return new FileStreamResult(stream,response.Headers["Content-Type"])
            {
                FileDownloadName= imageName,
            };

        }  

    }
}
