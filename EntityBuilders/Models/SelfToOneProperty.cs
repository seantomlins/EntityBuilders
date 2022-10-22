namespace EntityBuilders.Models;

internal class SelfToOneProperty
{
    public Property NavigationProperty { get; }
    public Property? ForeignKeyProperty { get; }

    public SelfToOneProperty(Property navigationProperty, Property? foreignKeyProperty)
    {
        NavigationProperty = navigationProperty;
        ForeignKeyProperty = foreignKeyProperty;
    }
}