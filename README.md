# Entity Builder Generator

### Learnings
* Use the versions of the source generator packages in the official docs
* Debugging can be done by attaching to VBCSCompiler.dll
* I haven't figured out how to use IncrementalSourceGenerator
* Id or {EntityName}Id is the Primary Key convention
* Writing tests against example generated code is better than testing the generator itself

### Guides and Tutorials

[Source Code Generator Official Docs](https://learn.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview)

[Source Code Generator Cookbook](https://github.com/dotnet/roslyn/blob/main/docs/features/source-generators.cookbook.md)

[EF Conventions](https://www.entityframeworktutorial.net/efcore/conventions-in-ef-core.aspx)

### TODO

* [X] Id naming convention for construction
* [X] Configurable namespace
* [X] Self-to-one properties
* [X] Self-to-many properties
* [X] AddEntity passing builder for Entity
* [X] Protected and private setters for properties
* [ ] Should setting a parent of a child also add the child to the parents children collection?
* [ ] Include/Exclude paths for entities. Is there a standard for syntax?
* [ ] Create as a nuget package
* [ ] Publish nuget package

### Future

* [ ] Refactoring to a SyntaxReceiver
* [ ] Non-integer Ids
* [ ] Key annotation
* [ ] Respecting EntityTypeConfiguration
* [ ] Independent Associations (Navigation property without Foreign Key)

### Maybe

* [ ] Generate builders in project A for entities contained in project B. Feasible?