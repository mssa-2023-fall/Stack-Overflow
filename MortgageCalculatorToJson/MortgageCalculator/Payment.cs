// See https://aka.ms/new-console-template for more information
public class Payment
{
    public DateOnly Date { get; set; }
    public decimal PrincipalAmount { get; set; }
    public decimal InterestAmount { get; set; }
    public decimal Total { get; set; }
    public decimal RemainingBalance { get; set; }
    public Payment(DateOnly date, decimal principal, decimal interest, decimal Balance) 
    {
        Date = date;
        PrincipalAmount = principal;
        InterestAmount = interest;
        RemainingBalance = Balance;

        Total = (principal + interest);
    }
}