namespace ShopAPI.Models.Books;

public class BookReadDto : BaseDto
{
    public string Title { get; set; }
    public string Image { get; set; }
    public decimal Price { get; set; }
    public int AuthorId { get; set; }
    public string AuthorName { get; set; }
}