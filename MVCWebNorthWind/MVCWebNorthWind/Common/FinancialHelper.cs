// ***********************************************************************
// Assembly         : MVCWebNorthWind
// Author           : Ian
// Created          : 10-16-2017
//
// Last Modified By : Ian
// Last Modified On : 10-17-2017
// ***********************************************************************
// <copyright file="FinancialHelper.cs" company="">
//     Copyright (C)  2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCWebNorthWind.ViewModels;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

/// <summary>
/// The Common namespace.
/// </summary>
namespace MVCWebNorthWind.Common
{
    /// <summary>
    /// Class FinancialHelper.
    /// </summary>
    public class FinancialHelper
    {



        /// <summary>
        /// Gets the payment details.
        /// </summary>
        /// <param name="LoanAmount">The loan amount.</param>
        /// <param name="Cost">The cost.</param>
        /// <param name="GracePeriod">The grace period.</param>
        /// <param name="totalPeriod">The total period.</param>
        /// <param name="StagePeriods">The stage periods.</param>
        /// <param name="StageRate">The stage rate.</param>
        /// <param name="APR">The apr.</param>
        /// <returns>PaymentDetail[].</returns>
        public static PaymentDetail[] GetPaymentDetails(double LoanAmount, double Cost, int GracePeriod, int totalPeriod, int[] StagePeriods, double[] StageRate, ref double APR)
        {
            HashSet<PaymentDetail> payments = new HashSet<PaymentDetail>();
            //剩餘本金
            double RestPrincipal = LoanAmount;
            //總還款金額;
            List<double> repaymentAMTArray = new List<double>() { -(LoanAmount - Cost) };

            for (int period = 1; period <= totalPeriod; period++)
            {
                PaymentDetail payment = new PaymentDetail();
                //取期數利率
                double rate = GetCurrentStageRate(period, StagePeriods, StageRate);
                double periodRate = CalculatePeriodRate(rate);
                if (IsLastPeriod(totalPeriod, period))
                {
                    payment = CalculateFinalPeriodPayment(totalPeriod, periodRate, ref RestPrincipal);
                    payments.Add(payment);
                }
                else
                {
                    //期數在寬限期
                    if (IsWithInGradePeriod(GracePeriod, period))
                    {
                        payment = CalculateGracePeriodPayment(period, periodRate, ref RestPrincipal);
                        payments.Add(payment);
                    }
                    else
                    {
                        payment = CalculatePeriodPayment(totalPeriod, period, periodRate, ref RestPrincipal);
                        payments.Add(payment);
                    }
                }
                repaymentAMTArray.Add(payment.RepaymentAMT);
            }
            APR = CalculateAnnualPercentageRate(repaymentAMTArray.ToArray());
            return payments.ToArray();
        }

        /// <summary>
        /// Determines whether [is with in grace period] [the specified current period].
        /// </summary>
        /// <param name="currentPeriod">The current period.</param>
        /// <param name="gracePeriod">The grace period.</param>
        /// <returns><c>true</c> if [is with in grace period] [the specified current period]; otherwise, <c>false</c>.</returns>
        private static bool IsWithInGracePeriod(int currentPeriod, int gracePeriod)
        {
            return currentPeriod <= gracePeriod;
        }


        /// <summary>
        /// Determines whether [is last period] [the specified total period].
        /// </summary>
        /// <param name="totalPeriod">The total period.</param>
        /// <param name="period">The period.</param>
        /// <returns><c>true</c> if [is last period] [the specified total period]; otherwise, <c>false</c>.</returns>
        private static bool IsLastPeriod(int totalPeriod, int period)
        {
            return period == totalPeriod;
        }

        /// <summary>
        /// Calculates the annual percentage rate.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>System.Double.</returns>
        private static double CalculateAnnualPercentageRate(double[] values)
        {
            return Math.Round(((Financial.IRR(ref values, 0)) * 12) * 100, 2);
        }


        /// <summary>
        /// Calculates the period payment.
        /// </summary>
        /// <param name="totalPeriod">The total period.</param>
        /// <param name="period">The period.</param>
        /// <param name="periodRate">The period rate.</param>
        /// <param name="restPrincipal">The rest principal.</param>
        /// <returns>PaymentDetail.</returns>
        /// <exception cref="Exception">[計算APR時]第" + period.ToString() + "期的分母不能為零</exception>
        private static PaymentDetail CalculatePeriodPayment(int totalPeriod, int period, double periodRate, ref double restPrincipal)
        {
            int calPeriod = totalPeriod - period + 1;
            double pow = Math.Pow((1 + periodRate), calPeriod);
            double top = (restPrincipal * periodRate * pow);
            double down = (pow - 1);
            if (down == 0)
            {
                throw new Exception("[計算APR時]第" + period.ToString() + "期的分母不能為零");
            }
            double repaymentAMT = (restPrincipal * periodRate * pow) / down;
            //付息=剩餘本金*(當期利率)
            double interest = CalculateInterestAMT(periodRate, restPrincipal);
            double repayment = repaymentAMT - interest;
            PaymentDetail payment = new PaymentDetail
            {
                //目前期數
                Period = period,
                RepaymentAMT = repaymentAMT,

                Interest = interest,
                Repayment = repaymentAMT - interest,
                //餘額=剩餘本金-本次還款金額
                Balance = restPrincipal - repayment
            };
            return payment;
        }

