using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWorkDB.Areas.Account.Models
{
    public enum CategoryEnum
    {
        [Display(Name ="支出")]
        Expend,
        [Display(Name = "收入")]
        Income,
    }
}