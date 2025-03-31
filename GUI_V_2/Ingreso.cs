using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GUI_V_2
{
    public partial class Ingreso : Form
    {
        public Ingreso()
        {
            InitializeComponent();
        }

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string stsql = "PC_LOGIN";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            ora.Open();
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("correo", txtUsername.Text);
            query.Parameters.Add("contra", txtPassword.Text);
            query.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;

            query.ExecuteNonQuery();
            
            string val = Convert.ToString(query.Parameters["validar"].Value);
            int rol = Convert.ToInt32(val);
            if (rol == 1)
            {
                //Administrador

                Form1 FRM1 = new Form1();
                Usuarios user = new Usuarios();
                sub sb = new sub();
                
                FRM1.Show();

                FRM1.lblusuario.Text = "Administrador";

                string consulta = "Select rut from persona where email = :mail and contraseña = :pass";
                OracleCommand cmdId = new OracleCommand(consulta, ora);
                cmdId.CommandType = CommandType.Text;
                cmdId.Parameters.Add(":mail", txtUsername.Text);
                cmdId.Parameters.Add(":pass", txtPassword.Text);

                OracleDataReader lector = cmdId.ExecuteReader();

                if (lector.Read())
                {
                    user.lblIDAdmin.Text = lector["rut"].ToString();
                    sb.idPersona = lector["rut"].ToString();
                    FRM1.idPEr = lector["rut"].ToString();
                }
                else
                {
                    user.lblIDAdmin.Text = "";
                    sb.idPersona = "";
                }


            }
            else if (rol == 2)
            {
                //Cliente interno
                Form1 FRM1 = new Form1();
                FRM1.Show();

                FRM1.btnSub.Enabled = false;
               
                FRM1.btnprod.Enabled = false;
                FRM1.btnDesp.Enabled = false;
                FRM1.btnGesti.Enabled = false;
                FRM1.btnOfer.Enabled = false;
                FRM1.btnDeta.Enabled = false;
                FRM1.btnGest.Enabled = false;

                FRM1.lblusuario.Text = "Cliente Interno";
            }
            else if (rol == 3)
            {
                //Cliente externo
                Form1 FRM1 = new Form1();
                FRM1.Show();
                FRM1.btnSub.Enabled = false;
                FRM1.btnVent.Enabled = false;
                FRM1.btnprod.Enabled = false;
                FRM1.btnDesp.Enabled = false;
                FRM1.btnGesti.Enabled = false;
                FRM1.btnOfer.Enabled = false;
                FRM1.btnDeta.Enabled = false;
                FRM1.btnGest.Enabled = false;
            }
            else if (rol == 4)
            {
                //Consultor
                Form1 FRM1 = new Form1();
                FRM1.Show();


                FRM1.lblusuario.Text = "Consultor";
            }
            else
            {
                string stsqlProv = "PC_LOGIN_PROVEEDOR";
                OracleCommand query2 = new OracleCommand(stsqlProv, ora);
                query2.CommandType = CommandType.StoredProcedure;
                query2.Parameters.Add("correo", txtUsername.Text);
                query2.Parameters.Add("contra", txtPassword.Text);
                query2.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;

                query2.ExecuteNonQuery();

                string valProv = Convert.ToString(query2.Parameters["validar"].Value);
                int rolProv = Convert.ToInt32(valProv);

                if (rolProv == 5)
                {
                    //Proveedor
                    Form1 FRM1 = new Form1();
                    FRM1.Show();
                    FRM1.btnSub.Enabled = false;
                    FRM1.btnVent.Enabled = true;
                    FRM1.btnprod.Enabled = true;
                    FRM1.btnDesp.Enabled = false;
                    FRM1.btnGesti.Enabled = true;
                   
                    FRM1.btnDeta.Enabled = false;
                    FRM1.btnGest.Enabled = false;
                    
                }
                else
                {
                    string stSqlTrans = "PC_LOGIN_TRANSPORTISTA";
                    OracleCommand query3 = new OracleCommand(stSqlTrans, ora);
                    query3.CommandType = CommandType.StoredProcedure;
                    query3.Parameters.Add("correo", txtUsername.Text);
                    query3.Parameters.Add("contra", txtPassword.Text);
                    query3.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    query3.ExecuteNonQuery();

                    string valTrans = Convert.ToString(query3.Parameters["validar"].Value);
                    int rolTrans = Convert.ToInt32(valTrans);
                    if (rolTrans == 6)
                    {
                        //Transportista

                        Form1 FRM1 = new Form1();
                        FRM1.Show();
                        FRM1.btnSub.Enabled = false;
                        FRM1.btnVent.Enabled = true;
                        FRM1.btnprod.Enabled = true;
                        FRM1.btnDesp.Enabled = false;
                        FRM1.btnGesti.Enabled = false;
                        FRM1.btnOfer.Enabled = false;
                        FRM1.btnDeta.Enabled = false;
                        FRM1.btnGest.Enabled = false;

                    }
                    else
                    {
                        string stSqlEx = "PC_LOGIN_EXTRANJERO";
                        OracleCommand query4 = new OracleCommand(stSqlEx, ora);
                        query4.CommandType = CommandType.StoredProcedure;
                        query4.Parameters.Add("correo", txtUsername.Text);
                        query4.Parameters.Add("contra", txtPassword.Text);
                        query4.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;

                        query4.ExecuteNonQuery();

                        string valCliEx = Convert.ToString(query4.Parameters["validar"].Value);
                        int rolCliEx = Convert.ToInt32(valCliEx);
                        if (rolCliEx == 7)
                        {
                            //Cliente extranjero
                            Form1 FRM1 = new Form1();
                            FRM1.Show();
                            FRM1.btnSub.Enabled = false;
                            FRM1.btnVent.Enabled = false;
                            FRM1.btnprod.Enabled = false;
                            FRM1.btnDesp.Enabled = false;
                        
                            FRM1.btnOfer.Enabled = false;
                            FRM1.btnDeta.Enabled = false;
                            FRM1.btnGest.Enabled = true;

                        }
                        else
                        {
                            //Muestre mensaje de usuario no existente
                            MessageBox.Show("El usuario ingresado no existe");
                        }
                    }
                }
            }

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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string stsql = "PC_LOGIN";
                OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
                OracleCommand query = new OracleCommand(stsql, ora);
                ora.Open();
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add("correo", txtUsername.Text);
                query.Parameters.Add("contra", txtPassword.Text);
                query.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;

                query.ExecuteNonQuery();

                string val = Convert.ToString(query.Parameters["validar"].Value);
                int rol = Convert.ToInt32(val);
                if (rol == 1)
                {
                    //Administrador

                    Form1 FRM1 = new Form1();
                    Usuarios user = new Usuarios();
                    sub sb = new sub();
                    FRM1.Show();

                    FRM1.lblusuario.Text = "Administrador";

                    string consulta = "Select rut from persona where email = :mail and contraseña = :pass";
                    OracleCommand cmdId = new OracleCommand(consulta, ora);
                    cmdId.CommandType = CommandType.Text;
                    cmdId.Parameters.Add(":mail", txtUsername.Text);
                    cmdId.Parameters.Add(":pass", txtPassword.Text);

                    OracleDataReader lector = cmdId.ExecuteReader();

                    if (lector.Read())
                    {
                        user.lblIDAdmin.Text = lector["rut"].ToString();
                        sb.lblRutAdmin.Text = lector["rut"].ToString();
                    }
                    else
                    {
                        user.lblIDAdmin.Text = "";
                        sb.lblRutAdmin.Text = "";
                    }
                }
                else if (rol == 2)
                {
                    //Cliente interno
                    Form1 FRM1 = new Form1();
                    FRM1.Show();

                    FRM1.btnSub.Enabled = false;

                    FRM1.btnprod.Enabled = false;
                    FRM1.btnDesp.Enabled = false;
                    FRM1.btnGesti.Enabled = false;
                    FRM1.btnOfer.Enabled = false;
                    FRM1.btnDeta.Enabled = false;
                    FRM1.btnGest.Enabled = false;

                    FRM1.lblusuario.Text = "Cliente Interno";
                }
                else if (rol == 3)
                {
                    //Cliente externo
                    Form1 FRM1 = new Form1();
                    FRM1.Show();
                    FRM1.btnSub.Enabled = false;
                    FRM1.btnVent.Enabled = false;
                    FRM1.btnprod.Enabled = false;
                    FRM1.btnDesp.Enabled = false;
                    FRM1.btnGesti.Enabled = false;
                    FRM1.btnOfer.Enabled = false;
                    FRM1.btnDeta.Enabled = false;
                    FRM1.btnGest.Enabled = false;
                }
                else if (rol == 4)
                {
                    //Consultor
                    Form1 FRM1 = new Form1();
                    FRM1.Show();


                    FRM1.lblusuario.Text = "Consultor";
                }
                else
                {
                    string stsqlProv = "PC_LOGIN_PROVEEDOR";
                    OracleCommand query2 = new OracleCommand(stsqlProv, ora);
                    query2.CommandType = CommandType.StoredProcedure;
                    query2.Parameters.Add("correo", txtUsername.Text);
                    query2.Parameters.Add("contra", txtPassword.Text);
                    query2.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    query2.ExecuteNonQuery();

                    string valProv = Convert.ToString(query2.Parameters["validar"].Value);
                    int rolProv = Convert.ToInt32(valProv);

                    if (rolProv == 5)
                    {
                        //Proveedor
                        Form1 FRM1 = new Form1();
                        FRM1.Show();
                        FRM1.btnSub.Enabled = false;
                        FRM1.btnVent.Enabled = true;
                        FRM1.btnprod.Enabled = true;
                        FRM1.btnDesp.Enabled = false;
                        FRM1.btnGesti.Enabled = true;

                        FRM1.btnDeta.Enabled = false;
                        FRM1.btnGest.Enabled = false;


                        FRM1.lblusuario.Text = "Proveedor";
                    }
                    else
                    {
                        string stSqlTrans = "PC_LOGIN_TRANSPORTISTA";
                        OracleCommand query3 = new OracleCommand(stSqlTrans, ora);
                        query3.CommandType = CommandType.StoredProcedure;
                        query3.Parameters.Add("correo", txtUsername.Text);
                        query3.Parameters.Add("contra", txtPassword.Text);
                        query3.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;

                        query3.ExecuteNonQuery();

                        string valTrans = Convert.ToString(query3.Parameters["validar"].Value);
                        int rolTrans = Convert.ToInt32(valTrans);
                        if (rolTrans == 6)
                        {
                            //Transportista

                            Form1 FRM1 = new Form1();
                            FRM1.Show();
                            FRM1.btnSub.Enabled = false;
                            FRM1.btnVent.Enabled = true;
                            FRM1.btnprod.Enabled = true;
                            FRM1.btnDesp.Enabled = false;
                            FRM1.btnGesti.Enabled = false;
                            FRM1.btnOfer.Enabled = false;
                            FRM1.btnDeta.Enabled = false;
                            FRM1.btnGest.Enabled = false;

                        }
                        else
                        {
                            string stSqlEx = "PC_LOGIN_EXTRANJERO";
                            OracleCommand query4 = new OracleCommand(stSqlEx, ora);
                            query4.CommandType = CommandType.StoredProcedure;
                            query4.Parameters.Add("correo", txtUsername.Text);
                            query4.Parameters.Add("contra", txtPassword.Text);
                            query4.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;

                            query4.ExecuteNonQuery();

                            string valCliEx = Convert.ToString(query4.Parameters["validar"].Value);
                            int rolCliEx = Convert.ToInt32(valCliEx);
                            if (rolCliEx == 7)
                            {
                                //Cliente extranjero
                                Form1 FRM1 = new Form1();
                                FRM1.Show();
                                FRM1.btnSub.Enabled = false;
                                FRM1.btnVent.Enabled = false;
                                FRM1.btnprod.Enabled = false;
                                FRM1.btnDesp.Enabled = false;

                                FRM1.btnOfer.Enabled = false;
                                FRM1.btnDeta.Enabled = false;
                                FRM1.btnGest.Enabled = true;

                            }
                            else
                            {
                                //Muestre mensaje de usuario no existente
                                MessageBox.Show("El usuario ingresado no existe");
                            }
                        }
                    }
                }

                ora.Close();
            }

        }

        private void Ingreso_Load(object sender, EventArgs e)
        {
            
        }
    }
}
