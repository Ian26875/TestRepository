using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebNorthWind.ViewModels
{
    /// <summary>
    /// Class PaymentDetail.
    /// </summary>
    public class PaymentDetail
    {
        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        /// <value>The period.</value>
        [Display(Name = "期數")]
        public int Period { get; set; }

        /// <summary>
        /// Gets or sets the repayment.
        /// </summary>
        /// <value>The repayment.</value>
        [Display(Name = "還款金額")]
        public double Repayment { get; set; }

        /// <summary>
        /// Gets or sets the interest.
        /// </summary>
        /// <value>The interest.</value>
        [Display(Name = "付息")]
        public double Interest { get; set; }

        /// <summary>
        /// Gets or sets the repayment amt.
        /// </summary>
        /// <value>The repayment amt.</value>
        [Display(Name = "還本")]
        public double RepaymentAMT { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>The balance.</value>
        [Display(Name = "餘額")]
        public double Balance { get; set; }
    }
}