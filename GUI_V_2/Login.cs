using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI_V_2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            OracleConnection ora = new OracleConnection("DATA SOURCE = xe;PASSWORD =1234;USER ID = nicolas;");
            ora.Open();
            OracleCommand query = new OracleCommand("Select * from usuario where id_usuario = :id and contraseña = :pass");
            query.Parameters.AddWithValue(":id", txtUsername.Text);
            query.Parameters.AddWithValue(":pass", txtPassword);

            OracleDataReader rd = query.ExecuteReader();

            if (rd.Read())
            {
               
            }
            MessageBox.Show("Tay conectao lacra");
            ora.Close();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
