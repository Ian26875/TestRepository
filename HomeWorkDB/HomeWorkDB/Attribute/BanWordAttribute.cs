using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HomeWorkDB.Attribute
{
    public sealed class BanWordsAttribute : ValidationAttribute
    {
        private string[] Inputs { get; set; }
        public BanWordsAttribute(params string[] input)
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
            }
            return true;
        }
    }
}