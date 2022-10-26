namespace API.Model
{
    public class Contract : BaseModel
    {
        public int Total { get; set; }

        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ContractProduct> ContractProducts { get; set; } = new List<ContractProduct>();
    }
}
