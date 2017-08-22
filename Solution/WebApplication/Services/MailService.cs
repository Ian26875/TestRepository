using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Services
{
    public class MailService
    {
        private MyForumEntities db;

        /// <summary>
        /// Gmail 帳號
        /// </summary>
        private readonly string gmailAccount = Properties.Settings.Default.GmailAccount;

        /// <summary>
        /// Gmail 密碼
        /// </summary>
        private readonly string gmailpassword = Properties.Settings.Default.GmailPassword;

        /// <summary>
        /// Gmail 網址
        /// </summary>
        private readonly string gmailAddress = Properties.Settings.Default.GmailAddress;

        private const int ValidateCodeLength = 10;

        public MailService()
        {
            db = new MyForumEntities();
        }

        public string GetValidateCode()
        {
            string validateCode = "";
            string[] codeArray =
            {
                "A","B","C","D","E","F","G","H","I","J",
                "K","L","M","N","O","P","Q","R","S","T",
                "U","V","W","X","Y","Z",
                "0","1","2","3","4","5","6","7","8","9",
                "a","b","c","d","e","f","g","h","i","j",
                "k","l","m","n","o","p", "q","r","s","t",
                "u","v","w","x","y","z"
            };
            Random random = new Random();
            for (int i = 0; i < ValidateCodeLength; i++)
            {
                validateCode += codeArray[random.Next(codeArray.Count())];
            }
            return validateCode;
        }

        /// <summary>
        /// 將使用者資料填入範本中
        /// </summary>
        /// <param name="tempString">範本字串</param>
        /// <param name="userName">使用者名稱</param>
        /// <param name="validateUrl">EmailAddress</param>
        /// <returns></returns>
        public string GetRegisterMailBody(string tempString, string userName, string validateUrl)
        {
            tempString = tempString.Replace("{{UserName}}", userName);
            tempString = tempString.Replace("{{ValidateUrl}}", validateUrl);
            return tempString;
        }

        public void SendRegisterMail(string mailBody, string toEmail)
        {
            SmtpClient service = new SmtpClient("smtp.gmail.com");
            service.Port = 587;
            service.Credentials = new NetworkCredential(gmailAccount, gmailpassword);
            service.EnableSsl = true;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(gmailAddress);
            message.To.Add(toEmail);
            message.Subject = "會員註冊確認信";
            message.Body = mailBody;
            message.IsBodyHtml = true;
            service.Send(message);
        }
    }
}