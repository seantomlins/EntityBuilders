using System.Collections.Immutable;
using EntityBuilders.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders.Parsing;

internal static class EntityParser
{
    public static IEnumerable<Entity> GetEntities(GeneratorExecutionContext context)
    {
        var entities = new List<EntityClass>();
        
        foreach (var syntaxTree in context.Compilation.SyntaxTrees)
        foreach (var classDeclarationSyntax in syntaxTree
                     .GetRoot()
                     .DescendantNodes()
                     .OfType<ClassDeclarationSyntax>()
                     .Where(x => x.AttributeLists.Any())
                     .ToImmutableList())
        {
            if (classDeclarationSyntax.AttributeLists
                .SelectMany(x => x.Attributes)
                .Any(x => x.Name.ToString() == "GenerateEntityBuilder"))
            {
                entities.Add(new EntityClass(classDeclarationSyntax));
            }
        }

        return entities.Select(x => new Entity(x, entities));
    }
}