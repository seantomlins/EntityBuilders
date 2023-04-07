using System.Text;
using EntityBuilders.Config;
using EntityBuilders.Models;
using EntityBuilders.Parsing;
using EntityBuilders.Templates;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;

namespace EntityBuilders;

[Generator]
public class EntityBuilderGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var config = new EntityBuilderConfig(context);

        AddIdProvidersSource(context, config);

        foreach (var entity in EntityParser.GetEntities(context, config))
        {
            AddEntityBuilderSourceFor(entity, context, config);
        }
    }

    private static void AddIdProvidersSource(GeneratorExecutionContext context, EntityBuilderConfig config)
    {
        var sourceText = SourceText.From(IdProvidersTemplate.GenerateSource(config), Encoding.UTF8);
        
        context.AddSource("IdProviders.g.cs", sourceText);
    }

    private static void AddEntityBuilderSourceFor(Entity entityClass,
        GeneratorExecutionContext context,
        EntityBuilderConfig config)
    {
        var sourceText = SourceText.From(EntityBuilderTemplate.GenerateSource(entityClass, config), Encoding.UTF8);

        context.AddSource($"{entityClass.Name}Builder.g.cs", sourceText);
    }
}