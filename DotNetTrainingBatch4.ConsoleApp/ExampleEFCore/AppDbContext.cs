using IGK.DotNetTrainingBatch4.ConsoleApp.DTOS;
using IGK.DotNetTrainingBatch4.ConsoleApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGK.DotNetTrainingBatch4.ConsoleApp.ExampleEFCore
{
    internal class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<BlogDTO> Blogs { get; set; }
    }
}
