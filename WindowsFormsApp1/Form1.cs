using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DB;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        smartkidsdbEntities db = new smartkidsdbEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            var result = db.users.Where(y => y.username == textBox1.Text && y.password == textBox2.Text).ToList();

            if (result.Count() > 0)
            {
                this.Close();

                Thread th = new Thread(openForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else {
                MessageBox.Show("اسم المستخدم او كلمة المرور خطاء");
            }

        }
        void openForm() {
            Application.Run(new mainForm());
        }
    }
}
