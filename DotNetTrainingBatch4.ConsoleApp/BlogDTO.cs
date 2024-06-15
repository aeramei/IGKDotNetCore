using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4.ConsoleApp
{
    internal class BlogDTO
    {
        public int BlogID { get; set; } 
        public string BlogAuthor { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }

    }

   //(just short) public record BlogEntity(int BloagID , string BlogAuthor, string BlogTitle, string BlogConetnt );
}
 