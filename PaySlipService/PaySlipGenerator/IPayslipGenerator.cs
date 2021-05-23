namespace PaySlipService
{
    public interface IPayslipGenerator
    {
        void DisplayPayslip(string name, double monthlyIncome, double tax, double monthlyIncomeAfterTax);

    }
}
