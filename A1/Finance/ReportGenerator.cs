using TransactionLibrary;
using System.Linq;

namespace ReportLibrary
{
    public static class ReportGenerator
    {
        public static double TotalByCategory(IEnumerable<Transaction> txns, string category)
            => txns.Where(t => t.Category == category).Sum(t => t.Amount);

        public static double MonthlyTotal(IEnumerable<Transaction> txns, int month, int year)
            => txns.Where(t => t.Date.Month == month && t.Date.Year == year)
                   .Sum(t => t.Amount);
    }
}
