using EntityBuilders;
using Xunit;

namespace ExampleEntities.EntityBuilderTests;

public class BlogBuilderTests
{
    [Fact]
    public void Constructor_Should_CreateEntityWithId()
    {
        // When
        var builder = new BlogBuilder(new SequentialProvider());

        // Then
        Assert.Equal(1, builder.Entity.BlogId);
    }

    [Fact]
    public void AddPost_Should_AddPostToBlog_And_SetBlogOnPost()
    {
        // Given
        var post = new Post();
        var builder = new BlogBuilder(new SequentialProvider());

        // When
        builder.AddPost(post);

        // Then
        var blog = builder.Entity;
        Assert.Equal(blog, post.Blog);
        Assert.Equal(blog.BlogId, post.BlogId);
        Assert.Contains(post, blog.Posts);
    }

    [Fact]
    public void AddPost_SShould_DoThing_When_PassedNull()
    {
        // Given
        var builder = new BlogBuilder(new SequentialProvider());

        // When
        builder.AddPost(null);

        // Then
        var blog = builder.Entity;
        Assert.Empty(blog.Posts);
    }
}