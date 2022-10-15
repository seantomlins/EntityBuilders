using System.Text;
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

        foreach (var entity in EntityParser.GetEntities(context))
        {
            AddEntityBuilderSourceFor(entity, context, config);
        }
    }

    private static void AddIdProvidersSource(GeneratorExecutionContext context, EntityBuilderConfig config)
    {
        var sourceText = SourceText.From(IdProvidersTemplate.GenerateSource(config), Encoding.UTF8);
        
        context.AddSource("IdProviders.g.cs", sourceText);
    }

    private static void AddEntityBuilderSourceFor(Entity entity,
        GeneratorExecutionContext context,
        EntityBuilderConfig config)
    {
        var sourceText = SourceText.From(EntityBuilderTemplate.GenerateSource(entity, config), Encoding.UTF8);

        context.AddSource($"{entity.Name}.g.cs", sourceText);
    }
}