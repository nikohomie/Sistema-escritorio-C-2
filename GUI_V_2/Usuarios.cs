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
    public partial class Usuarios : Form
    {
        string respuesta;
        string tipoUser;
        int id_fila;

        public Usuarios()
        {
            InitializeComponent();
        }

        public DataTable listacomuna()
        {
            string stsql = "pc_lista_comunas";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();
            return dt;
        }

        private void listaClientesExtranjeros()
        {
            string stsql = "pc_lista_extranjero";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgUsuarios.DataSource = dt;
        }

        private void listaTransportistas()
        {
            string stsql = "pc_lista_transportista";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgUsuarios.DataSource = dt;
        }

        private void listaProductor()
        {
            string stsql = "pc_lista_proveedor";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgUsuarios.DataSource = dt;
        }

        private void listaConsultor()
        {
            string stsql = "pc_lista_consultor";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgUsuarios.DataSource = dt;
        }

        private void listaClienteExterno()
        {
            string stsql = "pc_lista_cli_ex";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgUsuarios.DataSource = dt;
        }

        private void listaClienteInterno()
        {
            string stsql = "pc_lista_cli_in";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgUsuarios.DataSource = dt;
        }

        private void listaAdministradores()
        {
            string stsql = "pc_lista_admins";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgUsuarios.DataSource = dt;
        }

        public DataTable listaRoles()
        {
            string stsql = "pc_lista_roles";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();
            return dt;
        }

        public DataTable listaTipoTransporte()
        {
            string stsql = "pc_lista_tipo_transporte";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();
            return dt;
        }



        private void Usuarios_Load(object sender, EventArgs e)
        {
            lblTransporte.Enabled = false;
            lblTransporte.Visible = false;
            lblCapacidad.Enabled = false;
            lblCapacidad.Visible = false;
            lblFrigorico.Enabled = false;
            lblFrigorico.Visible = false;
            lblPatente.Enabled = false;
            lblPatente.Visible = false;
            lblAño.Enabled = false;
            lblAño.Visible = false;

            cmbTransporte.Enabled = false;
            cmbTransporte.Visible = false;
            txtCapacidad.Enabled = false;
            txtCapacidad.Visible = false;
            txtFrigorifico.Enabled = false;
            txtFrigorifico.Visible = false;
            txtPatente.Enabled = false;
            txtPatente.Visible = false;
            txtAño.Enabled = false;
            txtAño.Visible = false;

            cmbPais.Visible = false;
            lblpais.Visible = false;

            cmbTransporte.DataSource = listaTipoTransporte();
            cmbTransporte.DisplayMember = "VEHICULO";
            cmbTransporte.ValueMember = "ID_TIPO";
        }

        int conteo;
        public int validacionUser()
        {
            string stsql = "pc_busqueda_usuarios";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("rol", Convert.ToInt32(cmbRol.SelectedValue));
            query.Parameters.Add("runn", txtRut.Text);
            query.Parameters.Add("val", OracleDbType.Int32).Direction = ParameterDirection.Output;
            ora.Open();

            query.ExecuteNonQuery();
            conteo = Convert.ToInt32("" + query.Parameters["val"].Value);

            if (conteo == 1)
            {
                return conteo;
            }
            else
            {
                conteo = 0;
                return conteo;
            }
        }

        public string insertUsuarios(int rol, string rut, string nom, string email, string direc, int fono, int idComu, int edad, string pass, int idPais)
        {
            string stsql = "pc_insert_usuarios";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("tipo_per", rol);
            query.Parameters.Add("id_per", rut);
            query.Parameters.Add("nom", nom);
            query.Parameters.Add("mail", email);
            query.Parameters.Add("direc", direc);
            query.Parameters.Add("fono", fono);
            query.Parameters.Add("comu", idComu);
            query.Parameters.Add("eda", edad);
            query.Parameters.Add("contra", pass);
            query.Parameters.Add("pais", idPais);
            ora.Open();

            int val = query.ExecuteNonQuery();
            ora.Close();
            if (val != 0)
            {
                this.respuesta = "ok";
                return respuesta;
            }
            else
            {
                this.respuesta = "error";
                return respuesta;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int validacion = validacionUser();

            if (validacion == 1)
            {
                MessageBox.Show("El usuario que se está intentando registrar ya existe");
            }
            else
            {
                if (cmbRol.Text == "Seleccione")
                {
                    MessageBox.Show("Debe seleccionar un rol de usuario para proceder con el registro");

                }
                else if (Convert.ToInt32(cmbRol.SelectedValue) > 0 && Convert.ToInt32(cmbRol.SelectedValue) < 5)
                {
                    if (txtRut.Text == "" || txtNombre.Text == "" || txtEmail.Text == "" || txtDirec.Text == "" || txtFono.Text.Length < 1 || txtEdad.Text.Length < 1 || txtContraseña.Text == "" || cmbRol.Text == "Seleccione" || cmbComunas.Text == "Seleccione una comuna")
                    {
                        MessageBox.Show("Todos los campos son obligatorios, debe rellenarlos para continuar");
                    }
                    else
                    {
                        string val = insertUsuarios(Convert.ToInt32(cmbRol.SelectedValue), txtRut.Text, txtNombre.Text, txtEmail.Text, txtDirec.Text, Convert.ToInt32(txtFono.Text), Convert.ToInt32(cmbComunas.SelectedValue), Convert.ToInt32(txtEdad.Text), txtContraseña.Text, Convert.ToInt32(cmbPais.SelectedValue));
                        if (val == "ok")
                        {
                            MessageBox.Show("Registro exitoso");
                            txtRut.Text = "";
                            txtEdad.Text = "";
                            txtFono.Text = "";
                            txtDirec.Text = "";
                            txtContraseña.Text = "";
                            txtEmail.Text = "";
                            txtAño.Text = "";
                            txtNombre.Text = "";
                            cmbRol.ResetText();
                            cmbComunas.ResetText();
                            cmbPais.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al intentar registrar al usuario");
                        }
                    }
                }
                else if (Convert.ToInt32(cmbRol.SelectedValue) == 5)
                {
                    if (txtRut.Text == "" || txtNombre.Text == "" || txtEmail.Text == "" || txtDirec.Text == "" || txtFono.Text.Length < 1 || txtContraseña.Text == "" || cmbRol.Text == "Seleccione")
                    {
                        MessageBox.Show("Todos los campos son obligatorios, debe rellenarlos para continuar");
                    }
                    else
                    {
                        string val = insertUsuarios(Convert.ToInt32(cmbRol.SelectedValue), txtRut.Text, txtNombre.Text, txtEmail.Text, txtDirec.Text, Convert.ToInt32(txtFono.Text), Convert.ToInt32(cmbComunas.SelectedValue), Convert.ToInt32(txtEdad.Text), txtContraseña.Text, Convert.ToInt32(cmbPais.SelectedValue));
                        if (val == "ok")
                        {
                            MessageBox.Show("Registro exitoso");
                            txtRut.Text = "";
                            txtEdad.Text = "";
                            txtFono.Text = "";
                            txtDirec.Text = "";
                            txtContraseña.Text = "";
                            txtEmail.Text = "";
                            txtAño.Text = "";
                            txtNombre.Text = "";
                            cmbRol.ResetText();
                            cmbComunas.ResetText();
                            cmbPais.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al intentar registrar al usuario");
                        }
                    }
                }
                else if (Convert.ToInt32(cmbRol.SelectedValue) == 6)
                {
                    if (txtRut.Text == "" || txtNombre.Text == "" || txtEmail.Text == "" || txtDirec.Text == "" || txtFono.Text.Length < 1 || txtContraseña.Text == "" || cmbRol.Text == "Seleccione")
                    {
                        MessageBox.Show("Todos los campos son obligatorios, debe rellenarlos para continuar");
                    }
                    else
                    {
                        string val = insertUsuarios(Convert.ToInt32(cmbRol.SelectedValue), txtRut.Text, txtNombre.Text, txtEmail.Text, txtDirec.Text, Convert.ToInt32(txtFono.Text), Convert.ToInt32(cmbComunas.SelectedValue), Convert.ToInt32(txtEdad.Text), txtContraseña.Text, Convert.ToInt32(cmbPais.SelectedValue));
                        if (val == "ok")
                        {
                            MessageBox.Show("Registro exitoso");
                            txtRut.Text = "";
                            txtEdad.Text = "";
                            txtFono.Text = "";
                            txtDirec.Text = "";
                            txtContraseña.Text = "";
                            txtEmail.Text = "";
                            txtAño.Text = "";
                            txtNombre.Text = "";
                            cmbRol.ResetText();
                            cmbComunas.ResetText();
                            cmbPais.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al intentar registrar al usuario");
                        }
                    }
                }
                else if (Convert.ToInt32(cmbRol.SelectedValue) == 7)
                {
                    if (txtRut.Text == "" || txtNombre.Text == "" || txtEmail.Text == "" || txtDirec.Text == "" || txtFono.Text.Length < 1 || txtContraseña.Text == "" || cmbRol.Text == "Seleccione" || cmbPais.Text == "Seleccione País")
                    {
                        MessageBox.Show("Todos los campos son obligatorios, debe rellenarlos para continuar");
                    }
                    else
                    {
                        string val = insertUsuarios(Convert.ToInt32(cmbRol.SelectedValue), txtRut.Text, txtNombre.Text, txtEmail.Text, txtDirec.Text, Convert.ToInt32(txtFono.Text), Convert.ToInt32(cmbComunas.SelectedValue), Convert.ToInt32(txtEdad.Text), txtContraseña.Text, Convert.ToInt32(cmbPais.SelectedValue));
                        if (val == "ok")
                        {
                            MessageBox.Show("Registro exitoso");
                            txtRut.Text = "";
                            txtEdad.Text = "";
                            txtFono.Text = "";
                            txtDirec.Text = "";
                            txtContraseña.Text = "";
                            txtEmail.Text = "";
                            txtAño.Text = "";
                            txtNombre.Text = "";
                            cmbRol.ResetText();
                            cmbComunas.ResetText();
                            cmbPais.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrio un error al intentar registrar al usuario");
                        }
                    }
                }
            }
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRol_TextChanged(object sender, EventArgs e)
        {
            lblRolSeleccionado.Text = cmbRol.Text;
            if (lblRolSeleccionado.Text == "Transportista")
            {
                lblTransporte.Enabled = true;
                lblTransporte.Visible = true;
                lblCapacidad.Enabled = true;
                lblCapacidad.Visible = true;
                lblFrigorico.Enabled = true;
                lblFrigorico.Visible = true;
                lblPatente.Enabled = true;
                lblPatente.Visible = true;
                lblAño.Enabled = true;
                lblAño.Visible = true;

                cmbTransporte.Enabled = true;
                cmbTransporte.Visible = true;
                txtCapacidad.Enabled = true;
                txtCapacidad.Visible = true;
                txtFrigorifico.Enabled = true;
                txtFrigorifico.Visible = true;
                txtPatente.Enabled = true;
                txtPatente.Visible = true;
                txtAño.Enabled = true;
                txtAño.Visible = true;
                cmbPais.Visible = false;
                lblpais.Visible = false;

            }
            else if (lblRolSeleccionado.Text == "Cliente extranjero")
            {
                lblTransporte.Enabled = false;
                lblTransporte.Visible = false;
                lblCapacidad.Enabled = false;
                lblCapacidad.Visible = false;
                lblFrigorico.Enabled = false;
                lblFrigorico.Visible = false;
                lblPatente.Enabled = false;
                lblPatente.Visible = false;
                lblAño.Enabled = false;
                lblAño.Visible = false;

                cmbTransporte.Enabled = false;
                cmbTransporte.Visible = false;
                txtCapacidad.Enabled = false;
                txtCapacidad.Visible = false;
                txtFrigorifico.Enabled = false;
                txtFrigorifico.Visible = false;
                txtPatente.Enabled = false;
                txtPatente.Visible = false;
                txtAño.Enabled = false;
                txtAño.Visible = false;

                cmbPais.Visible = true;
                lblpais.Visible = true;
            }
            else
            {
                lblTransporte.Enabled = false;
                lblTransporte.Visible = false;
                lblCapacidad.Enabled = false;
                lblCapacidad.Visible = false;
                lblFrigorico.Enabled = false;
                lblFrigorico.Visible = false;
                lblPatente.Enabled = false;
                lblPatente.Visible = false;
                lblAño.Enabled = false;
                lblAño.Visible = false;

                cmbTransporte.Enabled = false;
                cmbTransporte.Visible = false;
                txtCapacidad.Enabled = false;
                txtCapacidad.Visible = false;
                txtFrigorifico.Enabled = false;
                txtFrigorifico.Visible = false;
                txtPatente.Enabled = false;
                txtPatente.Visible = false;
                txtAño.Enabled = false;
                txtAño.Visible = false;

                cmbPais.Visible = false;
                lblpais.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length > 0 || txtRut.Text.Length > 0)
            {
                string stsql = "pc_desactivar_persona";
                OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
                OracleCommand queryPer = new OracleCommand(stsql, ora);
                ora.Open();
                queryPer.CommandType = CommandType.StoredProcedure;
                queryPer.Parameters.Add("idUser", txtId.Text);

                queryPer.ExecuteNonQuery();


                string stsqlc = "pc_desactivar_cliente_ex";
                OracleCommand queryCli = new OracleCommand(stsqlc, ora);
                queryCli.CommandType = CommandType.StoredProcedure;
                queryCli.Parameters.Add("idUser", txtId.Text);

                queryCli.ExecuteNonQuery();


                string stsqlx = "pc_desactivar_proveedor";
                OracleCommand queryEx = new OracleCommand(stsqlx, ora);
                queryEx.CommandType = CommandType.StoredProcedure;
                queryEx.Parameters.Add("idUser", txtId.Text);

                queryEx.ExecuteNonQuery();




                string stsqlt = "pc_desactivar_transportista";
                OracleCommand queryTran = new OracleCommand(stsqlt, ora);
                queryTran.CommandType = CommandType.StoredProcedure;
                queryTran.Parameters.Add("idUser", txtId.Text);

                queryTran.ExecuteNonQuery();

                ora.Close();

                lblvalidacion.Text = "Usuario Eliminado Correctamente";
            }else
            {
                lblvalidacion.Text = "Debe especificar un rut para usar esta opción";
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtCapacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTipoUser_TextChanged(object sender, EventArgs e)
        {
            lblTipoUsuario.Text = cmbTipoUser.Text;
            if (lblTipoUsuario.Text == "Administrador")
            {
                listaAdministradores();
            }else if (lblTipoUsuario.Text == "Cliente interno")
            {
                listaClienteInterno();
            }
            else if (lblTipoUsuario.Text == "Cliente externo")
            {
                listaClienteExterno();
            }
            else if (lblTipoUsuario.Text == "Consultor")
            {

                listaConsultor();
            }
            else if (lblTipoUsuario.Text == "Productor")
            {
                txtEdad.Visible = false;
                lblEdad.Visible = false;
                listaProductor();
            }
            else if (lblTipoUsuario.Text == "Transportista")
            {
                txtEdad.Visible = false;
                lblEdad.Visible = false;
                listaTransportistas();
            }
            else if (lblTipoUsuario.Text == "Cliente extranjero")
            {
                txtEdad.Visible = false;
                lblEdad.Visible = false;
                txtDirec.Visible = false;
                lblDirec.Visible = false;
                listaClientesExtranjeros();
            }
        }

        private void dtgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_fila = e.RowIndex;

            string rut;
            string nombre;
            string email;
            string direccion;
            string fono;
            string comuna;
            string edad;
            string contraseña;
            string rol;
            string transporte;
            string patente;
            string capacidad;
            string año;
            string frigorifico;
            string estado;

            if (cmbTipoUser.Text == "Seleccione  un tipo de usuario")
            {
                if (dtgUsuarios.Columns.Contains("RUT"))
                {
                    txtEdad.Visible = true;
                    lblEdad.Visible = true;
                    rut = dtgUsuarios.Rows[id_fila].Cells["RUT"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["NOMBRE"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["EMAIL"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["FONO"].Value.ToString();
                    txtFono.Text = fono;

                    comuna = dtgUsuarios.Rows[id_fila].Cells["COMUNA"].Value.ToString();
                    cmbComunas.Text = comuna;

                    edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    txtEdad.Text = edad;

                    contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA"].Value.ToString();
                    txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;

                }
                else if (dtgUsuarios.Columns.Contains("RUT_PROVEEDOR"))
                {
                    txtEdad.Visible = false;
                    lblEdad.Visible = false;
                    rut = dtgUsuarios.Rows[id_fila].Cells["RUT_PROVEEDOR"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["RAZON_SOCIAL"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["CORREO"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["TELEFONO"].Value.ToString();
                    txtFono.Text = fono;

                    //comuna = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_PROVEEEDOR"].Value.ToString();
                    //cmbComunas.Text = comuna;

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["ROL"].Value.ToString();

                    //edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    //txtEdad.Text = edad;

                    contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_PROVEEEDOR"].Value.ToString();
                    txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
                else if (dtgUsuarios.Columns.Contains("ID_TRANSPORTISTA"))
                {
                    txtEdad.Visible = false;
                    lblEdad.Visible = false;
                    rut = dtgUsuarios.Rows[id_fila].Cells["ID_TRANSPORTISTA"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["RAZON_SOCIAL"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["CORREO"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["TELEFONO"].Value.ToString();
                    txtFono.Text = fono;

                    /*comuna = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_TRANSPORTISTA"].Value.ToString();
                    cmbComunas.Text = comuna;*/

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["ROL"].Value.ToString();

                    //edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    //txtEdad.Text = edad;

                    contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_TRANSPORTISTA"].Value.ToString();
                    txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
                else if (dtgUsuarios.Columns.Contains("DNI"))
                {
                    txtEdad.Visible = false;
                    lblEdad.Visible = false;
                    txtDirec.Visible = false;
                    lblDirec.Visible = false;
                    rut = dtgUsuarios.Rows[id_fila].Cells["DNI"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["NOMBRE"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["COD_PAIS"].Value.ToString();
                    txtEmail.Text = email;

                    //direccion = dtgUsuarios.Rows[id_fila].Cells["TELEFONO"].Value.ToString();
                    //txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["TELEFONO"].Value.ToString();
                    txtFono.Text = fono;

                    comuna = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_CLIENTE"].Value.ToString();
                    cmbComunas.Text = comuna;

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["ROL"].Value.ToString();

                    //edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    //txtEdad.Text = edad;

                    //contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA"].Value.ToString();
                    //txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
            }
            else
            {
                tipoUser = cmbTipoUser.SelectedItem.ToString();

                if (tipoUser == "Administrador")
                {
                    txtEdad.Visible = true;
                    lblEdad.Visible = true;
                    rut = dtgUsuarios.Rows[id_fila].Cells["RUT"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["NOMBRE"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["EMAIL"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["FONO"].Value.ToString();
                    txtFono.Text = fono;

                    comuna = dtgUsuarios.Rows[id_fila].Cells["COMUNA"].Value.ToString();
                    cmbComunas.Text = comuna;

                    edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    txtEdad.Text = edad;

                    contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA"].Value.ToString();
                    txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
                else if (tipoUser == "Cliente interno")
                {
                    txtEdad.Visible = true;
                    lblEdad.Visible = true;
                    rut = dtgUsuarios.Rows[id_fila].Cells["RUT"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["NOMBRE"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["EMAIL"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["FONO"].Value.ToString();
                    txtFono.Text = fono;

                    comuna = dtgUsuarios.Rows[id_fila].Cells["COMUNA"].Value.ToString();
                    cmbComunas.Text = comuna;

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["id_comuna"].Value.ToString();

                    edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    txtEdad.Text = edad;

                    contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA"].Value.ToString();
                    txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
                else if (tipoUser == "Cliente externo")
                {
                    txtEdad.Visible = true;
                    lblEdad.Visible = true;
                    rut = dtgUsuarios.Rows[id_fila].Cells["RUT"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["NOMBRE"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["EMAIL"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["FONO"].Value.ToString();
                    txtFono.Text = fono;

                    comuna = dtgUsuarios.Rows[id_fila].Cells["COMUNA"].Value.ToString();
                    cmbComunas.Text = comuna;

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["id_comuna"].Value.ToString();

                    edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    txtEdad.Text = edad;

                    contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA"].Value.ToString();
                    txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
                else if (tipoUser == "Consultor")
                {
                    txtEdad.Visible = true;
                    lblEdad.Visible = true;
                    rut = dtgUsuarios.Rows[id_fila].Cells["RUT"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["NOMBRE"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["EMAIL"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["FONO"].Value.ToString();
                    txtFono.Text = fono;

                    comuna = dtgUsuarios.Rows[id_fila].Cells["COMUNA"].Value.ToString();
                    cmbComunas.Text = comuna;

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["id_comuna"].Value.ToString();

                    edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    txtEdad.Text = edad;

                    contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA"].Value.ToString();
                    txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
                else if (tipoUser == "Productor")
                {
                    txtEdad.Visible = false;
                    lblEdad.Visible = false;
                    rut = dtgUsuarios.Rows[id_fila].Cells["RUT_PROVEEDOR"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["RAZON_SOCIAL"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["CORREO"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["TELEFONO"].Value.ToString();
                    txtFono.Text = fono;

                    //comuna = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_PROVEEEDOR"].Value.ToString();
                    //cmbComunas.Text = comuna;

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["ROL"].Value.ToString();

                    //edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    //txtEdad.Text = edad;

                    contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_PROVEEEDOR"].Value.ToString();
                    txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
                else if (tipoUser == "Transportista")
                {
                    txtEdad.Visible = false;
                    lblEdad.Visible = false;
                    rut = dtgUsuarios.Rows[id_fila].Cells["ID_TRANSPORTISTA"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["RAZON_SOCIAL"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["CORREO"].Value.ToString();
                    txtEmail.Text = email;

                    direccion = dtgUsuarios.Rows[id_fila].Cells["TELEFONO"].Value.ToString();
                    txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["DIRECCION"].Value.ToString();
                    txtFono.Text = fono;

                    comuna = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_TRANSPORTISTA"].Value.ToString();
                    cmbComunas.Text = comuna;

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["ROL"].Value.ToString();

                    //edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    //txtEdad.Text = edad;

                    //contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA"].Value.ToString();
                    //txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
                else if (tipoUser == "Cliente extranjero")
                {
                    txtEdad.Visible = false;
                    lblEdad.Visible = false;
                    txtDirec.Visible = false;
                    lblDirec.Visible = false;
                    rut = dtgUsuarios.Rows[id_fila].Cells["DNI"].Value.ToString();
                    txtRut.Text = rut;

                    nombre = dtgUsuarios.Rows[id_fila].Cells["NOMBRE"].Value.ToString();
                    txtNombre.Text = nombre;

                    email = dtgUsuarios.Rows[id_fila].Cells["COD_PAIS"].Value.ToString();
                    txtEmail.Text = email;

                    //direccion = dtgUsuarios.Rows[id_fila].Cells["TELEFONO"].Value.ToString();
                    //txtDirec.Text = direccion;

                    fono = dtgUsuarios.Rows[id_fila].Cells["TELEFONO"].Value.ToString();
                    txtFono.Text = fono;

                    comuna = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA_CLIENTE"].Value.ToString();
                    cmbComunas.Text = comuna;

                    lblComuna.Text = dtgUsuarios.Rows[id_fila].Cells["ROL"].Value.ToString();

                    //edad = dtgUsuarios.Rows[id_fila].Cells["EDAD"].Value.ToString();
                    //txtEdad.Text = edad;

                    //contraseña = dtgUsuarios.Rows[id_fila].Cells["CONTRASEÑA"].Value.ToString();
                    //txtContraseña.Text = contraseña;

                    estado = dtgUsuarios.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                    txtEstado.Text = estado;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            ora.Open();

            string stsqlx = "pc_buscar_persona";
            OracleCommand queryEx = new OracleCommand(stsqlx, ora);
            queryEx.CommandType = CommandType.StoredProcedure;
            queryEx.Parameters.Add("runn", txtId.Text);
            queryEx.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;
            queryEx.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(queryEx);
            da.Fill(dt);

            string validacion = "" + queryEx.Parameters["validar"].Value;
            int val = Convert.ToInt32(validacion);

            if (val == 1)
            {
                dtgUsuarios.DataSource = dt;

            }
            else
            {
                string sqSql = "pc_buscar_proveedor";
                OracleCommand queryProv = new OracleCommand(sqSql, ora);
                queryProv.CommandType = CommandType.StoredProcedure;
                queryProv.Parameters.Add("runn", txtId.Text);
                queryProv.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;
                queryProv.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                DataTable dtProv = new DataTable();
                OracleDataAdapter daProv = new OracleDataAdapter(queryProv);
                daProv.Fill(dtProv);

                string validacionProv = "" + queryProv.Parameters["validar"].Value;
                int valProv = Convert.ToInt32(validacionProv);

                if (valProv == 1)
                {
                    dtgUsuarios.DataSource = dtProv;
                }
                else
                {
                    string sqSqlTrans = "pc_buscar_transportista";
                    OracleCommand queryTrans = new OracleCommand(sqSqlTrans, ora);
                    queryTrans.CommandType = CommandType.StoredProcedure;
                    queryTrans.Parameters.Add("runn", txtId.Text);
                    queryTrans.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    queryTrans.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                    DataTable dtTrans = new DataTable();
                    OracleDataAdapter daTrans = new OracleDataAdapter(queryTrans);
                    daTrans.Fill(dtTrans);

                    string validacionTrans = "" + queryTrans.Parameters["validar"].Value;
                    int valTrans = Convert.ToInt32(validacionTrans);

                    if (valTrans == 1)
                    {
                        dtgUsuarios.DataSource = dtTrans;
                    }
                    else
                    {
                        string sqSqlCliEx = "pc_buscar_cli_ex";
                        OracleCommand queryCliEx = new OracleCommand(sqSqlCliEx, ora);
                        queryCliEx.CommandType = CommandType.StoredProcedure;
                        queryCliEx.Parameters.Add("runn", txtId.Text);
                        queryCliEx.Parameters.Add("validar", OracleDbType.Int32).Direction = ParameterDirection.Output;
                        queryCliEx.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                        DataTable dtCliEx = new DataTable();
                        OracleDataAdapter daCliEx = new OracleDataAdapter(queryCliEx);
                        daCliEx.Fill(dtCliEx);

                        string validacionCliEx = "" + queryCliEx.Parameters["validar"].Value;
                        int valCliEx = Convert.ToInt32(validacionCliEx);

                        if (valCliEx == 1)
                        {
                            dtgUsuarios.DataSource = dtCliEx;
                        }
                        else
                        {
                            txtId.Text = "El usuario no existe";
                        }
                    }
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            ora.Open();
            string rolcmb = cmbRol.Text;
            if (rolcmb == "Seleccione")
            {
                MessageBox.Show("Debe seleccionar un rol");
            }
            else
            {
                int rol = Convert.ToInt32(cmbRol.SelectedValue.ToString());
                if (rol > 0 && rol < 5)
                {

                }
                else if (rol == 5)
                {
                    string sqSql = "PC_EDIT_PROVEEDOR";
                    OracleCommand queryProv = new OracleCommand(sqSql, ora);
                    queryProv.CommandType = CommandType.StoredProcedure;
                    queryProv.Parameters.Add("id_pro", txtRut.Text);
                    queryProv.Parameters.Add("nombre", txtNombre.Text);
                    queryProv.Parameters.Add("fono", txtFono.Text);
                    queryProv.Parameters.Add("email", txtEmail.Text);
                    queryProv.Parameters.Add("dire", txtDirec.Text);
                    queryProv.Parameters.Add("id_contrapro", txtContraseña.Text);

                    queryProv.ExecuteNonQuery();

                    MessageBox.Show("Usuario " + txtNombre.Text + "Actualizado correctamente");
                }
            }
        }
            

        private void cmbRol_Click(object sender, EventArgs e)
        {
            cmbRol.DataSource = listaRoles();
            cmbRol.DisplayMember = "TIPO";
            cmbRol.ValueMember = "ID_USUARIO";
        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblRolSeleccionado.Text == "Administración")
            {
                txtEdad.Visible = true;
                lblEdad.Visible = true;

            }
            else if (lblRolSeleccionado.Text == "Cliente interno")
            {
                txtEdad.Visible = true;
                lblEdad.Visible = true;
            }
            else if (lblRolSeleccionado.Text == "Cliente externo")
            {
                txtEdad.Visible = true;
                lblEdad.Visible = true;
            }
            else if (lblRolSeleccionado.Text == "consultor")
            {
                txtEdad.Visible = true;
                lblEdad.Visible = true;
            }
            else if (lblRolSeleccionado.Text == "Productor")
            {
                txtEdad.Visible = true;
                lblEdad.Visible = true;
            }
            else if (lblRolSeleccionado.Text == "Transportista")
            {
                txtEdad.Visible = true;
                lblEdad.Visible = true;
            }
            else if (lblRolSeleccionado.Text == "Cliente extranjero")
            {
                txtEdad.Visible = true;
                lblEdad.Visible = true;
            }
        }

        private void cmbComunas_Click(object sender, EventArgs e)
        {
            cmbComunas.DataSource = listacomuna();
            cmbComunas.DisplayMember = "COMUNA";
            cmbComunas.ValueMember = "ID_COMUNA";
        }
    }
}
        
    

