namespace ShopAPI.Data;

public partial class Authors
{
    public Authors()
    {
        Books = new HashSet<Books>();
    }

    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Bio { get; set; }

    public virtual ICollection<Books> Books { get; set; }
}