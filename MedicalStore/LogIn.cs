using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MedicalStore
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HospitalManagementDb;Integrated Security=True");
            con.Open();

                string str = "select * from Users where userName='"+txtUserName.Text+"' and password='"+txtPassword.Text+"'";
                SqlCommand cmd = new SqlCommand(str, con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    this.Visible = false;
                    Home obj2 = new Home();
                    obj2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid username and Password.");
                }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = true;
        }
    }
}
