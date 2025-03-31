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
    public partial class sub : Form
    {
        public string idPersona { get; set; }
        string tipoSub;
        int id_fila;

        OracleConnection ora = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");


        public sub()
        {
            InitializeComponent();
        }

        private void listaSubastas()
        {
            string stsql = "pc_lista_subastas";
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgvSubastas.DataSource = dt;
        }

        private void listaSolicitudes()
        {
            string stsql = "pc_lista_solicitudes";
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            cmbSolicitud.DataSource = dt;
            cmbSolicitud.DisplayMember = "Detalle_soli";
            cmbSolicitud.ValueMember = "id_solicitud";
        }

        private void listaSubastasEx()
        {
            string stsql = "pc_lista_subastas_ex";
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgvSubastas.DataSource = dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblIDPErsona.Text = idPersona;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ora.Open();
            DialogResult result = MessageBox.Show("Al terminar una subasta, se seleccionará automaticamente el ganador de esta, desea continuar?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //Selección de ganador subasta transporte
                string stsql = "pc_insert_ganador";
                OracleCommand query = new OracleCommand(stsql, ora);
                query.CommandType = CommandType.StoredProcedure;

                //Selección de ganador subasta extranjero
                string stsqlEx = "pc_insert_ganador_2";
                OracleCommand query2 = new OracleCommand(stsqlEx, ora);
                query2.CommandType = CommandType.StoredProcedure;

                if (txtnombre.Text.Length > 0)
                    {
                        //Pasamos parametros al procedimiento
                        query.Parameters.Add("subs", txtnombre.Text);
                        //Se ejecuta el procedimiento
                        query.ExecuteNonQuery();

                    //Pasamos parametros al procedimiento
                    query2.Parameters.Add("subs", txtnombre.Text);
                    //Se ejecuta el procedimiento
                    query2.ExecuteNonQuery();


                    MessageBox.Show("Subasta concluida correctamente");
                    }
                    else if (txtIdSubasta.Text.Length > 0)
                    {
                        //Pasamos parametros al procedimiento
                        query.Parameters.Add("subs", txtIdSubasta.Text);
                        //Se ejecuta el procedimiento
                        query.ExecuteNonQuery();

                    //Pasamos parametros al procedimiento
                    query2.Parameters.Add("subs", txtIdSubasta.Text);
                    //Se ejecuta el procedimiento
                    query2.ExecuteNonQuery();

                    MessageBox.Show("Subasta concluida correctamente");
                    }
                    else
                    {
                        MessageBox.Show("Debe indicar el codigo de la subasta que desea concluir");
                    }
                    ora.Close();
                
            }
            else if(result == DialogResult.No)
            {
                ora.Close();
            }
            ora.Close();
        }

        private void dtgvSubastas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_fila = e.RowIndex;

            string idSubas;
            string fecIni;
            string hrTerm;
            string fecTerm;
            string hrIni;
            string nom;
            string precio;
            string estado;
            string admin;
            string codSoli;

            if (dtgvSubastas.Columns.Contains("id_subasta_extra"))
            {
                idSubas = dtgvSubastas.Rows[id_fila].Cells["ID_SUBASTA_EXTRA"].Value.ToString();
                txtIdSubasta.Text = idSubas;

                fecIni = dtgvSubastas.Rows[id_fila].Cells["FECHA_INICIO_EXTRA"].Value.ToString();
                txtFecini.Text = fecIni;

                hrIni = dtgvSubastas.Rows[id_fila].Cells["HORA_INICIO_EXTRA"].Value.ToString();
                txtHoraIni.Text = hrIni;

                fecTerm = dtgvSubastas.Rows[id_fila].Cells["FECHA_TERMINO_EXTRA"].Value.ToString();
                txtFecTerm.Text = fecTerm;

                hrTerm = dtgvSubastas.Rows[id_fila].Cells["HORA_TERMINO_EXTRA"].Value.ToString();
                txtHrTerm.Text = hrTerm;

                nom = dtgvSubastas.Rows[id_fila].Cells["SUBASTA_EXTRA"].Value.ToString();
                txtNom.Text = nom;

                precio = dtgvSubastas.Rows[id_fila].Cells["PRECIO_BASE_EXTRA"].Value.ToString();
                txtPrecio.Text = precio;

                estado = dtgvSubastas.Rows[id_fila].Cells["ESTADO_SUBASTA_EXTRA"].Value.ToString();
                txtEstado.Text = estado;

                admin = dtgvSubastas.Rows[id_fila].Cells["COD_SOLICITUD"].Value.ToString();
                txtAdmin.Text = admin;
            }else if (dtgvSubastas.Columns.Contains("cod_persona"))
            {
                idSubas = dtgvSubastas.Rows[id_fila].Cells["ID_SUBASTA"].Value.ToString();
                txtIdSubasta.Text = idSubas;

                fecIni = dtgvSubastas.Rows[id_fila].Cells["FECHA_INICIO"].Value.ToString();
                txtFecini.Text = fecIni;

                hrIni = dtgvSubastas.Rows[id_fila].Cells["HORA_INICIO"].Value.ToString();
                txtHoraIni.Text = hrIni;

                fecTerm = dtgvSubastas.Rows[id_fila].Cells["FECHA_TERMINO"].Value.ToString();
                txtFecTerm.Text = fecTerm;

                hrTerm = dtgvSubastas.Rows[id_fila].Cells["HORA_TERMINO"].Value.ToString();
                txtHrTerm.Text = hrTerm;

                nom = dtgvSubastas.Rows[id_fila].Cells["SUBASTA"].Value.ToString();
                txtNom.Text = nom;

                precio = dtgvSubastas.Rows[id_fila].Cells["PRECIO_BASE"].Value.ToString();
                txtPrecio.Text = precio;

                estado = dtgvSubastas.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                txtEstado.Text = estado;

                admin = dtgvSubastas.Rows[id_fila].Cells["COD_PERSONA"].Value.ToString();
                txtAdmin.Text = admin;
            }

            tipoSub = cmbTipoSub.SelectedItem.ToString();
            if (tipoSub == "Transportes")
            {
                idSubas = dtgvSubastas.Rows[id_fila].Cells["ID_SUBASTA"].Value.ToString();
                txtIdSubasta.Text = idSubas;

                fecIni = dtgvSubastas.Rows[id_fila].Cells["FECHA_INICIO"].Value.ToString();
                txtFecini.Text = fecIni;

                hrIni = dtgvSubastas.Rows[id_fila].Cells["HORA_INICIO"].Value.ToString();
                txtHoraIni.Text = hrIni;

                fecTerm = dtgvSubastas.Rows[id_fila].Cells["FECHA_TERMINO"].Value.ToString();
                txtFecTerm.Text = fecTerm;

                hrTerm = dtgvSubastas.Rows[id_fila].Cells["HORA_TERMINO"].Value.ToString();
                txtHrTerm.Text = hrTerm;

                nom = dtgvSubastas.Rows[id_fila].Cells["SUBASTA"].Value.ToString();
                txtNom.Text = nom;

                precio = dtgvSubastas.Rows[id_fila].Cells["PRECIO_BASE"].Value.ToString();
                txtPrecio.Text = precio;

                estado = dtgvSubastas.Rows[id_fila].Cells["ESTADO"].Value.ToString();
                txtEstado.Text = estado;

                admin = dtgvSubastas.Rows[id_fila].Cells["COD_PERSONA"].Value.ToString();
                txtAdmin.Text = admin;
            }
            else if (tipoSub == "Extranjero")
            {
                idSubas = dtgvSubastas.Rows[id_fila].Cells["ID_SUBASTA_EXTRA"].Value.ToString();
                txtIdSubasta.Text = idSubas;

                fecIni = dtgvSubastas.Rows[id_fila].Cells["FECHA_INICIO_EXTRA"].Value.ToString();
                txtFecini.Text = fecIni;

                hrIni = dtgvSubastas.Rows[id_fila].Cells["HORA_INICIO_EXTRA"].Value.ToString();
                txtHoraIni.Text = hrIni;

                fecTerm = dtgvSubastas.Rows[id_fila].Cells["FECHA_TERMINO_EXTRA"].Value.ToString();
                txtFecTerm.Text = fecTerm;

                hrTerm = dtgvSubastas.Rows[id_fila].Cells["HORA_TERMINO_EXTRA"].Value.ToString();
                txtHrTerm.Text = hrTerm;

                nom = dtgvSubastas.Rows[id_fila].Cells["SUBASTA_EXTRA"].Value.ToString();
                txtNom.Text = nom;

                precio = dtgvSubastas.Rows[id_fila].Cells["PRECIO_BASE_EXTRA"].Value.ToString();
                txtPrecio.Text = precio;

                estado = dtgvSubastas.Rows[id_fila].Cells["ESTADO_SUBASTA_EXTRA"].Value.ToString();
                txtEstado.Text = estado;

                admin = dtgvSubastas.Rows[id_fila].Cells["COD_SOLICITUD"].Value.ToString();
                txtAdmin.Text = admin;
            }

            
        }

        private void cmbTipoSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoSub = cmbTipoSub.SelectedItem.ToString();
            if (tipoSub == "Transportes")
            {
                listaSubastas();
                lblcodigo.Text = "Codigo Persona ";
            }
            else if(tipoSub == "Extranjero")
            {
                listaSubastasEx();

                lblcodigo.Text = "Codigo Solicitud ";


            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //cmbTipoSub.
            if (cmbTipoSub.SelectedItem.ToString() == "Seleccione")
            {
                MessageBox.Show("Debe seleccionar una subasta");
            }
            else
            {
                tipoSub = cmbTipoSub.SelectedItem.ToString();
                if (tipoSub == "Transportes")
                {
                    string stsql = "PC_EDIT_SUBASTA";
                    OracleCommand query = new OracleCommand(stsql, ora);
                    query.CommandType = CommandType.StoredProcedure;
                    query.Parameters.Add("id_suba", txtIdSubasta.Text);
                    query.Parameters.Add("suba", txtNom.Text);
                    query.Parameters.Add("fecha_ini", txtFecini.Text);
                    query.Parameters.Add("hora_ini", txtHoraIni.Text);
                    query.Parameters.Add("precio", txtPrecio.Text);
                    query.Parameters.Add("fecha", txtFecTerm.Text);
                    query.Parameters.Add("estado_suba", txtEstado.Text);
                    query.Parameters.Add("hora_ter", txtHrTerm.Text);
                    query.Parameters.Add("persona", txtAdmin.Text);
                    ora.Open();

                    query.ExecuteNonQuery();
                    ora.Close();
                    MessageBox.Show("Subasta actualizada correctamente");

                }
                else if (tipoSub == "Extranjero")
                {
                    string stsql = "PC_EDIT_SUBASTA_EXTRANJERO";
                    OracleCommand query = new OracleCommand(stsql, ora);
                    query.CommandType = CommandType.StoredProcedure;
                    query.Parameters.Add("id_subasta",txtIdSubasta.Text);
                    query.Parameters.Add("subasta", txtNom.Text);
                    query.Parameters.Add("fecha_ini", txtFecini.Text);
                    query.Parameters.Add("hora_ini", txtHoraIni.Text);
                    query.Parameters.Add("precio", txtPrecio.Text);
                    query.Parameters.Add("fecha_ter", txtFecTerm.Text);
                    query.Parameters.Add("estado",txtEstado.Text);
                    query.Parameters.Add("hora_ter", txtHrTerm.Text);
                    query.Parameters.Add("solicitud", txtAdmin.Text);
                    ora.Open();

                  
                    ora.Close();
                    MessageBox.Show("Subasta actualizada correctamente");
                }
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //Procedimiento para buscar subasta
            string stsqlBuscar = "pc_buscar_subasta";
            OracleCommand query1 = new OracleCommand(stsqlBuscar, ora);
            query1.CommandType = CommandType.StoredProcedure;
            query1.Parameters.Add("idSub", txtIdSubasta.Text);
            query1.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query1);
            da.Fill(dt);
            ora.Open();
            query1.ExecuteNonQuery();

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("La subasta " + txtIdSubasta.Text + " ya está registrada");
            }
            else
            {
                string stsql = "PC_INSERT_SUBASTA";
                OracleCommand query = new OracleCommand(stsql, ora);
                query.CommandType = CommandType.StoredProcedure;
                query.Parameters.Add("subasta", txtIdSubasta.Text);
                query.Parameters.Add("precio", txtPrecio.Text);
                query.Parameters.Add("fecha", txtFecTerm.Text);
                query.Parameters.Add("estado", txtEstado.Text);
                query.Parameters.Add("hora_ter", txtHrTerm.Text);
                query.Parameters.Add("persona", idPersona);

                if (cmbSolicitud.Text == "Seleccione una solicitud")
                {
                    MessageBox.Show("Debe seleccionar una solicitud para crear subasta");
                }
                else
                {
                    query.ExecuteNonQuery();
                    MessageBox.Show("Subasta creada correctamente");
                }
            }
            ora.Close();
        }

        private void cmbSolicitud_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbSolicitud_Click(object sender, EventArgs e)
        {
            listaSolicitudes();
        }

        private void sub_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void buscarSubastas(int idSub)
        {
            string stsql = "pc_buscar_subasta";
            OracleCommand query = new OracleCommand(stsql, ora);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("idSub", idSub);
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            ora.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            ora.Close();

            dtgvSubastas.DataSource = dt;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text.Length < 1)
            {
                MessageBox.Show("Debe ingresar un Codigo de subasta en el campo (ID) para realizar la busqueda");
            }
            else
            {
                txtnombre.Text.Trim();
                int codSub = Convert.ToInt32(txtnombre.Text);
                buscarSubastas(codSub);
            }
        }
    }
}
