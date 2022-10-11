using System.Collections.Immutable;
using System.Text;
using EntityBuilders.Annotation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace EntityBuilders;

[Generator]
public class EntityBuilderGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classWithAttributesProvider = context.SyntaxProvider
            .CreateSyntaxProvider(IsClassWithAttributes, Transform)
            .Where(m => m is not null);

        context.RegisterSourceOutput(context.CompilationProvider.Combine(classWithAttributesProvider.Collect()),
            GenerateSource);
    }

    private static bool IsClassWithAttributes(SyntaxNode node, CancellationToken _)
    {
        return node is ClassDeclarationSyntax { AttributeLists.Count: > 0 };
    }

    private static ClassDeclarationSyntax? Transform(GeneratorSyntaxContext context, CancellationToken _)
    {
        // var classDeclarationSyntax = (ClassDeclarationSyntax)context.Node;

        throw new Exception("Found!");
        // foreach (var attributeSyntax in classDeclarationSyntax.AttributeLists.SelectMany(x => x.Attributes))
        // {
        //     if (attributeSyntax.GetType() == typeof(BuildableAttribute))
        //     {
        //         return classDeclarationSyntax;
        //     }
        // }
        //
        // return null;
    }

    private static void GenerateSource(SourceProductionContext sourceProductionContext,
        (Compilation Left, ImmutableArray<ClassDeclarationSyntax?> Right) source)
    {
        // TODO Generate from source
        sourceProductionContext.AddSource("OhHi.g.cs", SourceText.From(string.Empty, Encoding.UTF8));
    }
}