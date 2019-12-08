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
    public partial class Appointment : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HospitalManagementDb;Integrated Security=True;MultipleActiveResultSets=True");
        public Appointment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string str = " insert into Appointment values ('" + cmbDoctorName.SelectedValue + "','" + txtPatientId.Text + "','" + comboBox1.SelectedValue + "','" + dateTimePicker1.Value + "')";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select max(PatientId) from patient ;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {                    
                    MessageBox.Show("Appointment Created Successfully. ");
                    LoadGrid();
                    txtPatientId.Text = "";
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
            
        }
        private void LoadGrid()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select a.appointmetnId,p.PatientName,d.DoctorName,s.Speciality,a.appointmentDate from Appointment a join doctor d on a.doctorid = d.DoctorId join patient p on p.PatientId = a.patientId join Speciality s on s.SpecialitytId = a.SpecialitytId", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            //dataGridView2.Hide();
            //dataGridView1.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from doctor where SpecialitytId = '" + comboBox1.SelectedValue + "'", con);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                cmbDoctorName.SelectedIndex = -1;
                cmbDoctorName.DisplayMember = ds.Tables[0].Columns["doctorName"].ToString();
                cmbDoctorName.ValueMember = ds.Tables[0].Columns["doctorId"].ToString();
                //doctorId = int.Parse( ds.Tables[0].Columns["doctorId"].ToString());
                cmbDoctorName.DataSource = ds.Tables[0];
            }
            con.Close();
        }

        private void NewPatient_Load(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            // TODO: This line of code loads data into the 'hospitalManagementDbDataSet6.spAppointmentInfo' table. You can move, or remove it, as needed.
            this.spAppointmentInfoTableAdapter.Fill(this.hospitalManagementDbDataSet6.spAppointmentInfo);
            // TODO: This line of code loads data into the 'hospitalManagementDbDataSet5.Speciality' table. You can move, or remove it, as needed.
            this.specialityTableAdapter.Fill(this.hospitalManagementDbDataSet5.Speciality);
            comboBox1.SelectedIndex = -1;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (waterMarkTextBox1.Text == "")
            {
                MessageBox.Show("Please Enter Patient Name or Mobile Number to Search !!");
            }
            else
            {
                dataGridView1.Columns.Clear();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select PatientId, PatientName, Mobile, NID from Patient where PatientName LIKE '%" + waterMarkTextBox1.Text + "%'  or Mobile  LIKE '%" + waterMarkTextBox1.Text + "%'", con))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            ///////////////To Show in Grid\\\\\\\\\\\\\\\\\\\\\
                            DataTable dt = new DataTable();
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            sda.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView2.DataSource = dt;
                            }                            
                        }
                        else
                        {
                            MessageBox.Show("No Patient found !!");
                        }
                        con.Close();
                    }
                    LoadGrid2();
                }
            }
        }
        private void LoadGrid2()
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                dataGridView1.Hide();
                dataGridView2.Show();
                using (SqlDataAdapter sda = new SqlDataAdapter("select PatientId,PatientName,Mobile,NID from Patient where  PatientName LIKE '%" + waterMarkTextBox1.Text + "%'  or Mobile = '" + waterMarkTextBox1.Text + "'", con))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    dataGridView2.DataSource = dt;
                }
            }
        }
    }
}
