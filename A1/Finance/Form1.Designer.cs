namespace FinanceManagerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblBalance;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(90, 20);
            this.lblTitle.Text = "Personal Finance Manager";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(30, 70);
            this.lblDesc.Text = "Description:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(30, 100);
            this.lblAmount.Text = "Amount:";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(30, 130);
            this.lblCategory.Text = "Category:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(120, 67);
            this.txtDesc.Size = new System.Drawing.Size(150, 20);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(120, 97);
            this.txtAmount.Size = new System.Drawing.Size(150, 20);
            // 
            // cmbCategory
            // 
            this.cmbCategory.Location = new System.Drawing.Point(120, 127);
            this.cmbCategory.Size = new System.Drawing.Size(150, 21);
            this.cmbCategory.Items.AddRange(new object[] { "Income", "Food", "Transport", "Bills", "Entertainment" });
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(30, 170);
            this.btnAdd.Size = new System.Drawing.Size(80, 30);
            this.btnAdd.Text = "Add Txn";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(120, 170);
            this.btnReport.Size = new System.Drawing.Size(80, 30);
            this.btnReport.Text = "Category Report";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(210, 170);
            this.btnExport.Size = new System.Drawing.Size(80, 30);
            this.btnExport.Text = "Export CSV";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblBalance.Location = new System.Drawing.Point(30, 220);
            this.lblBalance.Text = "Balance: $0.00";
            // 
            // Form
            // 
            this.ClientSize = new System.Drawing.Size(350, 270);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblBalance);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Finance Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
