using IGK.DotNetTrainingBatch4.RestApiWithNLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IGK.DotNetTrainingBatch4.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BusinessLogicBlog _businessLogicBlog;

        public BlogController()
        {
            _businessLogicBlog = new BusinessLogicBlog();
        }

        [HttpGet]
        public IActionResult Read()
        {
            var lst = _businessLogicBlog.GetBlogs();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var item = _businessLogicBlog.GetBlogs(id);
            if (item is null)
            {
                return NotFound("No data Found");
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            var result = _businessLogicBlog.CreateBlog(blog);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);

            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BlogModel blog)
        {
            var item = _businessLogicBlog.GetBlogs(id);
            if (item is null)
            {
                return NotFound("No data Found");
            }

            var result = _businessLogicBlog.UpdateBlog(id , blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _businessLogicBlog.GetBlogs(id);
            if (item is null)
            {
                return NotFound("Data not found ");
            }

            var result = _businessLogicBlog.PatchBlog(id, blog);

            string message = result > 0 ? "Update Successfully." : "Update Fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _businessLogicBlog.GetBlogs(id);
            if (item is null)
            {
                return NotFound("No data Found");
            }
            var result = _businessLogicBlog.DeleteBlog(id);

            string message = result > 0 ? " Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);

            return Ok(message);
        }
    }
}

