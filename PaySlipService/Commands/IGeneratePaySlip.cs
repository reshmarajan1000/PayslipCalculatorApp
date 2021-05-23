namespace PaySlipService
{
    public interface IGeneratePaySlip
    {
        string GetName(string command);
        double GetIncome(string command);
    }
}
