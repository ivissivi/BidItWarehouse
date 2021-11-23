﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BidItWarehouse
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Warehouse.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM Users WHERE Access_code = '" + txtAccessCode.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {

                new Warehouse().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid access code, please try again", "Login unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccessCode.Text = "";
                txtAccessCode.Focus();
            }
            con.Close();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void pbxExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
