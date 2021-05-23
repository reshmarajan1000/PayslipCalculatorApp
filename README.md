### PaySlip App
PaySlip App is a  Console Application that give employee Anuual salary details outputs a monthly payslip


### Prerequisties
1. .NET Core 3.1 SDK


### How to Build PaySlip App
1. Unzip the file 
2. Open a command prompt 
3. Go to the PaySlipApp folder
`   cd PaySlipApp
`
4. Enter the following Command to build the App
`   dotnet restore
    dotnet build
`


### How to Run the Test
1. Testing Frame Work : Xunit: https://github.com/xunit/xunit

2. Enter the following Command
`   dotnet test PaySlipService.Tests
`


### How to Run the PaySlip App
1. Enyter the following Command
`   dotnet run --project PaySlipService
`


### Console Input Instructions 

Command Input  
`
    Usage << GenerateMonthlyPayslip EmployyeName Income>>
    Example #1 :  GenerateMonthlyPayslip 'Mary' 60000"
    Example #1 :  GenerateMonthlyPayslip 'Mary Jones' 70000"
`  


### Input Assumptions

   1. Parameters : No additional paramaters are allowed
   2. Order of parameters : paramater order change not allowed

