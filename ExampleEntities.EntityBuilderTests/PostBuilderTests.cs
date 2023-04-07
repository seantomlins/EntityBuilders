using ExampleEntities.Entities;
using ExampleEntities.Entities.Builders;
using Xunit;

namespace ExampleEntities.EntityBuilderTests;

public class PostBuilderTests
{
    [Fact]
    public void Constructor_Should_CreateEntityWithId()
    {
        // When
        var builder = new PostBuilder(new SequentialIdProvider());

        // Then
        Assert.Equal(1, builder.Entity.Id);
    }

    [Fact]
    public void Blog_Should_SetBlogAndBlogId_And_AddPostToBlogPosts()
    {
        // Given
        var blog = new Blog { BlogId = 123 };

        var builder = new PostBuilder(new SequentialIdProvider());

        // When
        builder.Blog(blog);

        // Then
        var post = builder.Entity;
        Assert.Equal(blog, post.Blog);
        Assert.Equal(blog.BlogId, post.BlogId);
    }

    [Fact]
    public void Blog_Should_AllowNulls()
    {
        // Given
        var blog = new Blog { BlogId = 123 };

        var builder = new PostBuilder(new SequentialIdProvider());
        builder.Blog(blog);

        // When
        builder.Blog(null);

        // Then
        var post = builder.Entity;
        Assert.Null(post.Blog);
        Assert.Equal(default, post.BlogId);
    }
}