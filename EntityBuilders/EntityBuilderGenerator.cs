﻿using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

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
        foreach (var attribute in classDeclarationSyntax.AttributeLists.SelectMany(x => x.Attributes))
        {
            if (attribute.Name.ToString() == "GenerateEntityBuilder")
            {
                GenerateBuilder(context, classDeclarationSyntax);
            }
        }
    }

    private static void GenerateBuilder(GeneratorExecutionContext context,
        ClassDeclarationSyntax classDeclarationSyntax)
    {
        var typeNamespace = GetNamespace(classDeclarationSyntax);
        var className = classDeclarationSyntax.Identifier;
        var sourceText = SourceText.From($@"
        using {typeNamespace};

        public partial class {className}Builder
        {{
            private readonly {className} _entity;

            public {className}Builder()
            {{
                _entity = new {className}();
            }}

            public {className} Build()
            {{
                return _entity;
            }}
        }}", Encoding.UTF8);

        context.AddSource($"{className}.g.cs", sourceText);
    }
    
    // determine the namespace the class/enum/struct is declared in, if any
    
    private static string GetNamespace(BaseTypeDeclarationSyntax syntax)
    {
        // If we don't have a namespace at all we'll return an empty string
        // This accounts for the "default namespace" case
        string nameSpace = string.Empty;

        // Get the containing syntax node for the type declaration
        // (could be a nested type, for example)
        SyntaxNode? potentialNamespaceParent = syntax.Parent;
    
        // Keep moving "out" of nested classes etc until we get to a namespace
        // or until we run out of parents
        while (potentialNamespaceParent != null &&
               potentialNamespaceParent is not NamespaceDeclarationSyntax
               && potentialNamespaceParent is not FileScopedNamespaceDeclarationSyntax)
        {
            potentialNamespaceParent = potentialNamespaceParent.Parent;
        }

        // Build up the final namespace by looping until we no longer have a namespace declaration
        if (potentialNamespaceParent is BaseNamespaceDeclarationSyntax namespaceParent)
        {
            // We have a namespace. Use that as the type
            nameSpace = namespaceParent.Name.ToString();
        
            // Keep moving "out" of the namespace declarations until we 
            // run out of nested namespace declarations
            while (true)
            {
                if (namespaceParent.Parent is not NamespaceDeclarationSyntax parent)
                {
                    break;
                }

                // Add the outer namespace as a prefix to the final namespace
                nameSpace = $"{namespaceParent.Name}.{nameSpace}";
                namespaceParent = parent;
            }
        }

        // return the final namespace
        return nameSpace;
    }
}