using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Product: BaseModel
    {
        [StringLength(512)]
        public string? Size { get; set; }
        public int Price { get; set; }
        public string Unit { get; set; }
        public IList<ContractProduct>? ContractProducts { get; set; }
    }
}
