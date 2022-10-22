using EntityBuilders.Parsing;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EntityBuilders.Models;

internal class EntityClass
{
    public string ClassName { get; }
    public string IdPropertyName { get; }
    public string Namespace { get; }

    public ClassDeclarationSyntax ClassDeclaration { get; }

    public EntityClass(ClassDeclarationSyntax classDeclarationSyntax)
    {
        ClassName = classDeclarationSyntax.Identifier.ToString();
        Namespace = NamespaceParser.GetNamespace(classDeclarationSyntax);
        IdPropertyName = IdPropertyParser.GetIdPropertyName(classDeclarationSyntax);
        ClassDeclaration = classDeclarationSyntax;
    }
}