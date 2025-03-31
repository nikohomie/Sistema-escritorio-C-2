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
using CrystalDecisions.CrystalReports;

namespace GUI_V_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string stsql = "pc_lista_ventas";
            OracleConnection cnx = new OracleConnection("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id = prueba13; Password = 1234;");
            OracleCommand query = new OracleCommand(stsql, cnx);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.Add("c_lista", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cnx.Open();

            DataTable dt = new DataTable();
            OracleDataAdapter da = new OracleDataAdapter(query);
            da.Fill(dt);

            CrystalReport1 cr1 = new CrystalReport1();
            cr1.SetDataSource(dt);

            crystalReportViewer1.ReportSource = cr1;
            //crystalReportViewer1.Refresh();

            cnx.Close();

        }
    }
}
