﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Membership_Mangement_System
{
    public partial class SearchMember : Form
    {
        public SearchMember()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearch.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=CHAMIKARA\\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Select * from NewMember where MID = " + txtSearch.Text + "";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }

            else
            {
                MessageBox.Show("Please Enter A member ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           



        }

        private void SearchMember_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=CHAMIKARA\\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select * from NewMember ";

            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();

            DA.Fill(DS);

           

            

            dataGridView1.DataSource = DS.Tables[0];
            String[] headers = {
                "Member ID",
                "First Name",
                "Last Name",
                "Gender",
                "Date Of Birth",
                "Mobile",
                "Email",
                "Join Date",
                "Gym Time",
                "Member Address",
                "Membership Time"
                };

            for(int i =0; i < headers.Length; i++)
            {
                dataGridView1.Columns[i].HeaderText = headers[i];
            }
        }
    }
}
