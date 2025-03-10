﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.model
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public bool IsPopular { get; set; }
        public string Genre { get;  set; }
        public int PageCount { get;  set; }
        public DateTime PublishDate { get;  set; }
    }
}
