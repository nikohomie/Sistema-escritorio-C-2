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
    public partial class Despacho : Form
    {
        int id_fila;
        public Despacho()
        {
            InitializeComponent();
        }

        private void listaDespachos()
        {
            string stsql = "pc_lista_despachos";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            query.ExecuteNonQuery();
            ora.Close();

            dataGridView1.DataSource = dt;
        }

        private void busquedaDespacho()
        {
            string stsql = "pc_busqueda_despachos";
            OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("idDespacho", txtnombre.Text);
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);
            query.ExecuteNonQuery();
            ora.Close();

            dataGridView1.DataSource = dt;
        }

        private void Despacho_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersVisible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            
            listaDespachos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Length < 1)
            {
                MessageBox.Show("Debe ingresar un codigo de despacho para continuar con la busqueda");
            }
            else
            {
                busquedaDespacho();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_fila = e.RowIndex;

            string idDespacho;
            string idVenta;
            string fecIngreso;
            string hrIngreso;
            string fecInicio;
            string hrInicio;
            string fecEntrega;
            string hrEntrega;
            string detalle;
            string codSeguimiento;
            string tipoDespacho;
            string estado;

            if (dataGridView1.Rows.Count > 0)
            {
                idDespacho = dataGridView1.Rows[id_fila].Cells["ID_DESPACHO"].Value.ToString();
                txtCodDespacho.Text = idDespacho;

                fecIngreso = dataGridView1.Rows[id_fila].Cells["FEC_INGRESO_PEDIDO"].Value.ToString();
                txtFecIngreso.Text = fecIngreso;

                hrIngreso = dataGridView1.Rows[id_fila].Cells["HR_INGRESO_PEDIDO"].Value.ToString();
                txtHrIngreso.Text = hrIngreso;

                fecInicio = dataGridView1.Rows[id_fila].Cells["FEC_INICIO_DESPACHO"].Value.ToString();
                txtFecIni.Text = fecInicio;

                hrInicio = dataGridView1.Rows[id_fila].Cells["HR_INICIO_DESPACHO"].Value.ToString();
                txtHrIni.Text = hrInicio;

                fecEntrega = dataGridView1.Rows[id_fila].Cells["FECHA_ENTREGA"].Value.ToString();
                txtFecEntrega.Text = fecEntrega;

                hrEntrega = dataGridView1.Rows[id_fila].Cells["HR_ENTREGA"].Value.ToString();
                txtHrEntrega.Text = hrEntrega;

                detalle = dataGridView1.Rows[id_fila].Cells["DETALLES"].Value.ToString();
                txtDetalle.Text = detalle;

                codSeguimiento = dataGridView1.Rows[id_fila].Cells["CODIGO_SEGUIMIENTO"].Value.ToString();
                txtCodSeguimiento.Text = codSeguimiento;

                estado = dataGridView1.Rows[id_fila].Cells["ESTADO_ENVIO"].Value.ToString();
                txtEstadoEnvio.Text = estado;

                tipoDespacho = dataGridView1.Rows[id_fila].Cells["TIPO_DESPACHO"].Value.ToString();
                cmbTipoDesp.Text = tipoDespacho;

                idVenta = dataGridView1.Rows[id_fila].Cells["COD_VENTA"].Value.ToString();
                txtCodVenta.Text = idVenta;

            }
        }

        private void cmbTipoDesp_Click(object sender, EventArgs e)
        {

        }
    }
}
