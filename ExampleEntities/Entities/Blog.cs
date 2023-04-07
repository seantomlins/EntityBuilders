namespace ExampleEntities.Entities;

public class Blog
{
    public int BlogId { get; set; } // Primary Key convention type B
    public string Url { get; set; }
    public int Rating { get; set; }
    
    public virtual ICollection<Post> Posts { get; set; }
}