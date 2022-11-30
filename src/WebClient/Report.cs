using ConsoleTables;

namespace WebClient
{
    public static class Table<T> where T : class, new()
    {
        public static void Create(T item)
        {
            var table = new ConsoleTable(item
                .GetType()
                .GetProperties()
                .Select(p => p.Name)
                .ToArray());

            table.AddRow(item.GetType().GetProperties().Select(p => p.GetValue(item)).ToArray());

            table.Write();

        }
    }
}