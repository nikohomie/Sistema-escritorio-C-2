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
    public partial class Vencs : Form
    {
        int id_fila;
        public int idVenta { get; set; }
        public Vencs()
        {
            InitializeComponent();
        }

        public DataTable listaVentasEx()
        {
            string stsql = "pc_lista_ventas_ex";
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

        public DataTable listaDocumento()
        {
            string stsql = "pc_lista_documento";
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

        public DataTable listaMedioPago()
        {
            string stsql = "pc_lista_medio";
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string stsql = "pc_desactivar_venta_ex";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand queryVenta = new OracleCommand(stsql, ora);
            ora.Open();
            queryVenta.CommandType = CommandType.StoredProcedure;
            queryVenta.Parameters.Add("codVenta", txtVentaa.Text);

            if (txtVentaa.Text.Length > 0)
            {
                queryVenta.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una venta o introducir el codigo en el campo (ID) para continuar");
            }
            ora.Close();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vencs_Load(object sender, EventArgs e)
        {

            cmbMedioPago.DataSource = listaMedioPago();
            cmbMedioPago.DisplayMember = "TIPO";
            cmbMedioPago.ValueMember = "ID_PAGO";
            
            cmbDocumento.DataSource = listaDocumento();
            cmbDocumento.DisplayMember = "TIPO_DOCUMENTO";
            cmbDocumento.ValueMember = "ID_DOCUMENTO";
            /*
            dataGridView1.DataSource = listaVentasEx();
            */
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_fila = e.RowIndex;

            string idVenta;

            if (dataGridView1.Columns.Contains("ID_VENTA_EXTRA"))
            {
                idVenta = dataGridView1.Rows[id_fila].Cells["ID_VENTA_EXTRA"].Value.ToString();
                txtVentaa.Text = idVenta;
            }
            else
            {
                idVenta = dataGridView1.Rows[id_fila].Cells["ID_VENTA"].Value.ToString();
                txtVentaa.Text = idVenta;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string stsql = "pc_buscar_venta";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand queryVenta = new OracleCommand(stsql, ora);
            ora.Open();
            queryVenta.CommandType = CommandType.StoredProcedure;
            queryVenta.Parameters.Add("idVenta", txtVentaa.Text);
            queryVenta.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(queryVenta);
            da.Fill(dt);

            if (txtVentaa.Text.Length > 0)
            {
                queryVenta.ExecuteNonQuery();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("El ID ingresado no corresponde a ninguna venta");
                }
            }
            else
            {
                MessageBox.Show("Debe introducir un codigo en el campo (ID) para continuar");
            }
            ora.Close();
        }

        public void listaSolicitudes()
        {
            string stsql = "pc_lista_solicitudes";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand querySol = new OracleCommand(stsql, ora);
            ora.Open();
            querySol.CommandType = CommandType.StoredProcedure;
            querySol.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(querySol);
            da.Fill(dt);

            cmbSolicitud.DataSource = dt;
            cmbSolicitud.DisplayMember = "detalle_soli";
            cmbSolicitud.ValueMember = "id_solicitud";
        }

        public int CodSegDespacho()
        {
            //var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var characters = "0123456789";
            var Charsarr = new char[8];
            var random = new Random();

            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var cod = new String(Charsarr);
            int codSeguimiento = Convert.ToInt32(cod);

            return codSeguimiento;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (cmbTipoVenta.Text == "Seleccione categoria")
            {
                MessageBox.Show("Debe seleccionar una categoria de venta para continuar");
            }
            else if (cmbTipoVenta.Text == "Local")
            {
                
                if (cmbDocumento.Text == "Seleccione tipo recibo" || cmbMedioPago.Text == "Seleccione medio de pago" || cmbCli.Text == "Seleccione un cliente")
                {
                    MessageBox.Show("Todos los campos son obligatorios para continuar");
                }
                else
                {
                    string stsql = "PC_INSERT_VENTA";
                    OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
                    OracleCommand queryVenta = new OracleCommand(stsql, ora);

                    

                    string consulta = "select seq_id_venta.nextval from dual";
                    OracleCommand cmd = new OracleCommand(consulta, ora);
                    cmd.CommandType = CommandType.Text;


                    OracleDataReader lector = cmd.ExecuteReader();

                    ora.Open();

                    if (lector.Read())
                    {
                        idVenta = Convert.ToInt32(lector["seq_id_venta.nextval"].ToString());
                    }

                    queryVenta.CommandType = CommandType.StoredProcedure;
                    queryVenta.Parameters.Add("codVenta", idVenta);
                    queryVenta.Parameters.Add("fecha", dtpFecVenta.Value);
                    queryVenta.Parameters.Add("docu", cmbDocumento.SelectedValue);
                    queryVenta.Parameters.Add("hora", Convert.ToDateTime(txtHora.Text));
                    queryVenta.Parameters.Add("rut", cmbCli.SelectedValue);
                    queryVenta.Parameters.Add("pago", cmbMedioPago.SelectedValue);


                    string consulta2 = "PC_INSERT_DESPACHO";
                    OracleCommand cmd2 = new OracleCommand(consulta2, ora);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("fecha_ingre", dtpFecVenta.Value);
                    cmd2.Parameters.Add("hora_ingre", Convert.ToDateTime(txtHora.Text));
                    cmd2.Parameters.Add("fecha_ini", null);
                    cmd2.Parameters.Add("hora_ini", null);
                    cmd2.Parameters.Add("fecha_entre", null);
                    cmd2.Parameters.Add("hr_entre", null);
                    cmd2.Parameters.Add("deta", txtDetalle.Text);
                    cmd2.Parameters.Add("cod_segui", CodSegDespacho());
                    cmd2.Parameters.Add("tipo_despa", cmbTipoDespacho.SelectedValue);
                    cmd2.Parameters.Add("venta", idVenta);


                    queryVenta.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                    MessageBox.Show("Venta registrada correctamente");

                    ora.Close();
                }
            }
            else
            {
                

                if (cmbCli.Text == "Seleccione un cliente" || cmbSolicitud.Text == "Seleccione solicitud")
                {
                    MessageBox.Show("Todos los campos son obligatorios para continuar");
                }
                else
                {

                    string stsql = "PC_INSERT_VENTA_EXTRA";
                    OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
                    OracleCommand queryVenta = new OracleCommand(stsql, ora);
                    ora.Open();
                    queryVenta.CommandType = CommandType.StoredProcedure;
                    queryVenta.Parameters.Add("fecha", dtpFecVenta.Value.ToString().Substring(10));
                    queryVenta.Parameters.Add("hora", txtHora.Text);
                    if (cmbSolicitud.Text == "Seleccione solicitud")
                    {
                        MessageBox.Show("Debes seleccionar una solicitud para continuar");
                    }
                    else
                    {
                        queryVenta.Parameters.Add("soli", cmbSolicitud.SelectedValue);
                        queryVenta.ExecuteNonQuery();

                        MessageBox.Show("Venta registrada correctamente");
                    }
                    ora.Close();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void cmbTipoVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTipoVenta.Text = cmbTipoVenta.Text;
            if (lblTipoVenta.Text == "Extranjero")
            {
                lblDocumento.Visible = false;
                cmbDocumento.Visible = false;
                lblSolicitud.Visible = true;
                cmbSolicitud.Visible = true;
                cmbMedioPago.Visible = false;
                label4.Visible = false;
                lblDetalles.Visible = false;
                lblTitulo.Visible = false;
                txtDetalle.Visible = false;
                cmbTipoDespacho.Visible = false;
                lblTipoDespacho.Visible = false;
            }
            else if (lblTipoVenta.Text == "Local")
            {
                lblDocumento.Visible = true;
                cmbDocumento.Visible = true;
                lblSolicitud.Visible = false;
                cmbSolicitud.Visible = false;
                lblDetalles.Visible = true;
                lblTitulo.Visible = true;
                txtDetalle.Visible = true;
                cmbTipoDespacho.Visible = true;
                lblTipoDespacho.Visible = true;


            }
        }

        private void cmbSolicitud_Click(object sender, EventArgs e)
        {
            listaSolicitudes();
        }

        public void listaCliente()
        {
            string stsql = "pc_lista_clientes_2";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("tipoCli", cmbTipoVenta.SelectedItem);
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            if (dt.Columns.Contains("dni"))
            {
                cmbCli.DataSource = dt;
                cmbCli.DisplayMember = "nombre";
                cmbCli.ValueMember = "dni";
            }
            else
            {
                cmbCli.DataSource = dt;
                cmbCli.DisplayMember = "nombre";
                cmbCli.ValueMember = "rut";
            }
            

            ora.Close();
            
        }

        private void cmbCli_Click(object sender, EventArgs e)
        {
            listaCliente();
        }

        private void txtVentaa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
