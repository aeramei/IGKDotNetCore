﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch4.ConsoleApp
{
    [Table("Tbl_Blog")]
    public class BlogDTO
    {

        [Key]
        public int BlogID { get; set; } 
        public string BlogAuthor { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }

    }

   //(just short) public record BlogEntity(int BloagID , string BlogAuthor, string BlogTitle, string BlogConetnt );
}
 