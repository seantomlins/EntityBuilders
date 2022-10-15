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

        IdProvidersGenerator.AddSource(context, config);

        var entities = EntityParser.GetEntities(context);

        foreach (var entity in entities)
        {
            AddBuilderSourceFor(entity, context, config);
        }
    }

    private static void AddBuilderSourceFor(Entity entity,
        GeneratorExecutionContext context,
        EntityBuilderConfig config)
    {
        var sourceText = SourceText.From(EntityBuilderTemplate.CreateFrom(entity, config), Encoding.UTF8);

        context.AddSource($"{entity.Name}.g.cs", sourceText);
    }
}