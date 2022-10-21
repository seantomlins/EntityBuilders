using EntityBuilders.Templates;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders.Models;

internal class Entity
{
    public string Name { get; }
    public string IdPropertyName { get; }
    public string Namespace { get; }

    public IEnumerable<Property> Properties { get; }
    public IEnumerable<NavigationAndForeignKeyProperty> SelfToOneProperties { get; }

    public Entity(EntityClass entityClass, IEnumerable<EntityClass> entities)
    {
        Name = entityClass.Name;
        IdPropertyName = entityClass.IdPropertyName;
        Namespace = entityClass.Namespace;

        var properties = entityClass.ClassDeclaration.Members
            .OfType<PropertyDeclarationSyntax>()
            .Select(x => new Property(x))
            .ToList();

        var foreignKeyProperties = properties.Where(x => !x.Name.Equals(IdPropertyName) && x.Name.EndsWith("Id")).ToList();

        var navigationProperties = properties.Where(x => entities.Any(y => y.Name.Equals(x.PropertyType))).ToList();

        Properties = properties.Except(foreignKeyProperties).Except(navigationProperties);

        SelfToOneProperties = navigationProperties.Select(x =>
            new NavigationAndForeignKeyProperty(x, foreignKeyProperties.FirstOrDefault(y => y.Name.StartsWith(x.Name.Substring(0, x.Name.Length - 2))))
        );
    }
}