using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ccsistema
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); 
        }
    }
}


namespace ccsistema
{
    public partial class MainForm : Form
    {
        private string connectionString = "Server=localhost;Database=CCLounge;Uid=root;Pwd=senha;";

        private DataGridView computersGridView;
        private DataGridView inventoryGridView;

        public MainForm()
        {
            InitializeComponent();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        private void LoadComputers()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var query = "SELECT * FROM cabine";  
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    computersGridView.DataSource = dt;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar cabines: " + ex.Message);
            }
        }

        private void LoadInventory()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    var query = "SELECT * FROM estoque";  
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    inventoryGridView.DataSource = dt;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar estoque: " + ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadComputers();
            LoadInventory();
        }

        private void InitializeComponent()
        {
            this.computersGridView = new System.Windows.Forms.DataGridView();
            this.inventoryGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.computersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).BeginInit();
            this.SuspendLayout();
            
            this.computersGridView.AccessibleName = "computersGridView";
            this.computersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.computersGridView.Location = new System.Drawing.Point(12, 24);
            this.computersGridView.Name = "computersGridView";
            this.computersGridView.Size = new System.Drawing.Size(240, 150);
            this.computersGridView.TabIndex = 0;
             
            this.inventoryGridView.AccessibleName = "inventoryGridView";
            this.inventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryGridView.Location = new System.Drawing.Point(12, 180);
            this.inventoryGridView.Name = "inventoryGridView";
            this.inventoryGridView.Size = new System.Drawing.Size(240, 150);
            this.inventoryGridView.TabIndex = 1;
            
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.inventoryGridView);
            this.Controls.Add(this.computersGridView);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.computersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
