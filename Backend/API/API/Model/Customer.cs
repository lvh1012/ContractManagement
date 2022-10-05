namespace API.Model
{
    public class Customer : BaseModel
    {
        public virtual ICollection<Contract> Contracts { get; set; } = new HashSet<Contract>();
    }
}
