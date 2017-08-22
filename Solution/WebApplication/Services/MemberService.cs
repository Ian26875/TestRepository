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
            //加密密碼
            newMember.Password = HashPassword(newMember.Password);
            db.Member.Add(newMember);
            db.SaveChanges();
        }

        /// <summary>
        /// 登入確定
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool CheckLogin(string userName, string password, ref string msg)
        {
            bool isLogin = false;
            Member member = db.Member.Find(userName);
            if (member != null)
            {
                //判斷是否有經過信箱驗證,有經過驗證驗證號碼會為空
                if (string.IsNullOrWhiteSpace(member.AuthCode))
                {
                    if (PasswordCheck(member, password))
                    {
                        isLogin = true;
                    }
                    else
                    {
                        msg = "輸入錯誤";
                    }
                }
                else
                {
                    msg = "此帳號尚未經過Email驗證,請去收信";
                }
            }
            else
            {
                msg = "此非會員,請註冊會員";
            }
            return isLogin;
        }

        /// <summary>
        /// 判斷密碼是否與資料庫密碼相同
        /// </summary>
        /// <param name="checkMember">判斷的會員</param>
        /// <param name="password">待確認密碼</param>
        /// <returns>是否相同</returns>
        public bool PasswordCheck(Member checkMember, string password)
        {
            return checkMember.Password.Equals(HashPassword(password));
        }

        /// <summary>
        /// 加密密碼
        /// </summary>
        /// <param name="source">需加密密碼</param>
        /// <returns>加密完密碼</returns>
        public string HashPassword(string source)
        {
            //使用SHA1加密密碼
            return new EncryptionHelper().Encryption(EncryptionType.SHA1, source);
        }

        /// <summary>
        /// 信箱驗證碼驗證
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="authCode"></param>
        /// <returns></returns>
        public string EmailValidate(string userName, string authCode)
        {
            string validateStr = string.Empty;
            Member member = db.Member.Find(userName);
            if (member != null)
            {
                if (member.AuthCode == authCode)
                {
                    member.AuthCode = string.Empty;
                    db.SaveChanges();
                    validateStr = "帳號信箱驗證成功，現在可以登入";
                }
                else
                {
                    validateStr = "驗證碼錯誤，請重新確認";
                }
            }
            else
            {
                validateStr = "傳送資料錯誤，請重新確認或再註冊";
            }
            return validateStr;
        }

        /// <summary>
        /// 確認註冊帳號是否有註冊過
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool AccountCheck(string account)
        {
            Member searchMember = db.Member.Find(account);
            return searchMember == null;
        }

        /// <summary>
        /// 變更會員密碼
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="password">舊密碼</param>
        /// <param name="newPassword">新密碼</param>
        /// <returns></returns>
        public string ChangePassword(string account, string password, string newPassword)
        {
            string result = "";
            Member member = db.Member.Find(account);
            if (PasswordCheck(member, password))
            {
                member.Password = HashPassword(newPassword);
                db.SaveChanges();
                result = "密碼修改成功";
            }
            else
            {
                result = "舊密碼輸入錯誤";
            }
            return result;
        }

        /// <summary>
        /// 取得會員權限角色
        /// </summary>
        /// <param name="account">帳號</param>
        /// <returns>帳號的所有角色</returns>
        public string GetRole(string account)
        {
            string roleName = "User";
            Member member = db.Member.Find(account);
            if (member.IsAdmin)
            {
                roleName += ",Admin";
            }
            return roleName;
        }
    }
}