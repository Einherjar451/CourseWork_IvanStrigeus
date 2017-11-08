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
    
    public partial class Form2 : Form {
        private String numberCard;
        private String name;
        private String email;
        private int balance;
        private Random random;

        private const String PATH_DATABASE = @"C:\dir\IVAN_S.db";
        private SQLiteConnection connect;
        private SQLiteCommand command;

        private String sqlite_Command;

        public Form2() {
            InitializeComponent();
        }
        private void dbConnectAndProcess() {
            try {
                random = new Random();
                
                numberCard = random.Next(100000000, 999999999).ToString();
                name = textBox1.Text;
                email = textBox2.Text;
                balance = Convert.ToInt32(textBox3.Text);

                connect = new SQLiteConnection(string.Format("Data Source={0};", PATH_DATABASE));
                connect.Open();

                sqlite_Command = "INSERT INTO bankuser(email,name,idcard,balance)VALUES('" + email + "','" + name + "','" + numberCard + "'," + balance + ");";

                command = new SQLiteCommand(sqlite_Command, connect);
                command.ExecuteNonQuery();
                connect.Close();

                Form2.ActiveForm.Close();
            }// catch(SQLiteException) {
            //    MessageBox.Show("Non Correct Input!");
                
            //    textBox1.Clear();
            //    textBox2.Clear();
            //    textBox3.Clear();
            //}
            catch(System.FormatException) {
                MessageBox.Show("Not Correct Input!");
                
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            dbConnectAndProcess();
        }
    }
}
