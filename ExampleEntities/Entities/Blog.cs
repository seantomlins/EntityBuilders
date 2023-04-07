namespace ExampleEntities.Entities;

public class Blog
{
    public int BlogId { get; set; } // Primary Key convention type B
    public string Url { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedDateUtc { get; protected set; } // Example of a property that is set by the database

    public virtual ICollection<Post> Posts { get; set; }
}