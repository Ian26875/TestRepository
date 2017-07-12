
using HomeWorkDB.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;

namespace HomeWorkDB.Respoitory
{
    public class AccountBookRepository 
    {
        protected SkillTreeHomeworkEntities1 db;
        public AccountBookRepository()
        {
            db = new SkillTreeHomeworkEntities1();
        }

       

        public IEnumerable<AccountBook> GetAll()
        {
            
            return db.AccountBook;
        }

      
    }
}