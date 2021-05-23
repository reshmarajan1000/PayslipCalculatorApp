using System;
namespace PaySlipService
{
    public class CommandService
    {


        public string CommandReturn(string CommandName)
        {
            foreach (int i in Enum.GetValues(typeof(CommandType)))
            {
                string CommandTypeName = Enum.GetName(typeof(CommandType), i);

                if (CommandTypeName == CommandName)
                {
                    return CommandName;

                }
                    
            }
            return Enum.GetName(typeof(NoCommand), 0);

        }
    }
}
