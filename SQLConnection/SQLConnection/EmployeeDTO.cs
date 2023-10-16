internal class EmployeeDTO
{
    public int Employee_Key { get; set; }
    public int WWI_Employee_ID { get; set; }
    public string Employee { get; set; }
    public string Preferred_Name { get; set; }
    public bool Is_Salesperson { get; set; }
    public byte[] Photo { get; set; }
    public DateTime Valid_From { get; set; }
    public DateTime Valid_To { get; set; }
    public int Lineage_Key { get; set; }
}