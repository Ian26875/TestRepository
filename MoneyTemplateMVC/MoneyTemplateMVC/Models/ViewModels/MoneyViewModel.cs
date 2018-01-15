using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Models.ViewModels
{
    public class MoneyViewModel
    {
        [Display(Name = "類別")]
        [DisplayFormat(NullDisplayText = "找不到類別")]
        public string Category { get; set; }


        [Display(Name = "日期")]
        public DateTime CreateTime { get; set; }


        [Display(Name = "金額")]     
        public decimal Amount { get; set; }
    }
}