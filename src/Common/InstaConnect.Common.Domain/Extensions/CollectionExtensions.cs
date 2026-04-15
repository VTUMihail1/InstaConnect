namespace InstaConnect.Common.Domain.Extensions;

public static class CollectionExtensions
{
    extension<T>(ICollection<T> collection)
    {
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }
    }
}
