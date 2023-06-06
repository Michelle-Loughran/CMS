// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;

// namespace CMS.Web.Controllers
// {namespace Bloggie.Web.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ImagesController : Controller
//     {
//         private readonly IImageRepository imageRepository;

//         public ImagesController(IImageRepository imageRepository)
//         {
//             this.imageRepository = imageRepository;
//         }

//         [HttpPost]
//         public async Task<IActionResult> UploadAsync(IFormFile file)
//         {
//             var imageUrl = await imageRepository.UploadAsync(file);

//             if (imageUrl == null)
//             {
//                 return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
//             }

//             return Json(new { link = imageUrl });
//         }
//     }
// }
//     [Route("[controller]")]
//     public class ImageUploadController : Controller
//     {
//         private readonly ILogger<ImageUploadController> _logger;

//         public ImageUploadController(ILogger<ImageUploadController> logger)
//         {
//             _logger = logger;
//         }

//         public IActionResult Index()
//         {
//             return View();
//         }

//         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//         public IActionResult Error()
//         {
//             return View("Error!");
//         }
//     }
// }
