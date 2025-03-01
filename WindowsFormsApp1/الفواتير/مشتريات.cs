using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.cust;
using WindowsFormsApp1.DB;
using WindowsFormsApp1.screens.products;
using WindowsFormsApp1.sub;

namespace WindowsFormsApp1.الفواتير
{
    public partial class مشتريات : Form
    {
        smartkidsdbEntities db = new smartkidsdbEntities();
        public مشتريات()
        {
            InitializeComponent();
            comboBox2.DataSource = db.category.ToList();
            dataGridView1.DataSource = db.product.ToList();
        }

        private void مشتريات_Load(object sender, EventArgs e)
        {
            fatora2 f = new fatora2();
            f.number = int.Parse(textBox6.Text);
            int result = db.fatora2.Count();
            textBox3.Text = "0000" + result;

            db.fatora2.Add(f);
            db.SaveChanges();
            textBox4.Text = DateTime.Now.ToString("yyyy/MM/dd");


            foreach (DataGridViewColumn col in dataGridView2.Columns)
            {
                col.DefaultCellStyle.ForeColor = Color.Navy;

            }
            dataGridView2.Columns[3].DefaultCellStyle.ForeColor = Color.Red;


            textBox5.Focus();
            textBox5.Select();
            textBox5.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                dataGridView1.DataSource = db.product.Where(x => x.code == textBox1.Text).ToList();
            }
            else if (textBox1.Text == "")
            {
                dataGridView1.DataSource = db.product.Where(x => x.name.Contains(textBox2.Text)).ToList();

            }
            else
            {
                dataGridView1.DataSource = db.product.Where(x => x.code == textBox1.Text || x.name.Contains(textBox2.Text)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.product.ToList();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int catid = int.Parse(comboBox2.SelectedValue.ToString());
                dataGridView1.DataSource = db.product.Where(x => x.categotyid == catid).ToList();
            }
            catch { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.product.SingleOrDefault(x => x.id == id);


                if (textBox8.Text != "")
                {
                    result.price = int.Parse(textBox8.Text);
                }
                if (textBox5.Text != "")
                {
                    result.quantity = int.Parse(textBox6.Text) + result.quantity;
                }
                db.SaveChanges();

                string name = result.name;
                int qty = int.Parse(textBox6.Text);
                double price = (double)result.price;
                double local_total = price * qty;

                object[] row = { name, qty, price, local_total };
                dataGridView2.Rows.Add(row);

                textBox7.Text = (Convert.ToDouble(textBox7.Text) + local_total).ToString();

                textBox6.Text = "1";
                textBox2.Text = "";
                textBox1.Text = "";
                textBox8.Text = "";

                MessageBox.Show("تم اضافة المنتج الي المخزون");

                dataGridView1.DataSource = db.product.ToList();
            }
            catch { }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
        }

        private void button3_Click(object sender, EventArgs e)
        {
             submanage c = new submanage();
             c.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            productclass p = new productclass();
            p.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
