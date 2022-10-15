using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders;

internal static class IdPropertyParser
{
    public static string GetIdPropertyName(ClassDeclarationSyntax classDeclarationSyntax)
    {
        var properties = classDeclarationSyntax.Members
            .OfType<PropertyDeclarationSyntax>();

        return properties.Any(x => x.Identifier.ToString().Equals("Id"))
            ? "Id"
            : $"{classDeclarationSyntax.Identifier}Id";
    }
}