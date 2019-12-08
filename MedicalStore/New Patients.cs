using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace MedicalStore
{
    public partial class New_Patients : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HospitalManagementDb;Integrated Security=True");
        public New_Patients()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBox_image_path.Text == "")
            {
                textBox_image_path.Text = @"C:\\Users\\student\\OneDrive\\Pictures\\nasiha image.jpg";
            }
            else
            {
                byte[] imageBt = null;
                FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fstream);
                imageBt = br.ReadBytes((int)fstream.Length);

                try
                {
                    con.Open();
                    string str = "insert into patient (PatientName,GenderId,RegistratioDate,age,Address,Mobile,Disease,picture,Email,NID) values('" + txtPatientName.Text + "'," + gender + ",'" + dateTimePicker2.Value.ToShortDateString() + "','" + txtAge.Text + "','" + txtAddrs.Text + "','" + txtMobileNo.Text + "','" + txtDisease.Text + "',@img,'" + txtEmail.Text + "','" + txtNid.Text + "')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.Parameters.Add(new SqlParameter("@img", imageBt));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Insert Successfully !!");
                }

                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
                LoadGrid();
            }
        }
        int gender = 1;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = 2;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox_image_path.Text == "")
            {
                textBox_image_path.Text = @"C:\\Users\\student\\OneDrive\\Pictures\\nasiha image.jpg";
            }
            else
            {
                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Please Enter Patient Id to Update !!");
                    txtSearch.BackColor = Color.LightYellow;
                    txtSearch.Focus();
                }
                else
                {
                    byte[] imageBt = null;

                    FileStream fstream = new FileStream(this.textBox_image_path.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fstream);
                    imageBt = br.ReadBytes((int)fstream.Length);

                    try
                    {
                        con.Open();
                        string str = "update patient set PatientName='" + txtPatientName.Text + "',GenderId='" + gender + "',RegistratioDate='" + dateTimePicker2.Value.ToShortDateString() + "',age=" + txtAge.Text + ",Address='" + txtAddrs.Text + "',Mobile='" + txtMobileNo.Text + "',Disease='" + txtDisease.Text + "',email='" + txtEmail.Text + "',nid='" + txtNid.Text + "',picture=@img where PatientId =" + txtSearch.Text + "";
                        SqlCommand cmd = new SqlCommand(str, con);
                        cmd.Parameters.Add(new SqlParameter("@img", imageBt));
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated Successfully !!");
                    }
                    catch (SqlException excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
                con.Close();
                LoadGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = "delete Patient where PatientId =" + txtSearch.Text + "";
                SqlCommand cmd = new SqlCommand(str, con);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient ID: " + txtSearch.Text + " Deleted Successfully !!");
                con.Close();
                LoadGrid();
            }
            catch (SqlException sqEx)
            {

                if (sqEx.Number == 547)
                {
                    MessageBox.Show("This Patient Has an Appointment !! Please Delete The Appointment First !!");
                }
                else
                {
                    MessageBox.Show(sqEx.Message);
                }
            }
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select PatientId,PatientName from patient", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please Enter Patient ID !!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from patient where patientid=" + txtSearch.Text + "", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtPatientName.Text = dr["patientName"].ToString();
                    txtAddrs.Text = dr["Address"].ToString();
                    dateTimePicker2.Text = dr["RegistratioDate"].ToString();
                    txtMobileNo.Text = dr["mobile"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtAge.Text = dr["age"].ToString();
                    txtDisease.Text = dr["Disease"].ToString();
                    txtAge.Text = dr["age"].ToString();
                    txtNid.Text = dr["nid"].ToString();

                    if (dr["picture"].ToString() == "")
                    {
                        pictureBox1.Image = null;
                        //this.textBox_image_path.Text = "";
                    }
                    else
                    {
                        byte[] imgg = (byte[])(dr["picture"]);
                        //this.textBox_image_path.Text=/*imgg*/.
                        MemoryStream stream = new MemoryStream(imgg);
                        pictureBox1.Image = System.Drawing.Image.FromStream(stream);
                    }
                }
                dr.Close();

                ///////////////To Show in Grid\\\\\\\\\\\\\\\\\\\\\
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Patient found !!");
                }
                con.Close();
                //LoadGridOnSearch();                
            }
        }

        private void New_Patients_Load(object sender, EventArgs e)
        {
            LoadGrid();
            MaximizeBox = true;
            textBox_image_path.Hide();
            textBox_image_path.Text = @"C:\\Users\\student\\OneDrive\\Pictures\\nasiha image.jpg";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.* ";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                textBox_image_path.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
        }

        private void btnChangePic_Click(object sender, EventArgs e)
        {

        }
    }
}
