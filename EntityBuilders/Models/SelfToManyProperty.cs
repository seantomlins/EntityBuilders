namespace EntityBuilders.Models;

internal class SelfToManyProperty
{
    public Property CollectionProperty { get; }
    public EntityClass CollectionEntityClass { get; }

    public SelfToManyProperty(Property collectionProperty, EntityClass collectionEntityClass)
    {
        CollectionProperty = collectionProperty;
        CollectionEntityClass = collectionEntityClass;
    }
}