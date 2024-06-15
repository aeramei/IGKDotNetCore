using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4.ConsoleApp
{
    internal class IGKDapper
    {
        public void Run() 
        {
            // Read();
            // Edit(1);
            // Edit(3);

            //Create("author", "title", "content");
            //Update (2, " author Ingyin ", "test title", "test content");
            Delete (2);
        }

        public void Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
           List<BlogDTO> lst =  db.Query<BlogDTO>( "select * from Tbl_Blog").ToList();

            foreach (BlogDTO item in lst)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("---------------------------");
            }

        }

        private void Edit (int id)
        {
            using IDbConnection db = new SqlConnection (ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDTO> ("select * from Tbl_Blog where blogid = @BlogID", new BlogDTO { BlogID = id}). FirstOrDefault();

            if(item is null) // like ==
            {
                Console.WriteLine("No data Found");
                return;
            }

            Console.WriteLine(item.BlogID);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogContent);
        }

        private void Create(string author, string title, string content)
        {

            var item = new BlogDTO
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content,
            };

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogAuthor]
           ,[BlogTitle]
           ,[BlogContent])
     VALUES
           (@BlogAuthor
           ,@BlogTitle 
           ,@BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
           int result =  db.Execute(query, item);

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);

        }

        private void Update(int id, string author, string title, string content)
        {
            var item = new BlogDTO
            {
                BlogID = id,    
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content,
            };

            string query = @"UPDATE [dbo].[Tbl_Blog]
  SET [BlogAuthor] = @BlogAuthor
      ,[BlogTitle] = @BlogTitle
      ,[BlogContent] = @BlogContent
 WHERE BlogID = @BlogID";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        private void Delete(int id)
        {

            var item = new BlogDTO
            {
                BlogID = id
            };

            string query = @"Delete from [dbo].[Tbl_Blog] WHERE BlogID = @BlogID";

            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);

            string message = result > 0 ? "Delete Successful." : "Sorry , Its Failed.";
            Console.WriteLine(message);

        }
    }
}
