namespace PaySlipService
{

    public class CommandFactory : ICommandFactory
    {
       
        public string RetriveCommand(string Arguments)
        {
            ParseArguments ParseObj = ParseArguments();
            string commandArgument = ParseObj.ParseCommand(Arguments);

            if(commandArgument != CommandConstants.InvalidInput)
            {
                CommandService CommandServiceObj = PasreCommand();
                string CommandName = CommandServiceObj.CommandReturn(commandArgument);
                return CommandName; 
            }
            else
            {
                return CommandConstants.InvalidInput;
            }
            
        }

        public ParseArguments ParseArguments()
        {
            return new ParseArguments();
        }

        public CommandService PasreCommand()
        {
            return new CommandService();
        }

    }
    
}
