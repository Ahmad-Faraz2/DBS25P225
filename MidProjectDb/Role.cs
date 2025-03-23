namespace MidProjectDb
{
    public class Role
    {
        public int LookupId { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}
