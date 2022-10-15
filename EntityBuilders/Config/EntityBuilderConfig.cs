using Microsoft.CodeAnalysis;

namespace EntityBuilders.Config;

internal class EntityBuilderConfig
{
    public string RootNamespace { get; }
    
    public EntityBuilderConfig(GeneratorExecutionContext context)
    {
        context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("entity_builders.root_namespace",
            out var rootNamespace);
        RootNamespace = rootNamespace ?? "EntityBuilders";
    }
}