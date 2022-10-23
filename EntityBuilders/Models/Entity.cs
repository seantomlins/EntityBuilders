using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders.Models;

internal class Entity
{
    public string Name { get; }
    public string IdPropertyName { get; }
    public string Namespace { get; }

    public IEnumerable<Property> Properties { get; }
    public IEnumerable<SelfToOneProperty> SelfToOneProperties { get; }
    public IEnumerable<SelfToManyProperty> SelfToManyProperties { get; }

    public Entity(EntityClass entityClass, IEnumerable<EntityClass> entities)
    {
        Name = entityClass.ClassName;
        IdPropertyName = entityClass.IdPropertyName;
        Namespace = entityClass.Namespace;

        var properties = entityClass.ClassDeclaration.Members
            .OfType<PropertyDeclarationSyntax>()
            .Select(x => new Property(x))
            .ToList();

        var foreignKeyProperties = properties
            .Where(x => !x.Name.Equals(IdPropertyName) && x.Name.EndsWith("Id"))
            .ToList();

        var navigationProperties = properties
            .Where(x => entities.Any(y => y.ClassName.Equals(x.PropertyType)))
            .ToList();

        var navigationCollectionProperties = properties
            .Where(x => entities.Any(y => x.PropertyType.Equals($"ICollection<{y.ClassName}>")))
            .ToList();

        Properties = properties
            .Except(foreignKeyProperties)
            .Except(navigationProperties)
            .Except(navigationCollectionProperties);

        SelfToOneProperties = navigationProperties.Select(x =>
            new SelfToOneProperty(x,
                foreignKeyProperties.FirstOrDefault(y => y.Name.StartsWith(x.Name.Substring(0, x.Name.Length - 2))))
        );

        SelfToManyProperties = navigationCollectionProperties.Select(x =>
            new SelfToManyProperty(x, entities.First(y => x.PropertyType.Equals($"ICollection<{y.ClassName}>"))));
    }
}