using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Interfaces;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.DTOs.Reviews;
using OnlineStore.Data.Entities;
using OnlineStore.Business.DTOs.ProductImage;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore;
using System.IO;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImagesController : Controller
    {
        private readonly IProductImageService _service;
        private readonly IWebHostEnvironment _env;
        public ProductImagesController(IProductImageService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }


        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var item = await _service.GetByProductId(productId);
            return item == null ? NotFound() : Ok(item);
        }


       
        [HttpPost]
        public async Task<IActionResult> UploadImage( IFormFile imageFile, int productId,short order)
        {
            if (imageFile == null || imageFile.Length == 0)
                return BadRequest("No file uploaded.");

            string webRoot = _env.WebRootPath;

            if (string.IsNullOrEmpty(webRoot))
            {
                // fallback: use ContentRoot instead
                webRoot = Path.Combine(_env.ContentRootPath, "wwwroot");
            }

            string folder = Path.Combine(webRoot, "product-images");
                
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            
            string fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);

            
            string fullPath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

           
            string dbPath = $"product-images/{fileName}";

            var dto = new createProductImageDto
            {
                ProductId = productId,
                ImageOrder = order,
                ImageURL = dbPath
            };

            var item = await _service.CreateAsync(dbPath,dto);

            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(int id,UpdateProductImageDto dto)
        {

            var item =await _service.UpdateAsync(id,dto);
            return item == null ? NotFound() : Ok(item);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var URL = await _service.DeleteAsync(id);
            if(URL == string.Empty)  return NotFound();

            string webRoot = _env.WebRootPath;

            var fullPath = Path.Combine(_env.WebRootPath, URL);
            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);

            return Ok();

        }  
    }
}
