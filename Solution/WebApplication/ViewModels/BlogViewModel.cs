using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.ViewModels
{
    public class BlogViewModel
    {
        public string Content { get; set; }
        public string Kind { get; set; }
        public DateTime CreatTime { get; set; }
        public string Title { get; set; }
    }
}