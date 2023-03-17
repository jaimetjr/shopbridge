namespace Domain.DTO
{
    public class ProductDTO
    {
        public int Product_Id {  get; set; }    
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; } = null!;
    }
}
