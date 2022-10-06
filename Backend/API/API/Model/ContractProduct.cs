namespace API.Model
{
    public class ContractProduct: BaseModel
    {
        public int Quantity { get; set; }
        public Guid ContractId { get; set; }
        public virtual Contract? Contract { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
