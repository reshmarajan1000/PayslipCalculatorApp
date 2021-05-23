namespace PaySlipService
{
    public class GeneratePaySlipCommand : IGeneratePaySlip
    {

        public string GetName(string Arguments)
        {
            ParseArguments parseArgumentsObj = ParseArguments();
            bool Isvalid = parseArgumentsObj.ValidateGeneratePaySlipElements(Arguments);
            if (Isvalid)
            {
                string name = parseArgumentsObj.ParseGeneratePaySlipName(Arguments);
                return name != GeneratePaySlipConstants.NilName ? name : GeneratePaySlipConstants.NilName;
            }
            else
            {
                return GeneratePaySlipConstants.NilName;
            }

        }

        public double GetIncome(string Arguments)
        {
            ParseArguments parseArguments = ParseArguments();
            bool Isvalid = parseArguments.ValidateGeneratePaySlipElements(Arguments);
            if (Isvalid)
            {
                double income = parseArguments.ParseGeneratePaySlipIncome(Arguments);
                return income != GeneratePaySlipConstants.NilIncome ? income : GeneratePaySlipConstants.NilIncome;

            }
            else
            {
                return GeneratePaySlipConstants.NilIncome;
            }

        }

        public ParseArguments ParseArguments()
        {
            return new ParseArguments();
        }

    }
}
