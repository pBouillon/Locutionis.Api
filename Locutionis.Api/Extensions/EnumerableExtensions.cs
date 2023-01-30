namespace Locutionis.Api.Extensions;

public static class EnumerableExtensions
{
    public static T PickRandomly<T>(this IList<T> list)
    {
        var random = new Random();
        var index = random.Next(list.Count);
        return list[index];
    }

    public static List<T> Shuffled<T>(this IEnumerable<T> list)
    {
        var random = new Random();

        return list
            .OrderBy(_ => random.Next())
            .ToList();
    }
}