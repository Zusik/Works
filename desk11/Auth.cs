using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace desk11
{
    public partial class Authorizaton : Form
    {
        public Authorizaton()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=LAB206-11\SQLEXPRESS;Initial Catalog=ek11;Integrated Security=True");
            string sqlcom = string.Format("SELECT * FROM Users WHERE Login = '"+LoginBox.Text+"' AND Password = '"+PasswordBox.Text+"';");
            SqlCommand check = new SqlCommand(sqlcom, sqlcon);
            sqlcon.Open();
            if (check.ExecuteScalar() != null)
            {
                this.Hide();
                Menu m1 = new Menu();
                m1.Show();
            }
            else
            {
                MessageBox.Show("Учётная запись не найдена");
            }
            sqlcon.Close();
        }
        private void singw_Click(object sender, EventArgs e)
        {
            forgost fg = new forgost();
            fg.Show();
            this.Hide();
        }
    }
}
