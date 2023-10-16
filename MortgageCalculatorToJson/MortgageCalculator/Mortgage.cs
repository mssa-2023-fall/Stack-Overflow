// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;

public class Mortgage : HomeInterface
{
    private int Duration { get; set; } // 10, 15, 30
    private decimal InterestRate { get; set; }  // = .05m; In Monthly
    private decimal PrincipalAmount { get; set; } // *decimal is best practice for precision and financial calulations*
    private DateOnly OriginationDate { get; set; }

    public Dictionary<int, Payment> Payments { get; set; } // Payment# , Total Payment

    //Constructor
    public Mortgage(int Years, decimal YearInterestRate, decimal principal, DateOnly startDate)
    {
        Duration = (12 * Years);
        InterestRate = YearInterestRate / 12; //Convert to monthly
        PrincipalAmount = principal;
        OriginationDate = startDate;
        Payments = CalculatePayments();
    }

    private Dictionary<int, Payment> CalculatePayments()
    {
        decimal MonthlyPayment = PrincipalAmount * (InterestRate * (decimal)Math.Pow((double)(1 + InterestRate), Duration)) / ((decimal)Math.Pow(1 + (double)InterestRate, Duration) - 1); // M = P * ( r(1+r)^n ) / ( (1+r)^n - 1 )
        Dictionary<int, Payment> result = new Dictionary<int, Payment>();
        result.Add(0, new Payment(OriginationDate, 0, 0, PrincipalAmount));

        for(int i = 1; i < Duration + 1; i++)
        {
            decimal InterestPayment = PrincipalAmount * InterestRate, PrincipalPayment = MonthlyPayment - InterestPayment;

            PrincipalAmount -= PrincipalPayment;

            result.Add(i, new Payment(OriginationDate.AddMonths(i), PrincipalPayment, InterestPayment, PrincipalAmount));
        }

        return result;
    }

    public string GetPayoffDate()
    {
        Payment LastPayment = Payments[Payments.Keys.Max()];
        return LastPayment.Date.ToString("yyyy/MM/dd");
    }

    public string RemainingPrincipalAtDate(DateOnly targetDate)
    {
        Payment foundPayment = Payments[12 * (targetDate.Year - OriginationDate.Year) - (targetDate.Month - OriginationDate.Month)];
        return foundPayment.RemainingBalance.ToString("0.00");
    }

    public decimal InterestPaidAtDate(DateOnly targetDate)
    {
        Payment foundPayment = Payments[12 * (targetDate.Year - OriginationDate.Year) - (targetDate.Month - OriginationDate.Month)];

        return foundPayment.InterestAmount; // .ToString("0.00") so it formats correctly
    }


    public void GetAmortizationSchedule()
    {
        Console.WriteLine("| Payment# | Principal | Interest | Total Paid | Remaining Balance | Payment Date |");
        foreach (var entry in Payments)
        {
            Console.WriteLine($"| {entry.Key, 8} | {entry.Value.PrincipalAmount.ToString("0.00"), 9} | {entry.Value.InterestAmount.ToString("0.00"), 8} | {entry.Value.Total.ToString("0.00"),10} | {entry.Value.RemainingBalance.ToString("0.00"),17} |  {entry.Value.Date.ToString("yyyy/MM/dd")}  |");
        }
    }

    public void GetAmortizationScheduleByYear()
    {
        Console.WriteLine("| Payment# | Principal | Interest | Total Paid | Remaining Balance | Payment Date |");
        foreach (var entry in Payments)
        {
            if (entry.Key % 12 != 0) continue;
            Console.WriteLine($"| {entry.Key,8} | {entry.Value.PrincipalAmount.ToString("0.00"),9} | {entry.Value.InterestAmount.ToString("0.00"),8} | {entry.Value.Total.ToString("0.00"),10} | {entry.Value.RemainingBalance.ToString("0.00"),17} |  {entry.Value.Date.ToString("yyyy/MM/dd")}  |");
        }
    }

    public string Save()
    {
        var formattedObj = new { 
            TermLengthInYears = this.Duration / 12,
            InterestRate = (this.InterestRate * 12).ToString("0.000"),
            PrincipalAmount = this.RemainingPrincipalAtDate(OriginationDate), 
            this.OriginationDate
        };
            
        return JsonConvert.SerializeObject(formattedObj);
    }
}