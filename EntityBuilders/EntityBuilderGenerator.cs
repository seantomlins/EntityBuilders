using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders;

[Generator]
public class EntityBuilderGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        foreach (var syntaxTree in context.Compilation.SyntaxTrees)
        foreach (var classDeclarationSyntax in syntaxTree
                     .GetRoot()
                     .DescendantNodes()
                     .OfType<ClassDeclarationSyntax>()
                     .Where(x => x.AttributeLists.Any())
                     .ToImmutableList())
        {
            foreach (var attribute in classDeclarationSyntax.AttributeLists.SelectMany(x => x.Attributes))
            {
                if (attribute.Name.ToString() == "GenerateEntityBuilder")
                {
                    GenerateBuilder(context, classDeclarationSyntax);
                }
            }
        }
    }

    private static void GenerateBuilder(GeneratorExecutionContext context, ClassDeclarationSyntax classDeclarationSyntax)
    {
        // TODO Generate Source Code
    }
}