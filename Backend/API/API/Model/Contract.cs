namespace API.Model
{
    public class Contract: BaseModel
    {
        public int Total { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IList<ContractProduct> ContractProducts { get; set; }
    }
}
