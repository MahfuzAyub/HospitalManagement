using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedicalStore
{
    public partial class Tests : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=HospitalManagementDb;Integrated Security=True;MultipleActiveResultSets=True");
        public Tests()
        {
            InitializeComponent();
        }
        private void Tests_Load(object sender, EventArgs e)
        {
            txtDiscountRate.Text = "0";
            txtPaidAmount.Text = "0";
            // TODO: This line of code loads data into the 'hospitalManagementDbDataSet7.tblGroup' table. You can move, or remove it, as needed.
            this.tblGroupTableAdapter.Fill(this.hospitalManagementDbDataSet7.tblGroup);
        }
        private void cmbTestGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select * from tblTest where GroupId ='" + cmbTestGroup.SelectedValue + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = false;
                    dataGridView1.Rows[n].Cells[1].Value = item["testId"].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item["testName"].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item["price"].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item["groupId"].ToString();
                }
            }
            con.Close();
        }
        private void CheckBox_Checked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void checkedListBoxTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public double result = 0;
        public double discountRate = 0;
        public double paidAmount = 0;

        private void btnTests_Click(object sender, EventArgs e)
        {
            result = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item.Cells[4].Value.ToString();
                }
            }
            discountRate = double.Parse(txtDiscountRate.Text);
            paidAmount = double.Parse(txtPaidAmount.Text);
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                result += Convert.ToDouble(row.Cells[2].Value);
            }
            if (discountRate != 0)
            {
                discountRate = discountRate / 100;
            }
            lblTotalBill.Text = result.ToString();
            result = (1 - discountRate) * result;
            txtNetBill.Text = result.ToString();
            result = result - paidAmount;
            txtDue.Text = result.ToString();


            dataGridView1.CancelEdit();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[0].Value = false;
            }

            string existingTests = dataGridView2.Rows[0].Cells[0].Value.ToString();
            for (int i = 1; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value.ToString() == existingTests)
                {
                    int rowIndex = dataGridView2.CurrentCell.RowIndex;
                    foreach (DataGridViewRow row in dataGridView2.SelectedRows)
                    {
                        dataGridView2.Rows.RemoveAt(row.Index);
                    }
                }
                else
                {
                    existingTests = dataGridView2.Rows[i].Cells[0].Value.ToString();
                }
            }
           
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((bool)dataGridView1.SelectedRows[0].Cells[0].Value == false)
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = true;
            }
            else
            {
                dataGridView1.SelectedRows[0].Cells[0].Value = false;
            }
        }
        private void dataGridView1_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void btnDeleteTests_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(row.Index);
            }
            double result = 0;

            txtPaidAmount.Text = "0";
            paidAmount = 0;
            double discountRate = 0;
            discountRate = double.Parse(txtDiscountRate.Text);
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                result += Convert.ToDouble(row.Cells[2].Value);
            }
            if (discountRate != 0)
            {
                discountRate = discountRate / 100;
            }
            lblTotalBill.Text = result.ToString();
            result = (1 - discountRate) * result;
            txtNetBill.Text = result.ToString();
            result = result - paidAmount;
            txtDue.Text = result.ToString();
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {

            result = 0;
            //dataGridView2.Rows.Clear();
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[0].Value == true)
                {
                    int n = dataGridView2.Rows.Add();
                    dataGridView2.Rows[n].Cells[0].Value = item.Cells[1].Value.ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item.Cells[2].Value.ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item.Cells[3].Value.ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item.Cells[4].Value.ToString();
                }
            }
            discountRate = double.Parse(txtDiscountRate.Text);
            paidAmount = double.Parse(txtPaidAmount.Text);
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                result += Convert.ToDouble(row.Cells[2].Value);
            }
            if (discountRate != 0)
            {
                discountRate = discountRate / 100;
            }
            lblTotalBill.Text = result.ToString();
            result = (1 - discountRate) * result;
            txtNetBill.Text = result.ToString();
            result = result - paidAmount;
            txtDue.Text = result.ToString();
        }

        private void txtDiscountRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPaidAmount_MouseClick(object sender, MouseEventArgs e)
        {
            txtPaidAmount.Text = "";
        }
    }
}

