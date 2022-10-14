// See https://aka.ms/new-console-template for more information

using EntityBuilders;

var idProvider = new SequentialProvider();

var blogBuilder = new BlogBuilder(idProvider)
    .Url("http://localhost")
    .Build();

var postBuilder = new PostBuilder(idProvider)
    .Build();