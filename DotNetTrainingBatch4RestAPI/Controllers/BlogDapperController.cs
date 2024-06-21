using Dapper;
using IGK.DotNetTrainingBatch4RestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IGK.DotNetTrainingBatch4RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blog";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult EditBlogs(int id)
        {
           // string query = "select * from Tbl_Blog where blogid = @BlogID";
           // using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
          //  var item = db.Query<BlogModel>(query , new BlogModel { BlogID = id}).FirstOrDefault();
          
            var item = FindbyID(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlogs(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogAuthor]
           ,[BlogTitle]
           ,[BlogContent])
     VALUES
           (@BlogAuthor
           ,@BlogTitle 
           ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(int id, BlogModel blog)
        {

            var item = FindbyID(id);
            if(item is null)
            {
                return NotFound("No Datat Found");
            }

            blog.BlogID = id;
            string query = @"UPDATE [dbo].[Tbl_Blog]
  SET [BlogAuthor] = @BlogAuthor
      ,[BlogTitle] = @BlogTitle
      ,[BlogContent] = @BlogContent
 WHERE BlogID = @BlogID";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlogs(int id, BlogModel blog)
        {
            var item = FindbyID(id);
            if (item is null)
            {
                return NotFound("No Data Found");
            }

            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }

            if(conditions.Length == 0)
            {
                return NotFound("No Data Update");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogID = id;

            string query = $@"UPDATE [dbo].[Tbl_Blog]
  SET {conditions}
 WHERE BlogID = @BlogID";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlogs(int id )
        {
            var item = FindbyID(id);
            if (item is null)
            {
                return NotFound("No Datat Found");
            }

            string query = @"Delete from [dbo].[Tbl_Blog] WHERE BlogID = @BlogID";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, new BlogModel {BlogID = id });

            string message = result > 0 ? "Delete Successful." : "Sorry , Its Failed.";
            return Ok(message);
        }

        private BlogModel? FindbyID(int id)  
        {
            string query = "select * from Tbl_Blog where blogid = @BlogID";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogID = id }).FirstOrDefault();
            return item;
        }
    }
}
