using System.Collections.ObjectModel;

public static class ObservableCollectionExtensions
{
    public static bool RemoveById<T>(this ObservableCollection<T> collection, Guid id) where T : IHasGuid
    {
        var item = collection.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            return collection.Remove(item);
        }
        return false;
    }
}

public interface IHasGuid
{
    Guid Id { get; }
}
