namespace ExampleEntities.Entities;

public class Post
{
    public int Id { get; set; } // Primary Key convention type A
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}