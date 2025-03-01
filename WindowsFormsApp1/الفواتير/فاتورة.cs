using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.cust;
using WindowsFormsApp1.DB;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.الفواتير
{
    public partial class فاتورة : Form
    {
        smartkidsdbEntities db = new smartkidsdbEntities();

        public فاتورة()
        {
            InitializeComponent();
            
            comboBox2.DataSource = db.category.ToList();
            dataGridView1.DataSource = db.product.ToList();
        }

        private void فاتورة_Load(object sender, EventArgs e)
        {
            fatora2 f = new fatora2();
            f.number = int.Parse(textBox6.Text);
            int result = db.fatora2.Count();
            textBox3.Text ="0000"+result;

            db.fatora2.Add(f);
            db.SaveChanges();
            textBox4.Text = DateTime.Now.ToString("yyyy/MM/dd");


            foreach (DataGridViewColumn col in dataGridView2.Columns) { 
                col.DefaultCellStyle.ForeColor= Color.Navy;
                
            }
            dataGridView2.Columns[3].DefaultCellStyle.ForeColor= Color.Red;


            textBox5.Focus();
            textBox5.Select();
            textBox5.SelectAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                dataGridView1.DataSource = db.product.Where(x => x.code == textBox1.Text).ToList();
            }
            else if (textBox1.Text == "") {
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.product.SingleOrDefault(x => x.id == id);

                


                string name = result.name;
                int qty = int.Parse(textBox6.Text);

                if (qty > result.quantity)
                {
                    MessageBox.Show("الكمية المطلوبة غير متاحة");
                    textBox6.Text = "1";
                }

                else
                {
                    result.quantity -=  qty;
                    double price = (double)result.price;
                    double local_total = price * qty;
                    int id1 = int.Parse(result.id.ToString());

                   
                    object[] row = {id1 , name, qty, price, local_total };
                    dataGridView2.Rows.Add(row);


                    double total = 0; 
                    for (int x = 0; x < dataGridView2.Rows.Count; x += 1)
                    {
                          double temp = double.Parse(dataGridView2.Rows[x].Cells[4].Value.ToString());
                        total += temp;
                    }
                    textBox7.Text = total.ToString();




                      textBox6.Text = "1";
                    textBox2.Text = "";
                    textBox1.Text = "";


                    dataGridView1.DataSource = db.product.ToList();
                }
            }
            catch { }


        }
        private void button7_Click(object sender, EventArgs e)
        {

            int id = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
            var result = db.product.SingleOrDefault(x => x.id == id);

            int q = int.Parse(dataGridView2.CurrentRow.Cells[2].Value.ToString());
            double p = double.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());



            MessageBox.Show(q.ToString());
            MessageBox.Show(result.quantity.ToString());
            result.quantity = result.quantity + q;

            double n = double.Parse(textBox7.Text.ToString());
            double t = n - p;
            textBox7.Text = t.ToString();
            
            db.SaveChanges();

            dataGridView2.Rows.Remove(dataGridView2.CurrentRow);
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //for (int x = 0; x < dataGridView2.Rows.Count; x += 1)
            //{
            //    int id1 = int.Parse(dataGridView2.Rows[x].Cells[0].Value.ToString());
            //    var result2 = db.product.SingleOrDefault(y => y.id == id1);

            //    int curqty = int.Parse(dataGridView2.Rows[x].Cells[1].Value.ToString());

            //    result2.quantity = result2.quantity - curqty;
            //    db.SaveChanges();
            //}

       
                ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK) {
                printDocument1.Print();
            }






        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Image image = Image.FromFile("C:\\Users\\hp10\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\الفواتير\\i.png");
            
            float margin = 40;
            Font f = new Font("Arial", 18, FontStyle.Bold);
            
            string strNO = "#NO " + textBox3.Text;
            string strdate = "التاريخ: " + textBox4.Text;
            string strname = "مطلوب من السيد: " + textBox5.Text;

            SizeF fontsizeNO = e.Graphics.MeasureString(strNO, f);
            SizeF fontsizedate = e.Graphics.MeasureString(strdate, f);
            SizeF fontsizename = e.Graphics.MeasureString(strname, f);


            e.Graphics.DrawImage(image, 50,50,150,100);
            e.Graphics.DrawString(strNO, f,Brushes.Red,(e.PageBounds.Width - fontsizeNO.Width)/2 ,margin);
            e.Graphics.DrawString(strdate, f, Brushes.Black, e.PageBounds.Width - fontsizedate.Width - margin, margin + fontsizeNO.Height);
            e.Graphics.DrawString(strname, f, Brushes.Navy, e.PageBounds.Width - fontsizedate.Width - margin, margin + fontsizeNO.Height + fontsizedate.Height);

            float perhights = margin + fontsizeNO.Height + fontsizename.Height + fontsizedate.Height + 40;

            e.Graphics.DrawRectangle(Pens.Black, margin, perhights, e.PageBounds.Width - margin * 2, e.PageBounds.Height - margin - perhights);

            float colhight = 60;
            float col1width = 300;
            float col2width = 125 + col1width;
            float col3width = 125 + col2width;
            float col4width = 125 + col3width;

            e.Graphics.DrawLine(Pens.Black, margin, perhights + colhight, e.PageBounds.Width - margin, perhights + colhight);

            e.Graphics.DrawString("الاسم", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col1width +140, perhights +13);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col1width, perhights, e.PageBounds.Width - margin * 2 - col1width, e.PageBounds.Height - margin);

            e.Graphics.DrawString("الكمية", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col2width +35, perhights+15);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col2width, perhights, e.PageBounds.Width - margin * 2 - col2width, e.PageBounds.Height - margin);

            e.Graphics.DrawString("السعر", f, Brushes.Black, e.PageBounds.Width - margin * 2 - col3width+35, perhights + 15);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - col3width, perhights, e.PageBounds.Width - margin * 2 - col3width, e.PageBounds.Height - margin);


            e.Graphics.DrawString("الاجمالي", f, Brushes.Red, e.PageBounds.Width - margin * 2 - col4width +5, perhights + 15);

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            float rowhigh = 60;
            for (int x = 0; x < dataGridView2.Rows.Count; x += 1) {

                e.Graphics.DrawString(dataGridView2.Rows[x].Cells[1].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col1width + 120, perhights + rowhigh +10);
                e.Graphics.DrawString(dataGridView2.Rows[x].Cells[2].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col2width + +49, perhights + rowhigh + 10);
                e.Graphics.DrawString(dataGridView2.Rows[x].Cells[3].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col3width + 45, perhights + rowhigh + 10);
                e.Graphics.DrawString(dataGridView2.Rows[x].Cells[4].Value.ToString(), f, Brushes.Navy, e.PageBounds.Width - margin * 2 - col4width + 10, perhights + rowhigh + 10);
                e.Graphics.DrawLine(Pens.Black, margin, perhights + rowhigh + colhight, e.PageBounds.Width - margin, perhights + rowhigh + colhight);

                rowhigh += 60;

                

            }
            e.Graphics.DrawString("الاجمالي", f, Brushes.Red, e.PageBounds.Width - margin * 2 - col3width + 35, perhights + rowhigh + 10);
            e.Graphics.DrawString(textBox7.Text, f, Brushes.Red, e.PageBounds.Width - margin * 2 - col4width + 10, perhights + rowhigh + 10);
            e.Graphics.DrawLine(Pens.Black, margin, perhights + rowhigh + colhight, e.PageBounds.Width - margin, perhights + rowhigh + colhight);




        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            custmanage c = new custmanage();    
            c.Show();
        }
    }
}
