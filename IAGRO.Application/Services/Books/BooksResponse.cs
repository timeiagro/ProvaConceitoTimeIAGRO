namespace IAGRO.Application.Services.Books
{
    public class BooksResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public SpecificationResponse Specifications { get; set; }
    }
}
