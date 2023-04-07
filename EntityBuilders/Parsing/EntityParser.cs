using System.Collections.Immutable;
using EntityBuilders.Config;
using EntityBuilders.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders.Parsing;

internal static class EntityParser
{
    public static IEnumerable<Entity> GetEntities(GeneratorExecutionContext context, EntityBuilderConfig entityBuilderConfig)
    {
        var entities = new List<EntityClass>();
        foreach (var syntaxTree in context.Compilation.SyntaxTrees)
        foreach (var classDeclarationSyntax in syntaxTree
                     .GetRoot()
                     .DescendantNodes()
                     .OfType<ClassDeclarationSyntax>()
                     .ToImmutableList())
        {
            var semanticModel = context.Compilation.GetSemanticModel(classDeclarationSyntax.SyntaxTree);
            var classSymbol = semanticModel.GetDeclaredSymbol(classDeclarationSyntax);
            if (classSymbol?.ContainingNamespace.ToString() == entityBuilderConfig.EntitiesNamespace)
            {
                entities.Add(new EntityClass(classDeclarationSyntax));
            }
        }

        return entities.Select(x => new Entity(x, entities));
    }
}