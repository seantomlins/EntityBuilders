﻿using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders;

internal class EntityParser
{
    public static IEnumerable<Entity> GetEntities(GeneratorExecutionContext context)
    {
        var entities = new List<Entity>();
        foreach (var syntaxTree in context.Compilation.SyntaxTrees)
        foreach (var classDeclarationSyntax in syntaxTree
                     .GetRoot()
                     .DescendantNodes()
                     .OfType<ClassDeclarationSyntax>()
                     .Where(x => x.AttributeLists.Any())
                     .ToImmutableList())
        foreach (var attribute in classDeclarationSyntax.AttributeLists.SelectMany(x => x.Attributes))
        {
            if (attribute.Name.ToString() == "GenerateEntityBuilder")
            {
                entities.Add(new Entity(classDeclarationSyntax));
            }
        }

        return entities;
    }
}