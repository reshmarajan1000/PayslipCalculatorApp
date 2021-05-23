namespace PaySlipService
{

    public class CommandProcessor
    {
        private readonly CommandFactory _commandFactory;

        public CommandProcessor()
        {
            _commandFactory = new CommandFactory();
        }

        public string ProcessCommand(string args)
        {
 
            string command = _commandFactory.RetriveCommand(args);
            return command;
        }

    }
}
