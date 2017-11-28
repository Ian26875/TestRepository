using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWebNorthWind.ViewModels
{
    public class LoanInformation
    {
        /// <summary>
        /// Gets or sets the loan amount.
        /// </summary>
        /// <value>The loan amount.</value>
        [Required]
        [Display(Name = "貸款金額")]
        public double LoanAmount { get; set; }

        /// <summary>
        /// Gets or sets the fee.
        /// </summary>
        /// <value>The fee.</value>
        [Range(0, int.MaxValue)]
        [Display(Name = "手續費")]
        public int Fee { get; set; }

        /// <summary>
        /// Gets or sets the grace period.
        /// </summary>
        /// <value>The grace period.</value>
        [Range(0, int.MaxValue)]
        [Display(Name = "寬限期")]
        public int GracePeriod { get; set; }

        /// <summary>
        /// Gets or sets the total periods.
        /// </summary>
        /// <value>The total periods.</value>
        [Display(Name = "總期數")]
        [Range(0, int.MaxValue)]
        public int TotalPeriods { get; set; }

        /// <summary>
        /// Gets or sets the stage interest rate.
        /// </summary>
        /// <value>The stage interest rate.</value>
        [Display(Name = "階段利率")]
        public double[] StageInterestRate { get; set; }

        /// <summary>
        /// Gets or sets the stage period.
        /// </summary>
        /// <value>The stage period.</value>
        [Display(Name = "階段期數")]
        public int[] StagePeriod { get; set; }
    }
}