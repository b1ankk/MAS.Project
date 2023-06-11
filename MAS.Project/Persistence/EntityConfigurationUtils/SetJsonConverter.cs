using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAS.Project.Persistence.EntityConfigurationUtils;

public class SetJsonConverter<T> : ValueConverter<ISet<T>, string>
    where T : IConvertible
{
    private static readonly JsonSerializerOptions SerializerOptions = JsonSerializerOptions.Default;

    public SetJsonConverter() : this(null) { }

    public SetJsonConverter(ConverterMappingHints? mappingHints)
        : base(
            list => JsonSerializer.Serialize(list, SerializerOptions),
            json => JsonSerializer.Deserialize<ISet<T>>(json, SerializerOptions),
            mappingHints
        ) { }
}
