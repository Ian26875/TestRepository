using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeWorkDB.Attribute
{
    public sealed class BanWordAttribute : ValidationAttribute
    {
        private string Input { get; set; }
        public BanWordAttribute(string input)
        {

        }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is string)
            {
                //輸入值是字串才判斷
                if (this.Input.Contains(value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}