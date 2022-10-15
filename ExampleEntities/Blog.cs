﻿using EntityBuilders.Annotation;

namespace ExampleEntities;

[GenerateEntityBuilder]
public class Blog
{
    public int BlogId { get; set; } // Primary Key convention type B
    public string Url { get; set; }
    public int Rating { get; set; }
    public List<Post> Posts { get; set; }
}