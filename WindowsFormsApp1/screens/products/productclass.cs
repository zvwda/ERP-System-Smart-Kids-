using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1.screens.products
{
    public partial class productclass : Form
    {
        smartkidsdbEntities db = new smartkidsdbEntities();

        public productclass()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'smartkidsdbDataSet.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.smartkidsdbDataSet.category);

            int maxValue = int.MinValue;
            foreach (var product in db.product)
            {
                if (int.TryParse(product.code, out int codeValue) && codeValue > maxValue)
                {
                    maxValue = codeValue;
                }
            }

            int m = maxValue;
            int y = m + 1; 
            textBox5.Text = y.ToString();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("برجاء اكمال البيانات");  
            }
            else {
                
                var result = db.product.Where(x => x.code == textBox5.Text);
                int res = result.Count();
                if (res > 0)
                {
                    MessageBox.Show("الكود غير صالج");
                }

                else
                {
                    product p = new product();
                    p.price = decimal.Parse(textBox2.Text);
                    p.quantity = int.Parse(textBox4.Text);
                    p.name = textBox1.Text;
                    p.code = textBox5.Text;
                    p.notes = richTextBox1.Text;
                    p.categotyid = int.Parse(comboBox1.SelectedValue.ToString());

                    db.product.Add(p);
                    db.SaveChanges();

                    MessageBox.Show("تم الاضافة ");
                    textBox2.Text = "";
                    textBox4.Text = "";
                    textBox1.Text = "";
                    //textBox5.Text = "";
                    comboBox1.SelectedIndex = 0;
                    richTextBox1.Text = "";

                    int maxValue = int.MinValue;
                    foreach (var product in db.product)
                    {
                        if (int.TryParse(product.code, out int codeValue) && codeValue > maxValue)
                        {
                            maxValue = codeValue;
                        }
                    }

                    int m = maxValue;
                    int y = m + 10;
                    textBox5.Text = y.ToString();



                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            productlist p = new productlist();
            p.Show();
        }
    }
}
