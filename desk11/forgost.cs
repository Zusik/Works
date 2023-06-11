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
    public partial class forgost : Form
    {
        public forgost()
        {
            InitializeComponent();
            LoadData();
        }
        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlCommand cm = new SqlCommand();
        SqlConnection con = new SqlConnection(@"Data Source=LAB206-11\SQLEXPRESS;Integrated Security=true; Initial Catalog=ek11;");
        DataSet ds = new DataSet();
        private void LoadData()
        {
            adapter = new SqlDataAdapter("SELECT * FROM Товары", con);
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }
        private void PaintRows()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    if (int.Parse(row.Cells[6].Value.ToString()) > 15)
                        row.DefaultCellStyle.BackColor = Color.Chartreuse;
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }
                catch
                { }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Authorizaton auth = new Authorizaton();
            auth.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                    break;
                case 1:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Действующая скидка] <=9";
                    break;
                case 2:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Действующая скидка] >=10 AND [Действующая скидка] <=14";
                    break;
                case 3:
                    (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"[Действующая скидка] >=15";
                    break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
                    break;
                case 1:
                    dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Descending);
                    break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    pictureBox1.Image = null;
                    break;
                case 1:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\B320R5.jpg");
                    break;
                case 2:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\D329H3.jpg");
                    break;
                case 3:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\D572U8.jpg");
                    break;
                case 4:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\F572H7.jpg");
                    break;
                case 5:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\F635R4.jpg");
                    break;
                case 6:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\G432E4.jpg");
                    break;
                case 7:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\G783F5.jpg");
                    break;
                case 8:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\H782T5.jpg");
                    break;
                case 9:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\J384T6.jpg");
                    break;
                case 10:
                    pictureBox1.Image = Image.FromFile(@"C:\Users\Admin11\Desktop\Вариант 6\Импорт\Товар_import\А112Т4.jpg");
                    break;
            }
        }

        private void forgost_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ek11DataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter.Fill(this.ek11DataSet.Товары);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaintRows();
        }
    }
}
