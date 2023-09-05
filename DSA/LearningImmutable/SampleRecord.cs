namespace LearnImmutable
{
    public record class SampleRecord(string ParamString, int ParamInt, DateTime ParamDate);

    public record Person(string FirstName, string LastName);
    /*public record Person
    {
        public required string FirstName { get; init; }
        public required string LastName {  get; init; }
    };*/
}