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
    
    // TODO Blog_Should_SetBlogAndBlogId
}