// See https://aka.ms/new-console-template for more information

using EntityBuilders;

var blogBuilder = new BlogBuilder()
    .BlogId(123)
    .Url("http://localhost")
    .Build();

var postBuilder = new PostBuilder()
    .Build();