public class CustomerDTO
{
    public string CustomerName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CustomerID { get; set; }
    public int Age()
    {
        DateTime currentDate = DateTime.Now;
        int age = currentDate.Year - DateOfBirth.Year;
        return (DateOfBirth.Date > currentDate.Date.AddYears(-age)) ? age - 1 : age;
    }
}