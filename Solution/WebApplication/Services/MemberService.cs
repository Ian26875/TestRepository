using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Services
{
    /// <summary>
    /// 提供會員功能相關邏輯及資料庫操作
    /// </summary>
    public sealed class MemberService
    {
        private MyForumEntities db;
        public MemberService()
        {
            db = new MyForumEntities();
        }

        /// <summary>
        /// 註冊會員
        /// </summary>
        /// <param name="newMember"></param>
        public void Register(Member newMember)
        {
            var encodingHelper = new EncryptionHelper();
            //使用SHA1加密密碼
            newMember.Password = encodingHelper.Encryption(EncryptionType.SHA1, newMember.Password);
            db.Member.Add(newMember);          
            db.SaveChanges();
        }
        
    }
}