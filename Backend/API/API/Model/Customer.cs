namespace API.Model
{
    public class Customer: BaseModel
    {
        public IList<Contract> Contracts { get; set; }
    }
}
