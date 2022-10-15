using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders.Models;

internal class Property
{
    public string Name { get; }
    public string PropertyType { get; }
    public Entity Entity { get; }

    public Property(PropertyDeclarationSyntax propertyDeclarationSyntax, Entity entity)
    {
        Entity = entity;
        Name = propertyDeclarationSyntax.Identifier.ToString();
        PropertyType = propertyDeclarationSyntax.Type.ToString();
    }
}