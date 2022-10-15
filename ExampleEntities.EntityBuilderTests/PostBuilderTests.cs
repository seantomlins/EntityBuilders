using EntityBuilders;
using Xunit;

namespace ExampleEntities.EntityBuilderTests;

public class PostBuilderTests
{
    [Fact]
    public void Build_Should_ReturnBuiltPost()
    {
        // Given
        var builder = new PostBuilder(new SequentialProvider());

        // When
        var post = builder.Build();

        // Then
        Assert.Equal(1, post.Id);
    }

    [Fact]
    public void Blog_Should_SetBlogAndBlogId()
    {
        // Given
        var blog = new Blog { BlogId = 123 };

        var builder = new PostBuilder(new SequentialProvider());

        // When
        builder.Blog(blog);

        // Then
        var post = builder.Build();
        Assert.Equal(blog, post.Blog);
        Assert.Equal(blog.BlogId, post.BlogId);
    }
}