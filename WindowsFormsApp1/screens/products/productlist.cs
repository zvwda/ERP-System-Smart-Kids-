using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1.screens.products
{
    public partial class productlist : Form
    {
        smartkidsdbEntities db = new smartkidsdbEntities();

        public productlist()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.product.ToList();
            comboBox1.DataSource = db.category.ToList(); 
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            else {
                dataGridView1.DataSource = db.product.Where(x => x.code == textBox1.Text || x.name.Contains(textBox2.Text)).ToList();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.product.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.product.SingleOrDefault(x => x.id == id);

                textBox7.Text = result.name;
                textBox6.Text = result.price.ToString();
                textBox4.Text = result.quantity.ToString();
                textBox8.Text = result.code.ToString();
                comboBox1.SelectedValue = result.categotyid;

            }
            catch { }
        }

        private void productlist_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'smartkidsdbDataSet2.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter1.Fill(this.smartkidsdbDataSet2.category);
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.product.SingleOrDefault(x => x.id == id);
                
            result.name = textBox7.Text;
            result.price = decimal.Parse(textBox6.Text);
            if (textBox5.Text != "")
            {
                result.quantity = int.Parse(textBox5.Text) + result.quantity;
            }
            result.code = textBox8.Text;
            result.categotyid = int.Parse(comboBox1.SelectedValue.ToString());  

            db.SaveChanges();

            MessageBox.Show("تم التعديل علي المنتج");
            dataGridView1.DataSource = db.product.ToList();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var r =  MessageBox.Show("هل تريد الحذف", "تأكيد الحذف" , MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.product.Find(id);

                db.product.Remove(result);

                db.SaveChanges();

                MessageBox.Show("تم حذف المنتج");

                dataGridView1.DataSource = db.product.ToList();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }
}
