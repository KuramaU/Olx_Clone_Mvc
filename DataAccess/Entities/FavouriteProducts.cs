namespace Data.Entities
{
    public class FavouriteProducts
    {
        public int Id { get; set; }


        public int ProductId { get; set; }
        // --navigation properties

        public User? user { get; set; }

    }
}
