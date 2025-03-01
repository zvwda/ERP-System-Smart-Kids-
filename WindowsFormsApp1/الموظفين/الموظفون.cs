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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.الموظفين
{
    public partial class الموظفون : Form
    {
        smartkidsdbEntities db = new smartkidsdbEntities();

        public الموظفون()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.mozaf.ToList();

        }

        private void الموظفون_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            try
            {

                int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var result = db.mozaf.SingleOrDefault(x => x.id == id);

                textBox7.Text = result.name;
                textBox6.Text = result.counter.ToString();
               
            }
            catch { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.mozaf.SingleOrDefault(x => x.id == id);

            result.name = textBox7.Text;
            result.counter = int.Parse(textBox6.Text) + 1;

            db.SaveChanges();
            MessageBox.Show("تم اضافة اليوم");
            textBox6.Text = result.counter.ToString();
            dataGridView1.DataSource = db.mozaf.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.mozaf.SingleOrDefault(x => x.id == id);

            
            result.counter = 0;

            db.SaveChanges();
            MessageBox.Show("تم تصفير الايام");
            textBox6.Text = "0";
            dataGridView1.DataSource = db.mozaf.ToList();
        }
    }
}
