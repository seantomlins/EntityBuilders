using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders.Models;

internal class Property
{
    public string Name { get; }
    public string PropertyType { get; }

    public Property(PropertyDeclarationSyntax propertyDeclarationSyntax)
    {
        Name = propertyDeclarationSyntax.Identifier.ToString();
        PropertyType = propertyDeclarationSyntax.Type.ToString();
    }
}