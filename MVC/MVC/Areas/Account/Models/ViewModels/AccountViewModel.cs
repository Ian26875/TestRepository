using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Areas.Account.Models.ViewModels
{
    public class AccountViewModel
    {
        [DisplayName("金額")]
        [Range(0, 100000000), DataType(DataType.Currency)]
        public int Amount { get; set; }
        [DisplayName("日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DisplayName("種類")]
        public string Category { get; set; }
        [DisplayName("編號")]
        public int Number { get; set; }
    }
}