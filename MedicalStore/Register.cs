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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HospitalManagementDb;Integrated Security=True");

            try
            {
                con.Open();
                string str = "insert into Users values ('" + txtName.Text + "','" + txtPassword.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("User Registered Successfully !!");
            }
            catch (SqlException sqEx)
            {
                if (sqEx.Number== 2601)
                {
                    MessageBox.Show("This UserName Alreadey Taken!!");
                }
                else
                {
                    MessageBox.Show(sqEx.Message);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Register Not Successful");
            }
            new LogIn().Show();
            this.Hide();
        }
    }
}
