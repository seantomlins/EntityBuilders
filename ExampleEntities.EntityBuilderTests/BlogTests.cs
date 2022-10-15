using EntityBuilders;
using Xunit;

namespace ExampleEntities.EntityBuilderTests;

public class BlogBuilderTests
{
   [Fact]
   public void Should_BuildABlog()
   {
      // Given
      var builder = new BlogBuilder(new SequentialProvider());

      // When
      var blog = builder.Build();

      // Then
      Assert.Equal(1, blog.BlogId);
   }
}