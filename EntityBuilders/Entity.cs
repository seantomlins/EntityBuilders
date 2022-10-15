using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders;

internal class Entity
{
    public string Name { get; }
    public string IdPropertyName { get; }
    public string Namespace { get; }

    public IEnumerable<Property> Properties { get; }

    public Entity(ClassDeclarationSyntax classDeclarationSyntax)
    {
        Name = classDeclarationSyntax.Identifier.ToString();
        Namespace = NamespaceParser.GetNamespace(classDeclarationSyntax);
        IdPropertyName = IdPropertyParser.GetIdPropertyName(classDeclarationSyntax);

        Properties = classDeclarationSyntax.Members
            .OfType<PropertyDeclarationSyntax>()
            .Select(x => new Property(x, this));
    }
}

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