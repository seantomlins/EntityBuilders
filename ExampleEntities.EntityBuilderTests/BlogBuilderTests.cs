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
   
   // TODO AddPost_Should_AddPostToBlog_And_SetBlogOnPost
}