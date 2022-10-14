# Entity Builder Generator

### Learnings
* Use the versions of the source generator packages in the official docs
* Debugging can be done by attaching to VBCSCompiler.dll
* I haven't figured out how to use IncrementalSourceGenerator
* Id or <EntityName>Id is the Primary Key convention

### Guides and Tutorials

https://learn.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview

https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md

https://www.youtube.com/watch?v=IUMZH5Z4r00

### TODO

* [ ] Self-to-one properties
* [ ] Self-to-many properties
* [ ] Protected and private setters for properties
* [ ] Refactoring to a SyntaxReceiver