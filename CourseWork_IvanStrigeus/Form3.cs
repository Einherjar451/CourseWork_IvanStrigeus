using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Common;

namespace CourseWork_IvanStrigeus
{
    public partial class Form3 : Form
    {
        public Form3() {
            InitializeComponent();

            label5.Text = Form1.idCard;
            label6.Text = Form1.name;
            label7.Text = Form1.email;
            label8.Text = Form1.balance;
        }

        private void button1_Click(object sender, EventArgs e) {
            Form3.ActiveForm.Close();
        }

    }
}
