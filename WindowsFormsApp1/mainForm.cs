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
using WindowsFormsApp1.screens;
using WindowsFormsApp1.screens.products;
using WindowsFormsApp1.sub;
using WindowsFormsApp1.الفواتير;
using WindowsFormsApp1.الموظفين;

namespace WindowsFormsApp1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newUser n = new newUser();
            n.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void اضافةمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productclass product = new productclass();
            product.Show();
        }

        private void عرضكلالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            productlist p = new productlist();
            p.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            custmanage c = new custmanage();
            c.Show();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            custmanage c = new custmanage();
            c.Show();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            submanage s = new submanage();
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            submanage s = new submanage();
            s.Show();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            productlist p = new productlist();
            p.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            فاتورة f = new فاتورة();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            newUser n = new newUser();  
            n.Show();
        }

        private void التحكمفيالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void فاتورةمشترياتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void فاتورةمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            فاتورة f = new فاتورة();
            f.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            مشتريات p = new مشتريات();
            p.Show();
        }

        private void الموظقينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApp1.الموظفين.الموظفون p = new الموظفون();
            p.Show();

        }
    }
}
