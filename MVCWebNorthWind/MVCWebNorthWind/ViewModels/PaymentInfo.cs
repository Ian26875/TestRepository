using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// The ViewModels namespace.
/// </summary>
namespace MVCWebNorthWind.ViewModels
{
    public class PaymentInfo
    {
        /// <summary>
        /// Gets or sets the annual percentage rate.
        /// </summary>
        /// <value>The annual percentage rate.</value>
        [Display(Name = "年度百分率")]
        public double AnnualPercentageRate { get; set; }

        /// <summary>
        /// Gets or sets the payment details.
        /// </summary>
        /// <value>The payment details.</value>
        [Display(Name = "繳款明細")]
        public IEnumerable<PaymentDetail> PaymentDetails { get; set; }
    }
}