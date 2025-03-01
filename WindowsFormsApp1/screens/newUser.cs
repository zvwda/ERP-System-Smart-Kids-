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

namespace WindowsFormsApp1.screens
{
    public partial class newUser : Form
    {
        smartkidsdbEntities db = new smartkidsdbEntities();
        public newUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            users obj = new users();    
            obj.username = textBox1.Text;
            obj.password = textBox2.Text;
            db.users.Add(obj);
            db.SaveChanges();

            MessageBox.Show("تم الحفظ");
           

           
        }

        private void newUser_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = db.users.Where(x => x.password == textBox2.Text && x.username == textBox1.Text);
        }
    }
}
