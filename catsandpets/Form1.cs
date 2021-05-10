using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace catsandpets
{
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection connection;
        public Form1()
        { 
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["catsandpets.Properties.Setting.PetsConnectionString"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulatePetsTable();
        }   
        private void PopulatePetsTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT* FROM PetType", connection))
            {
                DataTable petTable =new DataTable();
                adapter.Fill(petTable);

                listPets.DisplayMember ="PetTypeName";
                listPets.ValueMember = "Id";
                listPets.DataSource =petTable;
            }
        }
    }
}
