using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MAS.Project.Persistence.EntityConfigurationUtils;

public class SetValueComparer<T> : ValueComparer<ISet<T>>
    where T : IConvertible
{
    public SetValueComparer()
        : base(
            (l, r) => l.SequenceEqual(r),
            list => list.Aggregate(0, (l, r) => HashCode.Combine(l, r.GetHashCode())),
            list => list.ToHashSet()
        ) { }
}
