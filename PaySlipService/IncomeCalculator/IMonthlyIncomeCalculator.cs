namespace PaySlipService
{
    public interface IMonthlyIncomeCalculator
    {
        double GetMonthlyGrossIncome(double YearlyGrossIncome);
        double GetMonthlyIncomeAfterTax(double MonthlyGrossIncome, double Tax);
    }
}
