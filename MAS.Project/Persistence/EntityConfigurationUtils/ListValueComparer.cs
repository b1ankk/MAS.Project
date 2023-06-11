using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MAS.Project.Persistence.EntityConfigurationUtils;

public class ListValueComparer<T> : ValueComparer<IList<T>>
    where T : IConvertible
{
    public ListValueComparer()
        : base(
            (l, r) => l.SequenceEqual(r),
            list => list.Aggregate(0, (l, r) => HashCode.Combine(l, r.GetHashCode())),
            list => list.ToList()
        ) { }
}
