using EntityBuilders.Models;

namespace EntityBuilders.Templates;

internal class NavigationAndForeignKeyProperty
{
    public Property ForeignKeyProperty { get; }
    public Property NavigationProperty { get; }

    public NavigationAndForeignKeyProperty(Property foreignKeyProperty, Property navigationProperty)
    {
        ForeignKeyProperty = foreignKeyProperty;
        NavigationProperty = navigationProperty;
    }
}