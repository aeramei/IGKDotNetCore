using DotNetTrainingBatch4.ConsoleApp.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4.ConsoleApp.ExampleEFCore
{

    internal class EFCoreExample
    {
        private readonly AppDbContext db = new AppDbContext();
        public void Run()
        {
            //  Read();
            //  Edit(1);
            //  Edit(3);
            // Create("author", "title", "content");
            // Update(1003, " author Ingyin Khine ", "test title", "test content");
            Delete(1003);
        }

        private void Read()
        {

            var lst = db.Blogs.ToList();
            foreach (BlogDTO item in lst)
            {
                Console.WriteLine(item.BlogID);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("---------------------------");
            }
        }

        private void Edit(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
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

            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);

        }

        private void Update(int id, string author, string title, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            item.BlogAuthor = author;
            item.BlogTitle = title;
            item.BlogContent = content;

            int result = db.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);

        }

        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }

            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Delete Successful." : "Sorry , Its Failed.";
            Console.WriteLine(message);
        }

    }
}
