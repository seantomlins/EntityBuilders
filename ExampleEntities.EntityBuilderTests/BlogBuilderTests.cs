using System.Linq;
using ExampleEntities.Entities;
using ExampleEntities.Entities.Builders;
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
    public void Build_Should_ReturnTheEntity()
    {
        // When
        var builder = new BlogBuilder(new SequentialProvider());

        // Then
        Assert.Same(builder.Entity, builder.Build());
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
    public void AddPost_Should_DoNothing_When_PassedNull()
    {
        // Given
        var builder = new BlogBuilder(new SequentialProvider());

        // When
        builder.AddPost((Post)null!);

        // Then
        var blog = builder.Entity;
        Assert.Empty(blog.Posts);
    }

    [Fact]
    public void AddPost_Should_AcceptPostBuilderExpression()
    {
        // Given
        var builder = new BlogBuilder(new SequentialProvider());

        // When
        builder.AddPost(p => p.Title("Post Title"));

        // Then
        var blog = builder.Entity;
        var post = blog.Posts.First();
        Assert.Equal(blog, post.Blog);
        Assert.Equal(blog.BlogId, post.BlogId);
        Assert.Equal(2, post.Id);
        Assert.Equal("Post Title", post.Title);
    }

    [Fact]
    public void Should_NotHaveCreatedDateUtcMethod_Because_ItDoesNotHaveAPublicSetter()
    {
        // Given
        var builderType = typeof(BlogBuilder);

        // Then
        Assert.Null(builderType.GetProperty("CreatedDateUtc"));
    }
}