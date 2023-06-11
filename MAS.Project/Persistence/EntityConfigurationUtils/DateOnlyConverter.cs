using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAS.Project.Persistence.EntityConfigurationUtils;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter()
        : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime)
        ) { }
}
