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

namespace WindowsFormsApp1.sub
{
    public partial class submanage : Form
    {
        smartkidsdbEntities db = new smartkidsdbEntities();

        public submanage()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.supplier.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.supplier.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("برجاء اكمال البيانات");
            }
            else if (db.supplier.Where(x => x.phone == textBox6.Text).Count() > 0) {
                MessageBox.Show("هذا المورد موجود مسبقا"); 
            }
            else
            {
                supplier s = new supplier();
                s.name = textBox7.Text;
                s.phone = textBox6.Text;
                s.combany = textBox4.Text;
                s.address = textBox5.Text;
                s.email = textBox8.Text;
                s.notes = richTextBox1.Text;
                s.active = checkBox1.Checked;

                db.supplier.Add(s);
                db.SaveChanges();

                MessageBox.Show("تم الاضافة ");

                richTextBox1.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                dataGridView1.DataSource = db.supplier.Where(x => x.phone == textBox1.Text).ToList();
            }
            else if (
                textBox1.Text == ""
                )
            {
                dataGridView1.DataSource = db.supplier.Where(x => x.name.Contains(textBox2.Text)).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.supplier.Where(x => x.phone == textBox1.Text || x.name == textBox2.Text).ToList();

            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.supplier.SingleOrDefault(x => x.id == id);

                textBox7.Text = result.name;
                textBox6.Text = result.phone.ToString();
                textBox4.Text = result.combany;
                textBox8.Text = result.email;
                textBox5.Text = result.address;
                checkBox1.Checked = result.active.Value;

            }
            catch { }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.supplier.SingleOrDefault(x => x.id == id);

            if (db.supplier.Where(x => x.phone == textBox6.Text &&  x.id != id).Count() > 0)
            {
                MessageBox.Show("هذا المورد موجود مسبقا");
                return;
            }


            result.name = textBox7.Text;
            result.phone = textBox6.Text;
            result.combany = textBox4.Text;
            result.email = textBox8.Text;
            result.address = textBox5.Text;
            result.active = checkBox1.Checked;
            db.SaveChanges();

            MessageBox.Show("تم التعديل ");
            dataGridView1.DataSource = db.supplier.ToList();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد الحذف", "تأكيد الحذف", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.supplier.Find(id);

                db.supplier.Remove(result);

                db.SaveChanges();

                MessageBox.Show("تم حذف المنتج");

                dataGridView1.DataSource = db.supplier.ToList();

            }
        }

        private void submanage_Load(object sender, EventArgs e)
        {

        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
