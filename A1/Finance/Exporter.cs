using TransactionLibrary;

namespace ExportLibrary
{
    public static class Exporter
    {
        public static void ExportToCsv(IEnumerable<Transaction> txns, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            writer.WriteLine("Date,Description,Category,Amount");
            foreach (var t in txns)
            {
                writer.WriteLine($"{t.Date},{t.Description},{t.Category},{t.Amount}");
            }
        }
    }
}
