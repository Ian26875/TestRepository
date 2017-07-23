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

        private readonly string gmailAccount = Properties.Settings.Default.GmailAccount;
        private readonly string gmailpassword = Properties.Settings.Default.GmailPassword;
        private readonly string gmailAddress = Properties.Settings.Default.GmailAddress;

        public MailService()
        {
            db = new MyForumEntities();
        }
    }
}