using Xunit;
using PaySlipService;
namespace PaySlipAppTest
{
    public class PaySlipServiceTest
    {

        [Theory]
        [InlineData("GenerateMonthPayslip")]
        [InlineData("PayslipGenerator")]
        [InlineData("GeneratePaySlip")]
        public void ProcessCommand_InvalidCommand_ReturnFalse(string value)
        {
            CommandProcessor commandProcessor = new CommandProcessor();
            string command = commandProcessor.ProcessCommand(value);
            bool resultStatus = command == CommandConstants.GeneratePaySlipCommand;
            Assert.False(resultStatus, $"No comand exist : {command} ");
        }

        [Theory]
        [InlineData("GenerateMonthlyPayslip")]
        [InlineData("GenerateMonthlyPayslip 'John' Kerry")]
        [InlineData("GenerateMonthlyPayslip 'Kerry' John")]
        public void ProcessCommand_ValidCommand_ReturnTrue(string value)
        {
            CommandProcessor commandProcessor = new CommandProcessor();
            string command = commandProcessor.ProcessCommand(value);
            bool resultStatus = command == CommandConstants.GeneratePaySlipCommand;
            Assert.True(resultStatus, $"Generate payslip Command : {command}");
        }

        [Theory]
        [InlineData("PayslipGenerator 'Mary' 9090909")]
        public void GetName_InvalidCommand_ReturnFalse(string value)
        {
            GeneratePaySlipCommand generatePayslip = new GeneratePaySlipCommand();
            string employeeName = generatePayslip.GetName(value);
            bool resultStatus = employeeName != GeneratePaySlipConstants.NilName;
            Assert.False(resultStatus, $"Employee Name: {employeeName}");
        }

        [Theory]
        [InlineData(" GenerateMonthlyPayslip 'Mary' 6000")]
        [InlineData(" GenerateMonthlyPayslip 'Mary Ann' 6000")]
        [InlineData(" GenerateMonthlyPayslip 'Mary Ann johns' 6000")]
        public void GetName_ValidCommand_ReturnTrue(string value)
        {
            GeneratePaySlipCommand generatePayslip = new GeneratePaySlipCommand();
            string employeeName = generatePayslip.GetName(value);

            bool resultStatus = employeeName != GeneratePaySlipConstants.NilName; ;
            Assert.True(resultStatus, $"Employee  Name : {employeeName}");
        }

        [Theory]
        [InlineData("PayslipGenerator 'Mary' 9090909")]
        public void GetIncome_InvalidCommand_ReturnFalse(string value)
        {
            GeneratePaySlipCommand generatePayslip = new GeneratePaySlipCommand();
            double employeeIncome = generatePayslip.GetIncome(value);
            bool resultStatus = employeeIncome != GeneratePaySlipConstants.NilIncome;
            Assert.False(resultStatus, $"Employee Yearly Income : {employeeIncome}");
        }

        [Theory]
        [InlineData(" GenerateMonthlyPayslip 'Mary' 6000")]
        [InlineData(" GenerateMonthlyPayslip 'Mary Ann' 6000")]
        [InlineData(" GenerateMonthlyPayslip 'Mary Ann johns' 6000")]
        public void GetIncome_ValidCommand_ReturnTrue(string value)
        {
            GeneratePaySlipCommand generatePayslip = new GeneratePaySlipCommand();
            double employeeIncome = generatePayslip.GetIncome(value);

            bool resultStatus = employeeIncome != GeneratePaySlipConstants.NilIncome;
            Assert.True(resultStatus, $"Employee Yearly Income : {employeeIncome}");
        }


        [Theory]
        [InlineData(-1.00)]
        public void MonthlyIncomeCalculator_InvalidInput_ReturnFalse(double value)
        {
            MonthlyIncomeCalculator MonthlyIncomeCalculator = new MonthlyIncomeCalculator();
            double MonthlyGrossIncome = MonthlyIncomeCalculator.GetMonthlyGrossIncome(value);

            bool resultStatus = MonthlyGrossIncome >= 0;
            Assert.False(resultStatus, $"Monthly Gross Income : {MonthlyGrossIncome}");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10000.00)]
        [InlineData(600000.00)]
        public void MonthlyIncomeCalculator_ValidInput_ReturnTrue(double value)
        {
            MonthlyIncomeCalculator MonthlyIncomeCalculator = new MonthlyIncomeCalculator();
            double MonthlyGrossIncome = MonthlyIncomeCalculator.GetMonthlyGrossIncome(value);

            bool resultStatus = MonthlyGrossIncome >= 0;
            Assert.True(resultStatus, $"Monthly Gross Income : {MonthlyGrossIncome}");
        }


        [Theory]
        [InlineData(-1.00)]
        public void CalculateMonthlyTax_InvalidInput_ReturnFalse(double value)
        {

            TaxCalculator TaxCalculator = new TaxCalculator();
            double tax = TaxCalculator.CalculateMonthlyTax(value);
            bool resultStatus = tax >= 0;
            Assert.False(resultStatus, $"Monthly Tax : {tax}");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(19000.00)]
        [InlineData(20000.00)]
        [InlineData(18000.00)]
        public void CalculateMonthlyTax_InvalidInput_ReturnTrue(double value)
        {
            TaxCalculator TaxCalculator = new TaxCalculator();
            double tax = TaxCalculator.CalculateMonthlyTax(value);
            bool resultStatus = tax >= 0;
            Assert.True(resultStatus, $"Monthly Tax : {tax}");
        }


        [Theory]
        [InlineData(-1.00, -2.00)]
        [InlineData(1000.00, 2000.00)]
        public void GetMonthlyIncomeAfterTax_InvalidInput_ReturnFalse(double value1, double value2)
        {
            MonthlyIncomeCalculator MonthlyIncomeCalculator = new MonthlyIncomeCalculator();
            double monthlyIncomeAfterTax = MonthlyIncomeCalculator.GetMonthlyIncomeAfterTax(value1, value2);

            bool resultStatus = monthlyIncomeAfterTax >= 0;
            Assert.False(resultStatus, $"Monthly Income After Tax : {monthlyIncomeAfterTax}");
        }

        [Theory]
        [InlineData(20000.00, 3000.00)]
        [InlineData(120000.00, 13000.00)]
        [InlineData(220000.00, 33000.00)]
        public void GetMonthlyIncomeAfterTax_InvalidInput_ReturnTrue(double value1, double value2)
        {
            MonthlyIncomeCalculator MonthlyIncomeCalculator = new MonthlyIncomeCalculator();
            double monthlyIncomeAfterTax = MonthlyIncomeCalculator.GetMonthlyIncomeAfterTax(value1, value2);

            bool resultStatus = monthlyIncomeAfterTax >= 0 ;
            Assert.True(resultStatus, $"Monthly Income After Tax : {monthlyIncomeAfterTax}");
        }


    }
}
