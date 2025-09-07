using System;
using System.Windows.Forms;
using TransactionLibrary;
using ReportLibrary;
using ExportLibrary;

namespace FinanceManagerApp
{
    public partial class Form1 : Form
    {
        private TransactionManager manager = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            double amount = double.TryParse(txtAmount.Text, out var a) ? a : 0;
            string category = cmbCategory.Text;
            manager.AddTransaction(txtDesc.Text, amount, category);

            lblBalance.Text = $"Balance: {manager.GetBalance():C}";
            txtDesc.Clear();
            txtAmount.Clear();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            string category = cmbCategory.Text;
            var total = ReportGenerator.TotalByCategory(manager.GetAll(), category);
            MessageBox.Show($"Total for {category}: {total:C}");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Exporter.ExportToCsv(manager.GetAll(), "transactions.csv");
            MessageBox.Show("Export complete: transactions.csv");
        }
    }
}
