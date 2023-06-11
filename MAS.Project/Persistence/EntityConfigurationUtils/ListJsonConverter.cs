using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAS.Project.Persistence.EntityConfigurationUtils;

public class ListJsonConverter<T> : ValueConverter<IList<T>, string>
    where T : IConvertible
{
    private static readonly JsonSerializerOptions SerializerOptions = JsonSerializerOptions.Default;

    public ListJsonConverter() : this(null) { }
    
    public ListJsonConverter(ConverterMappingHints? mappingHints)
        : base(
            list => JsonSerializer.Serialize(list, SerializerOptions),
            json => JsonSerializer.Deserialize<IList<T>>(json, SerializerOptions),
            mappingHints
        ) { }
}
