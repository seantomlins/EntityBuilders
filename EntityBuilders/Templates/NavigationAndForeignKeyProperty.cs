using EntityBuilders.Models;

namespace EntityBuilders.Templates;

internal class NavigationAndForeignKeyProperty
{
    public Property NavigationProperty { get; }
    public Property? ForeignKeyProperty { get; }

    public NavigationAndForeignKeyProperty(Property navigationProperty, Property? foreignKeyProperty)
    {
        NavigationProperty = navigationProperty;
        ForeignKeyProperty = foreignKeyProperty;
    }
}