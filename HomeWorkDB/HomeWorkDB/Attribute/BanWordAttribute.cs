using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HomeWorkDB.Attribute
{
    public sealed class BanWordAttribute : ValidationAttribute
    {
        private string[] Inputs { get; set; }
        public BanWordAttribute(params string[] input)
        {
            Inputs = input;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is string)
            {
                return Inputs.ToList().Exists(x =>!x.Contains(value.ToString()));
                //輸入值是字串才判斷
                //if (Inputs.Contains(value.ToString()))
                //{
                //    return false;
                //}
            }
            return true;
        }
    }
}