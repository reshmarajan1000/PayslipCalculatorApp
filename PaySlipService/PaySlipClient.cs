    namespace PaySlipService
    {
        public class PaySlipClient
        {
            public static void Main(string[] args)
            {

                if (args.Length == 0)
                {

                    IWritter _writter = new ConsoleWriter();
                    _writter.OutPutToConsole();

                    IReader _reader = new ConsoleReader();
                    string inputData = _reader.ReadLine();


                    CommandProcessor commandProcessor = new CommandProcessor();
                    string command = commandProcessor.ProcessCommand(inputData);

   
                    if(command == CommandConstants.GeneratePaySlipCommand)
                    {
                        GeneratePaySlipCommand generatePayslip = new GeneratePaySlipCommand();

                        string employeeName = generatePayslip.GetName(inputData);
                        double employeeSalary = generatePayslip.GetIncome(inputData);

                        if (employeeName != GeneratePaySlipConstants.NilName && employeeSalary != GeneratePaySlipConstants.NilIncome)
                        {

                            MonthlyIncomeCalculator MonthlyIncomeCalculator = new MonthlyIncomeCalculator();
                            double MonthlyGrossIncome = MonthlyIncomeCalculator.GetMonthlyGrossIncome(employeeSalary);

                            TaxCalculator TaxCalculator = new TaxCalculator();
                            double tax = TaxCalculator.CalculateMonthlyTax(employeeSalary);

                            if(MonthlyGrossIncome != MonthlyIncomeConstant.NilIncome && tax != TaxConstants.InvalidTaxRate)
                            {
                                double monthlyIncomeAfterTax = MonthlyIncomeCalculator.GetMonthlyIncomeAfterTax(MonthlyGrossIncome, tax);

                                PayslipGeneratror myPayslipCalculator = new PayslipGeneratror();
                                myPayslipCalculator.DisplayPayslip(employeeName, MonthlyGrossIncome, tax, monthlyIncomeAfterTax);
                            }
                        

                        }

                        else
                        {
                            _writter.WriteLine(CommandConstants.InvalidInput);
                        }

                    }
                    else
                    {
                        _writter.WriteLine(CommandConstants.InvalidInput);
                    }

                }


            }
        }
    }
