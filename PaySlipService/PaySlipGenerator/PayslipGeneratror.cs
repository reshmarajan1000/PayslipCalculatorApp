using System;
namespace PaySlipService
{
    public class PayslipGeneratror : IPayslipGenerator
    {
        public void DisplayPayslip(string name, double monthlyIncome, double tax, double monthlyIncomeAfterTax)
        {
            string displayPayslipstring = $" Monthly Payslip for : {name} \n Gross Monthly Income : {monthlyIncome} \n Monthly Income Tax :  {tax} \n Net Monthly Income is :  {monthlyIncomeAfterTax}";

            Console.WriteLine(displayPayslipstring);

        }
    }
}
