namespace API.Model
{
    public class Filter
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public dynamic Value { get; set; }

        public Filter(string field, string @operator, dynamic value)
        {
            Field = field;
            Operator = @operator;
            Value = value;
        }
    }
}
