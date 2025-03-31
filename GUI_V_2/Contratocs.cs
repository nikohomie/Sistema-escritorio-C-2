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
    public partial class Contratocs : Form
    {
        public Contratocs()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listaEstados()
        {
            string stsql = "pc_lista_estado_contrato";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            cmbEstadoContrato.DataSource = dt;
            cmbEstadoContrato.DisplayMember = "ESTADO";
            cmbEstadoContrato.ValueMember = "ID_ESTADO";
        }

        private void Contratocs_Load(object sender, EventArgs e)
        {
            txtFechcon.Enabled = false;
            txtFechcon.Text = Convert.ToString(DateTime.Now).Substring(0,8);

            listaEstados();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string stsql = "pc_desactivar_contrato";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand querycontrato = new OracleCommand(stsql, ora);
            ora.Open();
            querycontrato.CommandType = CommandType.StoredProcedure;
            querycontrato.Parameters.Add("idcontrato", txtidcontratopr.Text);

            querycontrato.ExecuteNonQuery();


            ora.Close();
            lblContrato.Text = "Eliminado Correctamente";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");

            //Procedimiento insert contrato proveedores
            string stsql = "PC_INSERT_CONTRATO";
            OracleCommand querycontrato = new OracleCommand(stsql, ora);

            //Procedimiento insert contrato extranjero
            string stsql2 = "PC_INSERT_CONTRATO_EXTRANJERO";
            OracleCommand querycontratoEx = new OracleCommand(stsql2, ora);

            ora.Open();

            if (lblTipoCli.Text == "Clientes Extranjeros")
            {
                querycontratoEx.CommandType = CommandType.StoredProcedure;
                querycontratoEx.Parameters.Add("fecha", Convert.ToDateTime(txtFechcon.Text));
                querycontratoEx.Parameters.Add("detalle", txtDetalle.Text);
                querycontratoEx.Parameters.Add("fecha_ven", Convert.ToDateTime(dtpFecVenc.Text));
                querycontratoEx.Parameters.Add("estado", Convert.ToInt32(cmbEstadoContrato.SelectedValue));
                querycontratoEx.Parameters.Add("cliente", Convert.ToString(cmbCli.SelectedValue));

                if (txtDetalle.Text.Trim().Length > 0 && txtFechcon.Text.Trim().Length > 0)
                {
                    querycontratoEx.ExecuteNonQuery();
                    MessageBox.Show("Registro de contrato satisfactorio");
                }
                else
                {
                    MessageBox.Show("Debe rellenar todos los campos");
                }
            }
            else
            {
                querycontrato.CommandType = CommandType.StoredProcedure;
                querycontrato.Parameters.Add("fecha_contra", Convert.ToDateTime(txtFechcon.Text));
                querycontrato.Parameters.Add("fecha_ven", Convert.ToDateTime(dtpFecVenc.Text));
                querycontrato.Parameters.Add("estado", Convert.ToInt32(cmbEstadoContrato.SelectedValue));
                querycontrato.Parameters.Add("proveedor", Convert.ToString(cmbCli.SelectedValue));

                if (txtDetalle.Text.Trim().Length > 0 && txtFechcon.Text.Trim().Length > 0)
                {
                    querycontrato.ExecuteNonQuery();
                    MessageBox.Show("Registro de contrato satisfactorio");
                }
                else
                {
                    MessageBox.Show("Debe rellenar todos los campos");
                }
            }
            
            
            
            ora.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void listaPRoveedores()
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

            cmbCli.DataSource = dt;
            cmbCli.DisplayMember = "razon_social";
            cmbCli.ValueMember = "rut_proveedor";
        }

        private void listaClientesEx()
        {
            string stsql = "PC_LISTAR_CLIENTES";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            cmbCli.DataSource = dt;
            cmbCli.DisplayMember = "nombre";
            cmbCli.ValueMember = "dni";
        }

        private void listaContratosProv()
        {
            string stsql = "pc_lista_contratos_prov";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgContratos.DataSource = dt;
        }

        private void listaContratosEx()
        {
            string stsql = "pc_lista_contratos_ex";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgContratos.DataSource = dt;
        }

        private void cmbTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTipoCli.Text = cmbTipoCliente.SelectedItem.ToString();
            if (lblTipoCli.Text == "Proveedores")
            {
                listaPRoveedores();
            }
            else
            {
                listaClientesEx();
            }
        }

        private void cmbCli_Click(object sender, EventArgs e)
        {
            if (cmbTipoCliente.Text == "Seleccione tipo cliente")
            {
                MessageBox.Show("Debe seleccionar un tipo de cliente");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblTipoCli.Text == "Proveedores")
            {
                listaContratosProv();
            }
            else if(lblTipoCli.Text == "Clientes Extranjeros")
            {
                listaContratosEx();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un tipo de clientes para buscar contratos");
            }
        }

        private void txtidcontratopr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
