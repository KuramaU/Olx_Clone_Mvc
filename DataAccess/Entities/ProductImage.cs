namespace Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public byte[]? ImageData { get; set; }

        public int ProductId { get; set; }
       // --navigation properties
        public Product? Product { get; set; }

    }
}
