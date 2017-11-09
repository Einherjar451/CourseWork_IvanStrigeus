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

namespace CourseWork_IvanStrigeus {
    public partial class Form1 : Form {
        private const String PATH_DATABASE = @"C:\dir\IVAN_S.db";
        private SQLiteConnection connect;
        private SQLiteDataReader reader;
        private SQLiteCommand command;

        public static String idCard;
        public static String emails;
        public static String balance;
        public static String email;
        public static String name;

        public Form1() {
            InitializeComponent();
        }

        private void db_Conn() {
            try {
                emails = textBox1.Text;
                connect = new SQLiteConnection(string.Format("Data Source={0};", PATH_DATABASE));
                connect.Open();

                command = new SQLiteCommand("SELECT * FROM 'bankuser' WHERE email='" + emails + "';", connect);
                reader = command.ExecuteReader();

                foreach (DbDataRecord record in reader) {
                    email = record["email"].ToString();

                    if (emails.Equals(email)) {
                        idCard = record["idcard"].ToString();
                        name = record["name"].ToString();
                        balance = record["balance"].ToString();

                        label3.Text = balance + "$";
                        label3.Visible = true;
                    }
                    else {
                        MessageBox.Show("Your card id is not register!"); 
                    }
                }
            } catch(SQLiteException) {
                MessageBox.Show("Error To Input!");
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            Form2 form = new Form2();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            db_Conn();
        }

        private void button3_Click(object sender, EventArgs e) {
            Form3 form = new Form3();
            form.Show();
        }
    }
}
