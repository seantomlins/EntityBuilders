using EntityBuilders;
using Xunit;

namespace ExampleEntities.EntityBuilderTests;

public class BlogBuilderTests
{
   [Fact]
   public void Build_Should_ReturnBuiltBlog()
   {
      // Given
      var builder = new BlogBuilder(new SequentialProvider());

      // When
      var blog = builder.Build();

      // Then
      Assert.Equal(1, blog.BlogId);
   }
   
   // TODO AddPost_Should_AddPostToBlog_And_SetBlogOnPost
}