namespace API.Model
{
    public static class Operator
    {
        public static string Equal { get; } = "==";
        public static string NotEqual { get; } = "!=";
        public static string Greater { get; } = ">";
        public static string Less { get; } = "<";
        public static string GreaterOrEqual { get; } = ">=";
        public static string LessOrEqual { get; } = "<=";
        public static string Contain { get; } = "like";
    }
}
