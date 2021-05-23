namespace PaySlipService
{
    public class TaxCalculator : ITaxCalculator
    {
        public double TotaltaxableIncome { get; set; }
        public double TaxableIncome { get; set; }
        public double YearlyTax { get; set; }
        public double MonthlyTax { get; set; }

        public double CalculateMonthlyTax(double income)
        {

            if(income < 0)
            {
                return TaxConstants.InvalidTaxRate;
            }

            if (income <= TaxConstants.TaxIncomeTier1)
            {
                YearlyTax = GetYearlyTaxrate(income, TaxConstants.TaxRateTier1, TaxConstants.TaxAmountTier1);
                MonthlyTax = GetMonthlyTaxrate(YearlyTax, TaxConstants.TotalMonthsInOneYear);
                TotaltaxableIncome = MonthlyTax;
            }
            if (income > TaxConstants.TaxIncomeTier1)
            {
                TaxableIncome = GetTaxableIncome(TaxConstants.TaxIncomeTier2, TaxConstants.TaxIncomeTier1, income);
                YearlyTax = GetYearlyTaxrate(TaxableIncome, TaxConstants.TaxRateTier2, TaxConstants.TaxAmountTier2);
                MonthlyTax = GetMonthlyTaxrate(YearlyTax, TaxConstants.TotalMonthsInOneYear);
                TotaltaxableIncome += MonthlyTax;

            }
            if (income > TaxConstants.TaxIncomeTier2)
            {
                TaxableIncome = GetTaxableIncome(TaxConstants.TaxIncomeTier3, TaxConstants.TaxIncomeTier2, income);
                YearlyTax = GetYearlyTaxrate(TaxableIncome, TaxConstants.TaxRateTier3, TaxConstants.TaxAmountTier3);
                MonthlyTax = GetMonthlyTaxrate(YearlyTax, TaxConstants.TotalMonthsInOneYear);
                TotaltaxableIncome += MonthlyTax;

            }
            if (income > TaxConstants.TaxIncomeTier3)
            {
                TaxableIncome = GetTaxableIncome(TaxConstants.TaxIncomeTier4, TaxConstants.TaxIncomeTier3, income);
                YearlyTax = GetYearlyTaxrate(TaxableIncome, TaxConstants.TaxRateTier4, TaxConstants.TaxAmountTier4);
                MonthlyTax = GetMonthlyTaxrate(YearlyTax, TaxConstants.TotalMonthsInOneYear);
                TotaltaxableIncome += MonthlyTax;

            }

            if (income > TaxConstants.TaxIncomeTier4)
            {
                TaxableIncome = income - TaxConstants.TaxIncomeTier4;
                YearlyTax = GetYearlyTaxrate(TaxableIncome, TaxConstants.TaxRateAboveTier4, TaxConstants.TaxAmountAboveTier4);
                MonthlyTax = GetMonthlyTaxrate(YearlyTax, TaxConstants.TotalMonthsInOneYear);
                TotaltaxableIncome += MonthlyTax;

            }

            return TotaltaxableIncome;
        }


        public double GetTaxableIncome(double UpperTaxTier, double LowerTaxTier, double income)
        {
            double taxslab = UpperTaxTier - LowerTaxTier;
            double deductIncome = income - LowerTaxTier;
            TaxableIncome = deductIncome > taxslab ? taxslab : deductIncome;
            return TaxableIncome;
        }

        public double GetYearlyTaxrate(double taxIncome, double taxrate, double taxamount)
        {

            if (taxrate > 0)
            {
                double tax = taxIncome / taxamount * taxrate;
                return tax;
            }
            else
            {
                return TaxConstants.NilTaxRate;
            }

        }

        public double GetMonthlyTaxrate(double yearlyTax, int Months)
        {

            double tax = yearlyTax / Months;
            return tax;
        }
    }
}
