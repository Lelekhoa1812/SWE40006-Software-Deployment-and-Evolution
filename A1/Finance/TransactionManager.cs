namespace TransactionLibrary
{
    public class Transaction
    {
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; }
    }

    public class TransactionManager
    {
        private List<Transaction> transactions = new();

        public void AddTransaction(string desc, double amount, string category)
        {
            transactions.Add(new Transaction
            {
                Description = desc,
                Amount = amount,
                Category = category,
                Date = DateTime.Now
            });
        }

        public IEnumerable<Transaction> GetAll() => transactions;

        public double GetBalance() => transactions.Sum(t => t.Amount);
    }
}