        /// <summary>
        /// Calculates the interest amt.
        /// 付息=剩餘本金*(當期利率)
        /// </summary>
        /// <param name="periodRate">當期利率</param>
        /// <param name="restPrincipal">剩餘本金</param>
        /// <returns>System.Double.</returns>
        private static double CalculateInterestAMT(double periodRate, double restPrincipal)
        {
            return restPrincipal * periodRate;
        }


        /// <summary>
        /// Calculates the final period payment.
        /// </summary>
        /// <param name="totalPeriod">The total period.</param>
        /// <param name="periodRate">The period rate.</param>
        /// <param name="restPrincipal">The rest principal.</param>
        /// <returns>PaymentDetail.</returns>
        private static PaymentDetail CalculateFinalPeriodPayment(int totalPeriod, double periodRate, ref double restPrincipal)
        {
            double repayment = restPrincipal;
            double interest = CalculateInterestAMT(periodRate, restPrincipal);
            PaymentDetail payment = new PaymentDetail
            {
                //目前期數
                Period = totalPeriod,
                //付息=剩餘本金*(當期利率)
                Interest = interest,
                Repayment = repayment,
                Balance = 0,
                RepaymentAMT = interest + repayment
            };
            return payment;
        }

        /// <summary>
        /// Calculates the grace period payment.
        /// </summary>
        /// <param name="period">The period.</param>
        /// <param name="periodRate">The period rate.</param>
        /// <param name="restPrincipal">The rest principal.</param>
        /// <returns>PaymentDetail.</returns>
        private static PaymentDetail CalculateGracePeriodPayment(int period, double periodRate, ref double restPrincipal)
        {

            double interest = CalculateInterestAMT(periodRate, restPrincipal);
            double repayementAMT =  interest;

            PaymentDetail payment = new PaymentDetail
            {
                //目前期數
                Period = period,
                //還本=寬限期不還本,故為0
                Repayment = 0,
                //付息=剩餘本金*(當期利率)
                Interest = restPrincipal * periodRate,
                //還款金額=還本+付息
                RepaymentAMT = repayementAMT,
                //餘額=剩餘本金-本次還款金額
                Balance = restPrincipal - repayementAMT,
            };
            return payment;
        }

        /// <summary>
        /// Calculates the period rate.
        /// </summary>
        /// <param name="rate">The rate.</param>
        /// <returns>System.Double.</returns>
        private static double CalculatePeriodRate(double rate)
        {
            return (rate / 12 / 100);
        }

        /// <summary>
        /// Determines whether [is with in grade period] [the specified grace period].
        /// </summary>
        /// <param name="gracePeriod">The grace period.</param>
        /// <param name="currentPeriod">The current period.</param>
        /// <returns><c>true</c> if [is with in grade period] [the specified grace period]; otherwise, <c>false</c>.</returns>
        private static bool IsWithInGradePeriod(int gracePeriod, int currentPeriod)
        {
            return currentPeriod <= gracePeriod;
        }

        /// <summary>
        /// Gets the current stage rate.
        /// </summary>
        /// <param name="period">The period.</param>
        /// <param name="stagePeriods">The stage periods.</param>
        /// <param name="stageRates">The stage rate.</param>
        /// <returns>System.Double.</returns>
        /// <exception cref="Exception">[計算APR時]階段利率與階段期數無法對應</exception>
        private static double GetCurrentStageRate(int period, int[] stagePeriods, double[] stageRates)
        {
            double rate = 0;
            if (stagePeriods.Length != stageRates.Length)
            {
                throw new Exception("[計算APR時]階段利率與階段期數無法對應");
            }
            //目前在第幾階段 1,2,3,4,5,6,7
           
            if (period <= stagePeriods.ElementAt(0))
            {
                rate = stageRates.ElementAtOrDefault(0);
                return rate;
            }
            if (period <= stagePeriods.ElementAtOrDefault(0) + stagePeriods.ElementAtOrDefault(1))
            {
                rate = stageRates.ElementAtOrDefault(1);
                return rate;
            }
            if (period <= stagePeriods.ElementAtOrDefault(0) + stagePeriods.ElementAtOrDefault(1) + stagePeriods.ElementAtOrDefault(2))
            {
                rate = stageRates.ElementAtOrDefault(2);
                return rate;
            }
            return rate;
        }

    }
}