using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalStore
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void newPatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
             New_Patients obj1 = new New_Patients();
            obj1.ShowDialog();
        }

        private void newDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewDoctor obj2 = new NewDoctor();
            obj2.ShowDialog();
        }

        private void patientBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PatientBill obj3 = new PatientBill();
            obj3.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Appointment obj4 = new Appointment();
            obj4.ShowDialog();
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
