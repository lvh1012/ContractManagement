namespace API.Model
{
    public class Page
    {
        const int minPageSize = 15;
        const int maxPageSize = 50;

        public int TotalPage { get; set; }
        public int TotalRow { get; set; }
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 15;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value switch
                {
                    var _value when _value > maxPageSize => maxPageSize,
                    50 => 50,
                    30 => 30,
                    15 => 15,
                    var _value when _value < minPageSize => minPageSize,
                    _ => 15,
                };
            }
        }
    }
}
