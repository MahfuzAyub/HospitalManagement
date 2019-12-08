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
    public partial class NewDoctor : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HospitalManagementDb;Integrated Security=True");
        
        public NewDoctor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// /////////Insert New Doctor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = "insert into doctor values('" + txtDoctorName.Text + "'," + cmbDesignation.SelectedValue + "," + cmbSpeciality.SelectedValue + ",'" + txtMobileNo.Text + "','" + txtAddress.Text + "','" + txtEmail.Text + "','" + Gender + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + txtNid.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();          
                MessageBox.Show("success!");                
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
            LoadGrid();
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select d.DoctorId,d.DoctorName,dg.Designation,sp.Speciality,d.MobileNo,d.Address,d.Email,g.Gender,d.JoinDate,d.NIDno from doctor d inner join Designation dg on d.DesigNationId = dg.DesigId join gender g on d.GenderId = g.GenderId join Speciality sp on d.SpecialitytId = sp.SpecialitytId", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //txtId.Text = "";
            //txtDoctorName.Text = "";
            //txtDesigNation.Text = "";
            //txtSpecialist.Text = "";
            //txtMobileNo.Text = "";
            //txtAddress.Text = "";
        }

        private void NewDoctor_Load(object sender, EventArgs e)
        {
            LoadGrid();


            // TODO: This line of code loads data into the 'hospitalManagementDbDataSet4.spShowDoctorsInfo' table. You can move, or remove it, as needed.
            this.spShowDoctorsInfoTableAdapter.Fill(this.hospitalManagementDbDataSet4.spShowDoctorsInfo);
            // TODO: This line of code loads data into the 'hospitalManagementDbDataSet3.Designation' table. You can move, or remove it, as needed.
            this.designationTableAdapter.Fill(this.hospitalManagementDbDataSet3.Designation);
            // TODO: This line of code loads data into the 'hospitalManagementDbDataSet2.Speciality' table. You can move, or remove it, as needed.
            this.specialityTableAdapter1.Fill(this.hospitalManagementDbDataSet2.Speciality);
            // TODO: This line of code loads data into the 'hospitalManagementDbDataSet1.Speciality' table. You can move, or remove it, as needed.
            this.specialityTableAdapter.Fill(this.hospitalManagementDbDataSet1.Speciality);
            // TODO: This line of code loads data into the 'hospitalManagementDbDataSet.Gender' table. You can move, or remove it, as needed.
            this.genderTableAdapter.Fill(this.hospitalManagementDbDataSet.Gender);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please Enter Doctor ID!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select d.DoctorId,d.DoctorName,dg.Designation,sp.Speciality,d.MobileNo,d.Address,d.Email,g.Gender,d.JoinDate,d.NIDno from doctor d inner join Designation dg on d.DesigNationId = dg.DesigId join gender g on d.GenderId = g.GenderId join Speciality sp on d.SpecialitytId = sp.SpecialitytId  where d.DoctorId=" + txtSearch.Text + "", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtDoctorName.Text = dr["DoctorName"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    dateTimePicker1.Text = dr["joinDate"].ToString();
                    txtMobileNo.Text = dr["mobileNo"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    cmbDesignation.SelectedIndex = -1;
                    cmbDesignation.SelectedText = dr["Designation"].ToString();
                    
                    cmbSpeciality.SelectedIndex = -1;
                    cmbSpeciality.SelectedText = dr["speciality"].ToString();
                    txtNid.Text = dr["nidNo"].ToString();
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
                    MessageBox.Show("No Doctor found");
                }
                con.Close();
                //LoadGridOnSearch();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnNameSearch_Click(object sender, EventArgs e)
        {
            if (txtNameSearch.Text == "")
            {
                MessageBox.Show("Please Enter Doctor Name!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select d.DoctorId,d.DoctorName,dg.Designation,sp.Speciality,d.MobileNo,d.Address,d.Email,g.Gender,d.JoinDate,d.NIDno from doctor d inner join Designation dg on d.DesigNationId = dg.DesigId join gender g on d.GenderId = g.GenderId join Speciality sp on d.SpecialitytId = sp.SpecialitytId  WHERE d.doctorName LIKE '%" + txtNameSearch.Text + "%'", con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No Doctor found");
                }
                con.Close();
            }
        }
        int Gender;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender =2;
        }
    }   
}
