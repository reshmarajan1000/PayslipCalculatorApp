using System;
using System.Linq;
using System.Collections.Generic;

namespace PaySlipService
{
    public class ParseArguments
    {

        public string ParseCommand(string input)
        {
            try
            {
                input = TrimInput(input);
                string[] elements = input.Split(' ');

                return (elements[0] != CommandConstants.InvalidInput) ? elements[0] : CommandConstants.InvalidInput;

            }
            catch (Exception)
            {
                return CommandConstants.InvalidInput;
            }


            throw new NotImplementedException();
        }
        public string TrimInput(string input)
        {
            try
            {
                input = input.Trim();

                return input;
            }
            catch (Exception)
            {
                return CommandConstants.InvalidInput; 
            }


            throw new NotImplementedException();
        }

        public bool ValidateGeneratePaySlipElements(string input)
        {
            try
            {
                input = TrimInput(input);
                bool validCommand = ValidateGeneratePaySlipCommand(input);
                if (validCommand == false)
                {
                    return false;
                }

                List<string> elements = ParseGeneratePaySlipArguments(input);
                int ElementCount = elements.Count();
                int ArgCount = GeneratePaySlipConstants.ArgCount;


                return ElementCount == ArgCount;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
                
            }
            throw new Exception();
            
        }
        public bool ValidateGeneratePaySlipCommand(string input)
        {
            try
            {
                input = TrimInput(input);
                string[] elements = input.Split(' ');
                return elements[0] == CommandConstants.GeneratePaySlipCommand;

            }
            catch (Exception)
            {
                return false;
            }

        }


        public string ParseGeneratePaySlipName(string input)
        {

           if(ValidateGeneratePaySlipElements(input) == false )
            {
                return GeneratePaySlipConstants.NilName;
            }

            List<string> elements = ParseGeneratePaySlipArguments(input);
            try
            {
                return elements[GeneratePaySlipConstants.NameArgPosition].ToString();
            }
            catch (Exception)
            {
                return GeneratePaySlipConstants.NilName;
            }

        }
        public double ParseGeneratePaySlipIncome(string input)
        {
           if (ValidateGeneratePaySlipElements(input) == false)
            {
                return GeneratePaySlipConstants.NilIncome;
            }
            List<string> elements = ParseGeneratePaySlipArguments(input);
            try
            {
                double income = Convert.ToDouble(elements[GeneratePaySlipConstants.IncomeArgPosition]);
                return income >= 0 ? income : GeneratePaySlipConstants.NilIncome;

            }
            catch (Exception)
            {
                return GeneratePaySlipConstants.NilIncome;
            }

        }
        public List<string> ParseGeneratePaySlipArguments(string input)
        {       
            try
            {
                List<string> elements = input.Split(GeneratePaySlipConstants.StringArgQuote)
                         .Select((element, index) => index % 2 == 0 
                                               ? element.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)  
                                               : new string[] { element }) 
                         .SelectMany(element => element).ToList();
                return elements;
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }



    }
}


