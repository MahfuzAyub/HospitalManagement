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
    public partial class PatientBill : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HospitalManagementDb;Integrated Security=True");
        public PatientBill()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txtPatientName.Text = "";
                    // Establishing Connection

            
            if (txtPatientId.Text != "")
            {
                try
                {
                    con.Open();
                    string getCust = "select * from patient where PatientId=" + txtPatientId.Text + "";     // saving new custmer info

                    SqlCommand cmd = new SqlCommand(getCust, con);
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtPatientName.Text = dr.GetValue(0).ToString();
                        txtRoomNo.Text = dr.GetValue(1).ToString();
                    }
                    else
                    {
                        MessageBox.Show(" Sorry ,,This ID, " + txtPatientId.Text + " customer is not Available.   ");
                        txtPatientId.Text = "";
                    }
                }
                catch (SqlException excep)
                {
                    MessageBox.Show(excep.Message);
                }
                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string str = " insert into bill values('" + txtPatientId.Text + "','" + txtPatientName.Text + "','" + txtRoomNo.Text + "','" + txtDoctorVisitCharge.Text + "','" + txtDrugs.Text + "','" + txtRoomRent.Text + "','" + txtEquipmentCharges.Text + "','" + txtOthers.Text + "','" + txtBId.Text + "','" + txtTotal.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                string str1 = "select max(PatientId) from bill ;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("bill saved Successfully. ");
                    txtPatientId.Text = "";
                    txtPatientName.Text = "";
                    txtRoomNo.Text = "";
                    txtDoctorVisitCharge.Text = "";
                    txtDrugs.Text = "";
                    txtRoomRent.Text = "";
                    txtEquipmentCharges.Text = "";
                    txtOthers.Text = "";
                    txtBId.Text = "";
                }
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDoctorVisitCharge.Text) && !string.IsNullOrEmpty(txtDrugs.Text) && !string.IsNullOrEmpty(txtRoomRent.Text) && !string.IsNullOrEmpty(txtEquipmentCharges.Text) && !string.IsNullOrEmpty(txtOthers.Text))
                txtTotal.Text = (Convert.ToInt32(txtDoctorVisitCharge.Text) + Convert.ToInt32(txtDrugs.Text) + Convert.ToInt32(txtRoomRent.Text) + Convert.ToInt32(txtEquipmentCharges.Text) + Convert.ToInt32(txtOthers.Text)).ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDoctorVisitCharge.Text) && !string.IsNullOrEmpty(txtDrugs.Text) && !string.IsNullOrEmpty(txtRoomRent.Text) && !string.IsNullOrEmpty(txtEquipmentCharges.Text) && !string.IsNullOrEmpty(txtOthers.Text))
                txtTotal.Text = (Convert.ToInt32(txtDoctorVisitCharge.Text) + Convert.ToInt32(txtDrugs.Text) + Convert.ToInt32(txtRoomRent.Text) + Convert.ToInt32(txtEquipmentCharges.Text) + Convert.ToInt32(txtOthers.Text)).ToString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDoctorVisitCharge.Text) && !string.IsNullOrEmpty(txtDrugs.Text) && !string.IsNullOrEmpty(txtRoomRent.Text) && !string.IsNullOrEmpty(txtEquipmentCharges.Text) && !string.IsNullOrEmpty(txtOthers.Text))
                txtTotal.Text = (Convert.ToInt32(txtDoctorVisitCharge.Text) + Convert.ToInt32(txtDrugs.Text) + Convert.ToInt32(txtRoomRent.Text) + Convert.ToInt32(txtEquipmentCharges.Text) + Convert.ToInt32(txtOthers.Text)).ToString();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDoctorVisitCharge.Text) && !string.IsNullOrEmpty(txtDrugs.Text) && !string.IsNullOrEmpty(txtRoomRent.Text) && !string.IsNullOrEmpty(txtEquipmentCharges.Text) && !string.IsNullOrEmpty(txtOthers.Text))
                txtTotal.Text = (Convert.ToInt32(txtDoctorVisitCharge.Text) + Convert.ToInt32(txtDrugs.Text) + Convert.ToInt32(txtRoomRent.Text) + Convert.ToInt32(txtEquipmentCharges.Text) + Convert.ToInt32(txtOthers.Text)).ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDoctorVisitCharge.Text) && !string.IsNullOrEmpty(txtDrugs.Text) && !string.IsNullOrEmpty(txtRoomRent.Text) && !string.IsNullOrEmpty(txtEquipmentCharges.Text) && !string.IsNullOrEmpty(txtOthers.Text))
                txtTotal.Text = (Convert.ToInt32(txtDoctorVisitCharge.Text) + Convert.ToInt32(txtDrugs.Text) + Convert.ToInt32(txtRoomRent.Text) + Convert.ToInt32(txtEquipmentCharges.Text) + Convert.ToInt32(txtOthers.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPatientId.Text = "";
            txtPatientName.Text = "";
            txtRoomNo.Text = "";
            txtDoctorVisitCharge.Text = "";
            txtDrugs.Text = "";
            txtRoomRent.Text = "";
            txtEquipmentCharges.Text = "";
            txtOthers.Text = "";
            txtBId.Text = "";
        }

        
    }
}
