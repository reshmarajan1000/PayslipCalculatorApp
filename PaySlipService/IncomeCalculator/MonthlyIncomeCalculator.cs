namespace PaySlipService
{
    public class MonthlyIncomeCalculator : IMonthlyIncomeCalculator
    {

        public double GetMonthlyGrossIncome(double YearlyGrossIncome)
        {
            return YearlyGrossIncome >= 0 ? YearlyGrossIncome / MonthlyIncomeConstant.TotalMonthsInOneYear : MonthlyIncomeConstant.NilIncome;
           
        }
        public double GetMonthlyIncomeAfterTax(double MonthlyGrossIncome, double Tax)
        {
            if (MonthlyGrossIncome >= 0 && Tax >= 0)
            {
                double IncomeAftertax = MonthlyGrossIncome - Tax;
                return IncomeAftertax;
            }
            else
            {
                return MonthlyIncomeConstant.NilIncome;
            }
               
        }
    }
}
