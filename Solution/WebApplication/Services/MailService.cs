using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class MailService
    {
        private MyForumEntities db;



        public MailService()
        {
            db = new MyForumEntities();
        }
    }
}