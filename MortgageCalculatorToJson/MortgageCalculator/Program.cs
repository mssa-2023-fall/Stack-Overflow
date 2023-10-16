Mortgage Leo = new Mortgage(30, 0.037m, 203000, new DateOnly(2021, 08, 01));
Console.WriteLine("Weclome to Leo's Mortgage Calculator");
int userInput = 0;
while(userInput != 7)
{
    userInput = OptionResponse();
    EvaluateInput(userInput);
}
 int OptionResponse()
{
    Console.WriteLine("Options: \n1 - over ride last calculation\n2 - Find out the payoff date\n3 - Remaining Principal Balance\n4 - Interest paid at certain date\n5 - Show Amortization Schedule\n6 - Save as json\n7 - End program");
    return (int) inputIsWithinRange(1, 7);
}

decimal inputIsWithinRange(decimal min, decimal max)
{
    decimal response = 0;
    try
    {
        response = decimal.Parse(Console.ReadLine());
        if ( (response >= min) && (response <= max) ) return response;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    Console.WriteLine($"Valid inputs are between {min} & {max}\nTry again...");
    return inputIsWithinRange(min, max);
}
void EvaluateInput(int input)
{
    switch (input)
    {
        case 1:
            CreateMortgage();
            return;
        case 2:
            Console.WriteLine("Payoff date is " + Leo.GetPayoffDate());
            return;
        case 3:
            DateOnly date = getDate();
            Console.WriteLine("Remaining principal on " + date + " is " +Leo.RemainingPrincipalAtDate(date));
            return;
        case 4:
            DateOnly newdate = getDate();
            Console.WriteLine("Interest paid on " + newdate + " is " + Leo.InterestPaidAtDate(newdate));
            return;
        case 5:
            Leo.GetAmortizationSchedule();
            return;
        case 6:
            Console.WriteLine(Leo.Save());
            return;
        case 7:
            Console.WriteLine("Goodbye!");
            return;
        default:
            Console.WriteLine("Yet to be implemented");
            return;
    }
}
void CreateMortgage()
{
    int loanInYears = MortgageLength();
    decimal yearlyInterestRate = askQuestion("What is your interest Rate? (format: '0.037' for 3.7%)", 0, .100m);
    decimal principal = askQuestion("What is the principal amount?", 1000, Decimal.MaxValue);
    Console.WriteLine("Tell me about the mortgage start date?");
    Leo = new Mortgage(loanInYears, yearlyInterestRate, principal, getDate());
    Console.WriteLine("New Mortgage is created!");
}

DateOnly getDate()
{
    int year = (int)askQuestion("Year?", 1900, 2200);
    int month = (int)askQuestion("Month?", 1, 12);
    int day = (int)askQuestion("Day?", 1, 30);
    return new DateOnly(year, month, day);
}

int MortgageLength()
{
    Console.WriteLine("What is your loan length?");
    int response = 0;
    try
    {
        response = Int32.Parse(Console.ReadLine());
        if (response == 10 || response == 15 || response == 30) return response;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    Console.WriteLine($"Valid inputs are 10, 15, or 30...\nTry again...");
    return MortgageLength();
}

decimal askQuestion(string question, decimal min, decimal max)
{
    Console.WriteLine(question);
    return inputIsWithinRange(min, max);
}

/*
 * string GetPayoffDate();
    string RemainingPrincipalAtDate(DateOnly targetDate);
    decimal InterestPaidAtDate(DateOnly targetDate);
    void GetAmortizationSchedule();
    // should show a nice table | Payment# | Principal | Interest | Total Payment | Remaining Balance

    string Save();
 */

/*
Console App

Calculate Payment amount- assuming equal payment across duration
Each Payment would be principal + interest
ex 15 yr = 180 payments due first of month, starting on the first of month after origination date
Payoff would occur on the last payment
Report Accumulated Interest and Principal at a future date.

-- provide an option to save a mortgage object as json file

Given Principal, Duration, StartingDate, Interest Rate


Class Design

Mortgage
Properties

-Duration 10,15,30 maybe enum
-InterestRate
-Principle Amount
-OriginationDate
-Payments - collection of Payment

Methods
-GetPayoffDates
-RemainingPrincipalAtDate
-InterestPaidAtDate
-GetAmortizationSchedule

Payment
-Date
-Principal Amount
-Interest Amount
-Total-

Prompt user to 1-create mortgage

-exercise methods
 */