using System;
namespace PaySlipService
{
    public class ConsoleWriter : IWritter
    {
        public void WriteLine( string input)
        {
            Console.WriteLine(input);
        }
        public void OutPutToConsole()
        {
            WriteLine(ConsoleConstants.OutputUsage);
            WriteLine(ConsoleConstants.OutputExample);
            WriteLine(ConsoleConstants.OutputInstruction);
        }
        
    }
}
