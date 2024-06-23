using Dapper;
using IGK.DotNetTrainingBatch4RestAPI.Models;
using Microsoft.AspNetCore.Http;        
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace IGK.DotNetTrainingBatch4RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select* from tbl_blog";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();


            // List<BlogModel> lst = new List<BlogModel>();
            //foreach(DataRow dr in dt.Rows)
            //{
            //    BlogModel blog = new BlogModel();
            //    blog.BlogID = Convert.ToInt32(dr["BlogID"]);
            //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);

            //    BlogModel blog = new BlogModel
            //    {
            //        BlogID = Convert.ToInt32(dr["BlogID"]),
            //       BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //        BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //        BlogContent = Convert.ToString(dr["BlogContent"])
            //    };
            //    lst.Add(blog);  
            // }

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogID = Convert.ToInt32(dr["BlogID"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogContent = Convert.ToString(dr["BlogContent"])

            }).ToList();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog (int id)
        {
            string query = "select* from tbl_blog where BlogID = @BlogID";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            if(dt.Rows.Count == 0)
            {
                return NotFound("No Data Found");
            }

            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogID = Convert.ToInt32(dr["BlogID"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogContent = Convert.ToString(dr["BlogContent"])

            };

            return Ok(dt);

        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
           
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogAuthor]
           ,[BlogTitle]
           ,[BlogContent])
     VALUES
           (@BlogAuthor
           ,@BlogTitle 
           ,@BlogContent)";

            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog( int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
  SET [BlogAuthor] = @BlogAuthor
      ,[BlogTitle] = @BlogTitle
      ,[BlogContent] = @BlogContent
 WHERE BlogID = @BlogID";

            //CTRL + K +  = Command 
            //SHIFT + ALT + . = Multipla Selection

            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogID", id);
            SqlCommand aera = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(aera);
            aera.Parameters.AddWithValue("@BlogID", id);
            aera.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            aera.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            aera.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            blog.BlogID = id;   
            int result = aera.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
          
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlogs(int id, BlogModel blog)
        {
            var item = FindbyID(id);
            if (item is null)
            {
                return Ok("No data found.");
            }

            string conditions = string.Empty;

            if (blog.BlogTitle != null)
            {
                conditions += "[BlogTitle] = @BlogTitle, ";
            }

            if (blog.BlogAuthor != null)
            {
                conditions += "[BlogAuthor] = @BlogAuthor, ";
            }

            if (blog.BlogContent != null)
            {
                conditions += "[BlogContent] = @BlogContent, ";
            }

            if (conditions.Length == 0)
            {
                return NotFound("No data update.");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);
            blog.BlogID = id;

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                           SET {conditions}
                         WHERE BlogID=@BlogID";

            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand aera = new SqlCommand(query, connection);

            aera.Parameters.AddWithValue("@BlogId", id);

            if (blog.BlogTitle != null)
            {
                aera.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            }

            if (blog.BlogAuthor != null)
            {
                aera.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            }

            if (blog.BlogContent != null)
            {
               aera.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }

            int result = aera.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Updating successful." : "Updating failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                             WHERE BlogId=@BlogId";
            SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();


            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }

        private object FindbyID(int id)
        {
            string query = "select * from Tbl_Blog where blogid = @BlogID";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel { BlogID = id }).FirstOrDefault();
            return item;
        }
    }
}


