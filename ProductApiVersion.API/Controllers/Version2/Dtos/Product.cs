namespace ProductApiVersion.API.Controllers.Version2.Dtos
{
    public class Product
    {
        public Guid InternalId { get; set; } = Guid.NewGuid();
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public float Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
