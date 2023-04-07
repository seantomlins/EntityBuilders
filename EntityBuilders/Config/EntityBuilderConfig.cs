using Microsoft.CodeAnalysis;

namespace EntityBuilders.Config;

internal class EntityBuilderConfig
{
    public string RootNamespace { get; }

    public string EntitiesNamespace { get; }
    
    public EntityBuilderConfig(GeneratorExecutionContext context)
    {
        context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("entity_builders.generated_code_namespace",
            out var rootNamespace);
        context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("entity_builders.source_entities_namespace",
            out var entitiesNamespace);
        RootNamespace = rootNamespace ?? "EntityBuilders";
        EntitiesNamespace = entitiesNamespace ?? "";
    }
}