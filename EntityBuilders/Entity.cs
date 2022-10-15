using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders;

internal class Entity
{
    public string Name { get; }
    public string IdPropertyName { get; }
    public string Namespace { get; }
    
    public IEnumerable<PropertyDeclarationSyntax> Properties { get; }

    public Entity(ClassDeclarationSyntax classDeclarationSyntax)
    {
        Name = classDeclarationSyntax.Identifier.ToString();
        Namespace = NamespaceParser.GetNamespace(classDeclarationSyntax);
        IdPropertyName = IdPropertyParser.GetIdPropertyName(classDeclarationSyntax);

        Properties = classDeclarationSyntax.Members
            .OfType<PropertyDeclarationSyntax>()
            .ToImmutableArray();
    }
}