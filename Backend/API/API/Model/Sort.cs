namespace API.Model
{
    public class Sort
    {
        public static string DESC = "desc";
        public static string ASC = "asc";

        public string Field { get; set; }
        private string _order;
        public string Order
        {
            get
            {
                return _order;
            }
            set
            {
                if (string.Equals(DESC, value) || string.Equals(ASC, value))
                {
                    _order = value;
                }
                else
                {
                    _order = DESC;
                }
            }
        }

        public Sort(string field, string order)
        {
            Field = field;
            Order = order;
        }
    }
}
