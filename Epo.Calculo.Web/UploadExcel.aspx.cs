using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace Epo.Calculo.Web
{
    public partial class UploadExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            string arquivo = Server.MapPath("~/Excel/") + FileUpload1.PostedFile.FileName;
            FileUpload1.SaveAs(arquivo);
            string strConexao = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"", arquivo);
            OleDbConnection conn = new OleDbConnection(strConexao);
            conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //Cria o objeto dataset para receber o conteúdo do arquivo Excel
            DataSet output = new DataSet();
            foreach (DataRow row in dt.Rows)
            {
                // obtem o noma da planilha corrente
                string sheet = row["TABLE"].ToString();
                // obtem todos as linhas da planilha corrente
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                cmd.CommandType = CommandType.Text;
                // copia os dados da planilha para o datatable
                DataTable outputTable = new DataTable(sheet);
                output.Tables.Add(outputTable);
                new OleDbDataAdapter(cmd).Fill(outputTable);
            }
            GridView1.DataSource = output.Tables[0];
            GridView1.DataBind();
        }
    }
}