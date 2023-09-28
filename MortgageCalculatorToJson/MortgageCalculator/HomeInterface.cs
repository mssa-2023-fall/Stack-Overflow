// See https://aka.ms/new-console-template for more information
public interface HomeInterface
{
    string GetPayoffDate();
    string RemainingPrincipalAtDate(DateOnly targetDate);
    decimal InterestPaidAtDate(DateOnly targetDate);
    void GetAmortizationSchedule();
    // should show a nice table | Payment# | Principal | Interest | Total Payment | Remaining Balance

    string Save();
}