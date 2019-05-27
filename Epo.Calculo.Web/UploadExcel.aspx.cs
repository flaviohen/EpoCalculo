using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using EPO.Calculo.Motor;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Epo.Calculo.Web
{
    public partial class UploadExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MensagemErros.Visible = false;
            MensagemSucesso.Visible = false;
        }

        protected void btnImportar_Click(object sender, EventArgs e)
        {
            string arquivo = Server.MapPath("~/Excel/") + FileUpload1.PostedFile.FileName;
            string Erros = string.Empty;
            MensagemErros.Visible = false;
            if (File.Exists(arquivo))
            {
                File.Delete(arquivo);
            }

            FileUpload1.SaveAs(arquivo);

            GridView1.DataSource = RetornarDados(arquivo, out Erros);
            GridView1.DataBind();

            if (!string.IsNullOrEmpty(Erros))
            {
                MensagemErros.Visible = true;
                MensagemErros.InnerHtml = Erros;
            }
            else 
            {
                MensagemSucesso.Visible = true;
            }

            //Usando Oledb para acesso aos dados do arquivo Excel
            //string strConexao = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"", arquivo);
            //OleDbConnection conn = new OleDbConnection(strConexao);
            //conn.Open();
            //DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            ////Cria o objeto dataset para receber o conteúdo do arquivo Excel
            //DataSet output = new DataSet();
            //foreach (DataRow row in dt.Rows)
            //{
            //    // obtem o noma da planilha corrente
            //    string sheet = row["TABLE"].ToString();
            //    // obtem todos as linhas da planilha corrente
            //    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
            //    cmd.CommandType = CommandType.Text;
            //    // copia os dados da planilha para o datatable
            //    DataTable outputTable = new DataTable(sheet);
            //    output.Tables.Add(outputTable);
            //    new OleDbDataAdapter(cmd).Fill(outputTable);
            //}
            //GridView1.DataSource = output.Tables[0];
            //GridView1.DataBind();

            //Usando biblioteca do excel

            //Microsoft.Office.Interop.Excel._Application xlApp;
            //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            //Microsoft.Office.Interop.Excel.Range range;


            //xlApp = new Microsoft.Office.Interop.Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Open(arquivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            //range = xlWorkSheet.UsedRange;
            //List<string> lstColunas = new List<string>();

            //int linhas = range.Rows.Count;
            //int colunas = range.Columns.Count;
            //string valor = string.Empty;

            //List<DadosAgroEquipamentos> lstItemCotacao = new List<DadosAgroEquipamentos>();
            //DadosAgroEquipamentos dadosAgroEquipamentos = null;
            //CoberturaAdicional coberturaAdicional = null;


            //for (int l = 2; l <= linhas; l++)
            //{
            //    dadosAgroEquipamentos = new DadosAgroEquipamentos();
            //    PropertyInfo[] propriedades = dadosAgroEquipamentos.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //    for (int c = 0; c < propriedades.Count(); c++)
            //    {
            //        if (!propriedades[c].PropertyType.IsGenericType)
            //        {
            //            if (propriedades[c].PropertyType.Name == "DateTime")
            //            {
            //                propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(DateTime.Now, range.Cells[l, c + 1].Value2), null);
            //            }
            //            else if (propriedades[c].PropertyType.Name == "String")
            //            {
            //                propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(String.Empty, range.Cells[l, c + 1].Value2), null);
            //            }
            //            else if (propriedades[c].PropertyType.Name == "Decimal")
            //            {
            //                propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(Decimal.MinValue, range.Cells[l, c + 1].Value2), null);
            //            }
            //            else if (propriedades[c].PropertyType.Name == "Int32")
            //            {
            //                propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(Int32.MinValue, range.Cells[l, c + 1].Value2), null);
            //            }
            //            else if (propriedades[c].PropertyType.Name == "Long")
            //            {
            //                propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(long.MinValue, range.Cells[l, c + 1].Value2), null);
            //            }
            //            else if (propriedades[c].PropertyType.Name == "Double")
            //            {
            //                propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(double.MinValue, range.Cells[l, c + 1].Value2), null);
            //            }           
            //        }
            //    }
            //    //dadosAgroEquipamentos = new DadosAgroEquipamentos();
            //    //dadosAgroEquipamentos.DataInicio = ValidarValor(dadosAgroEquipamentos.DataInicio, range.Cells[l, 1].Value2);
            //    //dadosAgroEquipamentos.DataFim = ValidarValor(dadosAgroEquipamentos.DataFim,range.Cells[l, 2].Value2);
            //    //dadosAgroEquipamentos.TipoPessoa = ValidarValor(dadosAgroEquipamentos.TipoPessoa, range.Cells[l, 3].Value2);
            //    //dadosAgroEquipamentos.NumeroCpfCnpj = ValidarValor(dadosAgroEquipamentos.NumeroCpfCnpj, range.Cells[l, 4].Value2);
            //    //dadosAgroEquipamentos.NomeSegurado = ValidarValor(dadosAgroEquipamentos.NomeSegurado, range.Cells[l, 5].Value2);
            //    //dadosAgroEquipamentos.Item =  ValidarValor(dadosAgroEquipamentos.Item, range.Cells[l, 6].Value2);
            //    //dadosAgroEquipamentos.TipoSeguro = ValidarValor(dadosAgroEquipamentos.TipoSeguro, range.Cells[l, 7].Value2);
            //    //dadosAgroEquipamentos.ApoliceAnterior = ValidarValor(dadosAgroEquipamentos.ApoliceAnterior, range.Cells[l, 8].Value2);
            //    //dadosAgroEquipamentos.SeguradoAnterior = ValidarValor(dadosAgroEquipamentos.SeguradoAnterior ,range.Cells[l, 9].Value2);
            //    //dadosAgroEquipamentos.AnosExperiencia = ValidarValor(dadosAgroEquipamentos.AnosExperiencia, range.Cells[l, 10].Value2);
            //    //dadosAgroEquipamentos.SinistroPremio = ValidarValor(dadosAgroEquipamentos.SinistroPremio, range.Cells[l, 11].Value2);
            //    //dadosAgroEquipamentos.Equipamento = ValidarValor(dadosAgroEquipamentos.Equipamento ,range.Cells[l, 12].Value2);
            //    //dadosAgroEquipamentos.Financiado = ValidarValor(dadosAgroEquipamentos.Financiado, range.Cells[l, 13].Value2);
            //    //dadosAgroEquipamentos.Ano = ValidarValor(dadosAgroEquipamentos.Ano,range.Cells[l, 14].Value2);
            //    //dadosAgroEquipamentos.Chassi = ValidarValor(dadosAgroEquipamentos.Chassi, range.Cells[l, 15].Value2);
            //    //dadosAgroEquipamentos.Fabricante =ValidarValor(dadosAgroEquipamentos.Fabricante ,range.Cells[l, 16].Value2);
            //    //dadosAgroEquipamentos.Modelo = ValidarValor(dadosAgroEquipamentos.Modelo, range.Cells[l, 17].Value2);
            //    //dadosAgroEquipamentos.NumeroMotor = ValidarValor(dadosAgroEquipamentos.NumeroMotor, range.Cells[l, 18].Value2);
            //    //dadosAgroEquipamentos.NotaFiscal = ValidarValor(dadosAgroEquipamentos.NotaFiscal, range.Cells[l, 19].Value2);
            //    //dadosAgroEquipamentos.DataSaidaNotaFiscal = ValidarValor(dadosAgroEquipamentos.DataSaidaNotaFiscal,range.Cells[l, 20].Value2);
            //    //dadosAgroEquipamentos.NumeroSerie = ValidarValor(dadosAgroEquipamentos.NumeroSerie, range.Cells[l, 21].Value2);
            //    //dadosAgroEquipamentos.NumeroCep = ValidarValor(dadosAgroEquipamentos.NumeroCep, range.Cells[l, 22].Value2);
            //    //dadosAgroEquipamentos.NumeroLocal = ValidarValor(dadosAgroEquipamentos.NumeroLocal, range.Cells[l, 23].Value2);
            //    //dadosAgroEquipamentos.ValorRisco = ValidarValor(dadosAgroEquipamentos.ValorRisco, range.Cells[l, 24].Value2);
            //    //dadosAgroEquipamentos.Comissao = ValidarValor(dadosAgroEquipamentos.SinistroPremio, range.Cells[l, 25].Value2);
            //    //dadosAgroEquipamentos.Desconto = ValidarValor(dadosAgroEquipamentos.SinistroPremio, range.Cells[l, 26].Value2);
            //    //dadosAgroEquipamentos.Agravo = ValidarValor(dadosAgroEquipamentos.SinistroPremio, range.Cells[l, 27].Value2); 
            //    //dadosAgroEquipamentos.CodigoCoberturaBasica = ValidarValor(dadosAgroEquipamentos.CodigoCoberturaBasica, range.Cells[l, 28].Value2);
            //    //dadosAgroEquipamentos.LmiCoberturaBasica = ValidarValor(dadosAgroEquipamentos.LmiCoberturaBasica, range.Cells[l, 29].Value2);
            //    dadosAgroEquipamentos.lstCoberturasAdicional = new List<CoberturaAdicional>();

            //    for (int c = 30; c <= colunas; c += 2)
            //    {
            //        if (range.Cells[l, c] != null && range.Cells[l, c].Value2 != null)
            //        {
            //            coberturaAdicional = new CoberturaAdicional();
            //            coberturaAdicional.CodigoCoberturaAdicional = Convert.ToInt32(range.Cells[l, c].Value2.ToString());
            //            coberturaAdicional.LmiCoberturaAdicional = Convert.ToDecimal(range.Cells[l, c + 1].Value2.ToString());
            //            dadosAgroEquipamentos.lstCoberturasAdicional.Add(coberturaAdicional);
            //        }
            //    }

            //    lstItemCotacao.Add(dadosAgroEquipamentos);
            //}

            //xlWorkBook.Close();
            //xlApp.Quit();

            //DataTable dt = new DataTable("Planilha");
            //DataRow linha;
            //List<int> lstColunasCoberturaAdicional = new List<int>();
            //dadosAgroEquipamentos = new DadosAgroEquipamentos();
            //PropertyInfo[] propriedades2 = dadosAgroEquipamentos.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //foreach (PropertyInfo propriedade in propriedades2)
            //{
            //    if (propriedade.PropertyType.IsPrimitive ||
            //        propriedade.PropertyType.Name == "String" ||
            //        propriedade.PropertyType.Name == "DateTime" ||
            //        propriedade.PropertyType.Name == "Decimal")
            //    {
            //        dt.Columns.Add(propriedade.Name);
            //    }
            //}

            //foreach (DadosAgroEquipamentos itemCotacao in lstItemCotacao)
            //{
            //    lstColunasCoberturaAdicional.Add(itemCotacao.lstCoberturasAdicional.Count);
            //}

            //int quantidadeColunasCobAdicional = lstColunasCoberturaAdicional.Max();

            //for (int i = 1; i <= quantidadeColunasCobAdicional; i++)
            //{
            //    dt.Columns.Add("Adicional" + i, typeof(int));
            //    dt.Columns.Add("LMI" + i, typeof(decimal));
            //}

            //foreach (DadosAgroEquipamentos itemCotacao in lstItemCotacao)
            //{
            //    PropertyInfo[] prop = itemCotacao.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            //    linha = dt.NewRow();
            //    foreach (PropertyInfo item in prop)
            //    {
            //        if (!item.PropertyType.IsGenericType)
            //        {
            //            if (item.PropertyType.Name == "DateTime")
            //            {
            //                linha[item.Name] = Convert.ToDateTime(item.GetValue(itemCotacao, null)).ToString("dd/MM/yyyy");
            //            }
            //            else
            //            {
            //                linha[item.Name] = item.GetValue(itemCotacao, null);
            //            }

            //        }
            //    }

            //    //linha["DataInicio"] = itemCotacao.DataInicio.ToString("dd/MM/yyyy");
            //    //linha["DataFim"] = itemCotacao.DataFim.ToString("dd/MM/yyyy");
            //    //linha["TipoPessoa"] = itemCotacao.TipoPessoa;
            //    //linha["NumeroCpfCnpj"] = itemCotacao.NumeroCpfCnpj;
            //    //linha["NomeSegurado"] = itemCotacao.NomeSegurado;
            //    //linha["Item"] = itemCotacao.Item;
            //    //linha["TipoSeguro"] = itemCotacao.TipoSeguro;
            //    //linha["ApoliceAnterior"] = itemCotacao.ApoliceAnterior;
            //    //linha["SeguradoAnterior"] = itemCotacao.SeguradoAnterior;
            //    //linha["AnosExperiencia"] = itemCotacao.AnosExperiencia;
            //    //linha["SinistroPremio"] = itemCotacao.SinistroPremio;
            //    //linha["Equipamento"] = itemCotacao.Equipamento;
            //    //linha["Financiado"] = itemCotacao.Financiado;
            //    //linha["Ano"] = itemCotacao.Ano;
            //    //linha["Chassi"] = itemCotacao.Chassi;
            //    //linha["Fabricante"] = itemCotacao.Fabricante;
            //    //linha["Modelo"] = itemCotacao.Modelo;
            //    //linha["NumeroMotor"] = itemCotacao.NumeroMotor;
            //    //linha["NotaFiscal"] = itemCotacao.NotaFiscal;
            //    //linha["DataSaidaNotaFiscal"] = itemCotacao.DataSaidaNotaFiscal.ToString("dd/MM/yyyy");
            //    //linha["NumeroSerie"] = itemCotacao.NumeroSerie;
            //    //linha["NumeroCep"] = itemCotacao.NumeroCep;
            //    //linha["NumeroLocal"] = itemCotacao.NumeroLocal;
            //    //linha["ValorRisco"] = itemCotacao.ValorRisco;
            //    //linha["Comissao"] = itemCotacao.Comissao;
            //    //linha["Desconto"] = itemCotacao.Desconto;
            //    //linha["Agravo"] = itemCotacao.Agravo;
            //    //linha["CodigoCoberturaBasica"] = itemCotacao.CodigoCoberturaBasica;
            //    //linha["LmiCoberturaBasica"] = itemCotacao.LmiCoberturaBasica;

            //    for (int i = 0; i < itemCotacao.lstCoberturasAdicional.Count; i++)
            //    {
            //        linha["Adicional" + (i + 1)] = itemCotacao.lstCoberturasAdicional[i].CodigoCoberturaAdicional;
            //        linha["LMI" + (i + 1)] = itemCotacao.lstCoberturasAdicional[i].LmiCoberturaAdicional;
            //    }

            //    dt.Rows.Add(linha);
            //}
        }


        public DataTable RetornarDados(string arquivo, out string camposErro) 
        {
            Microsoft.Office.Interop.Excel._Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            Microsoft.Office.Interop.Excel.Range range;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(arquivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            int linhas = range.Rows.Count;
            int colunas = range.Columns.Count;
            string valor = string.Empty;

            List<DadosAgroEquipamentos> lstItemCotacao = new List<DadosAgroEquipamentos>();
            DadosAgroEquipamentos dadosAgroEquipamentos = null;
            CoberturaAdicional coberturaAdicional = null;
            int colunasDinamicas = 1;

            for (int l = 2; l <= linhas; l++)
            {
                dadosAgroEquipamentos = new DadosAgroEquipamentos();
                PropertyInfo[] propriedades = dadosAgroEquipamentos.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                for (int c = 0; c < propriedades.Count(); c++)
                {
                    if (!propriedades[c].PropertyType.IsGenericType)
                    {
                        if (propriedades[c].PropertyType.Name == "DateTime")
                        {
                            propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(DateTime.Now, range.Cells[l, c + 1].Value2), null);
                        }
                        else if (propriedades[c].PropertyType.Name == "String")
                        {
                            propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(String.Empty, range.Cells[l, c + 1].Value2), null);
                        }
                        else if (propriedades[c].PropertyType.Name == "Decimal")
                        {
                            propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(Decimal.MinValue, range.Cells[l, c + 1].Value2), null);
                        }
                        else if (propriedades[c].PropertyType.Name == "Int32")
                        {
                            propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(Int32.MinValue, range.Cells[l, c + 1].Value2), null);
                        }
                        else if (propriedades[c].PropertyType.Name == "Long")
                        {
                            propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(long.MinValue, range.Cells[l, c + 1].Value2), null);
                        }
                        else if (propriedades[c].PropertyType.Name == "Double")
                        {
                            propriedades[c].SetValue(dadosAgroEquipamentos, ValidarValor(double.MinValue, range.Cells[l, c + 1].Value2), null);
                        }
                        colunasDinamicas++;
                    }
                }

                dadosAgroEquipamentos.lstCoberturasAdicional = new List<CoberturaAdicional>();

                for (int c = colunasDinamicas; c <= colunas; c += 2)
                {
                    if (range.Cells[l, c] != null && range.Cells[l, c].Value2 != null)
                    {
                        coberturaAdicional = new CoberturaAdicional();
                        coberturaAdicional.CodigoCoberturaAdicional = range.Cells[l, c].Value2.ToString();
                        coberturaAdicional.LmiCoberturaAdicional = range.Cells[l, c + 1].Value2.ToString();
                        dadosAgroEquipamentos.lstCoberturasAdicional.Add(coberturaAdicional);
                    }
                }

                colunasDinamicas = 1;

                lstItemCotacao.Add(dadosAgroEquipamentos);
            }

            xlWorkBook.Close();
            xlApp.Quit();

            DataTable dt = new DataTable("Planilha");
            DataRow linha;
            List<int> lstColunasCoberturaAdicional = new List<int>();
            dadosAgroEquipamentos = new DadosAgroEquipamentos();
            PropertyInfo[] propriedades2 = dadosAgroEquipamentos.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo propriedade in propriedades2)
            {
                if (propriedade.PropertyType.IsPrimitive ||
                    propriedade.PropertyType.Name == "String" ||
                    propriedade.PropertyType.Name == "DateTime" ||
                    propriedade.PropertyType.Name == "Decimal")
                {
                    dt.Columns.Add(propriedade.Name);
                }
            }

            foreach (DadosAgroEquipamentos itemCotacao in lstItemCotacao)
            {
                lstColunasCoberturaAdicional.Add(itemCotacao.lstCoberturasAdicional.Count);
            }

            int quantidadeColunasCobAdicional = lstColunasCoberturaAdicional.Max();

            for (int i = 1; i <= quantidadeColunasCobAdicional; i++)
            {
                dt.Columns.Add("Adicional" + i, typeof(string));
                dt.Columns.Add("LMI" + i, typeof(string));
            }

            foreach (DadosAgroEquipamentos itemCotacao in lstItemCotacao)
            {
                PropertyInfo[] prop = itemCotacao.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                linha = dt.NewRow();
                foreach (PropertyInfo item in prop)
                {
                    if (!item.PropertyType.IsGenericType)
                    {
                        if (item.PropertyType.Name == "DateTime")
                        {
                            linha[item.Name] = Convert.ToDateTime(item.GetValue(itemCotacao, null)).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            linha[item.Name] = item.GetValue(itemCotacao, null);
                        }

                    }
                }

                for (int i = 0; i < itemCotacao.lstCoberturasAdicional.Count; i++)
                {
                    linha["Adicional" + (i + 1)] = itemCotacao.lstCoberturasAdicional[i].CodigoCoberturaAdicional;
                    linha["LMI" + (i + 1)] = itemCotacao.lstCoberturasAdicional[i].LmiCoberturaAdicional;
                }

                dt.Rows.Add(linha);
            }
            StringBuilder erroCampos = new StringBuilder();

            //Validando campos obrigatórios da planinha ou se valores estão de acordo
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //Aqui adicionado campos obrigatorios
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["Produto"].ToString(), "|", (i + 1), "|", "Produto"), int.MinValue));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["DataInicio"].ToString(), "|", (i + 1), "|", "DataInicio"), DateTime.Now));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["DataFim"].ToString(), "|", (i + 1), "|", "DataFim"), DateTime.Now));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["TipoPessoa"].ToString(), "|", (i + 1), "|", "TipoPessoa"),string.Empty));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["NumeroCpfCnpj"].ToString(), "|", (i + 1), "|", "NumeroCpfCnpj"), long.MinValue));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["NomeSegurado"].ToString(), "|", (i + 1), "|", "NomeSegurado"), string.Empty));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["Item"].ToString(), "|", (i + 1), "|", "Item"), int.MinValue));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["TipoSeguro"].ToString(), "|", (i + 1), "|", "TipoSeguro"),string.Empty));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["Equipamento"].ToString(), "|", (i + 1), "|", "Equipamento"), int.MinValue));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["ZeroKm"].ToString(), "|", (i + 1), "|", "ZeroKm"), string.Empty));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["Financiado"].ToString(), "|", (i + 1), "|", "Financiado"), string.Empty));

                if (string.IsNullOrEmpty(ValidarCampos(string.Concat(dt.Rows[i]["Produto"].ToString(), "|", (i + 1), "|", "Produto"), int.MinValue))) 
                {
                    if (dt.Rows[i]["Produto"].ToString() == "7187") 
                    {
                        erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["PerguntaFinanciadoLeasing"].ToString(), "|", (i + 1), "|", "PerguntaFinanciadoLeasing"), string.Empty));
                        erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["PerguntaPodeSerLocadoEventualmente"].ToString(), "|", (i + 1), "|", "PerguntaPodeSerLocadoEventualmente"), string.Empty));
                        erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["PerguntaEquipamentoUtilizadoEmpreitada"].ToString(), "|", (i + 1), "|", "PerguntaEquipamentoUtilizadoEmpreitada"), string.Empty));
                    }
                }

                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["Ano"].ToString(), "|", (i + 1), "|", "Ano"), int.MinValue));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["NumeroCep"].ToString(), "|", (i + 1), "|", "NumeroCep"), string.Empty, true));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["NumeroLocal"].ToString(), "|", (i + 1), "|", "NumeroLocal"), string.Empty));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["ValorRisco"].ToString(), "|", (i + 1), "|", "ValorRisco"), decimal.MinValue));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["Comissao"].ToString(), "|", (i + 1), "|", "Comissao"), double.MinValue));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["CodigoCoberturaBasica"].ToString(), "|", (i + 1), "|", "CodigoCoberturaBasica"), int.MinValue));
                erroCampos.AppendLine(ValidarCampos(string.Concat(dt.Rows[i]["LmiCoberturaBasica"].ToString(), "|", (i + 1), "|", "LmiCoberturaBasica"), decimal.MinValue));

                DataRow row = dt.Rows[i];
                int contadorCoberburasAdicional = 1;
                int qtdColunasAdicional = row.Table.Columns.Count - 20;
                for (int j = 21; j < qtdColunasAdicional; j+=2)
                {
                    string cobeAdicional = row["Adicional" + contadorCoberburasAdicional].ToString();
                    string lmiAdicional = row["LMI"+ contadorCoberburasAdicional].ToString();
                    if (!string.IsNullOrEmpty(cobeAdicional) && !string.IsNullOrEmpty(lmiAdicional)) 
                    {
                        erroCampos.AppendLine(ValidarCampos(string.Concat(cobeAdicional, "|", (i + 1), "|", "Adicional" + contadorCoberburasAdicional), int.MinValue));
                        erroCampos.AppendLine(ValidarCampos(string.Concat(lmiAdicional, "|", (i + 1), "|", "LMI" + contadorCoberburasAdicional), decimal.MinValue)); 
                    }
                    contadorCoberburasAdicional++;
                }
            }
            camposErro = erroCampos.ToString();
            return dt;
        }


        public string ValidarCampos(string campo, DateTime tipoCampo) 
        {
            string mensagem = string.Empty;
            string[] campos = campo.Split('|');
            try
            {
                var validacaoData = DateTime.TryParseExact(campos[0],"dd/MM/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None, out tipoCampo);
                if (!validacaoData) 
                {
                    mensagem = MsgDataInvalida(campos);
                }
                if (tipoCampo == DateTime.MinValue) 
                {
                    mensagem = MsgDataInvalida(campos);
                }
            }
            catch (Exception)
            {
                mensagem = MsgCampoInvalido(campos);
            }

            return mensagem;
        }

        public string ValidarCampos(string campo, string tipoCampo) 
        {
            string mensagem = string.Empty;
            string[] campos = campo.Split('|');

            if (string.IsNullOrEmpty(campos[0])) 
            {
                mensagem = MsgCampoObrigatorio(campos);
            }
            return mensagem;
        }

        public string ValidarCampos(string campo, string tipoCampo, bool cep)
        {
            string mensagem = string.Empty;
            string[] campos = campo.Split('|');

            if (cep) 
            {
                if (string.IsNullOrEmpty(campos[0]))
                {
                    mensagem = MsgCampoObrigatorio(campos);
                }
                else 
                {
                    Regex Rgx = new Regex(@"^\d{8}$");

                    if (!Rgx.IsMatch(campos[0])) 
                    {
                        mensagem = MsgCampoInvalido(campos);
                    }
                }
            }
            return mensagem;
        }


        public string ValidarCampos(string campo, int tipoCampo)
        {
            string mensagem = string.Empty;
            string[] campos = campo.Split('|');

            try
            {
                if (string.IsNullOrEmpty(campos[0]))
                {
                    mensagem = MsgCampoObrigatorio(campos);
                }
                else 
                {
                    tipoCampo = Convert.ToInt32(campos[0]);
                    if (tipoCampo == 0) 
                    {
                        mensagem = MsgCampoInvalido(campos);
                    }
                }
            }
            catch (Exception)
            {
                mensagem = MsgCampoInvalido(campos);
            }
            
            return mensagem;
        }

        public string ValidarCampos(string campo, decimal tipoCampo)
        {
            string mensagem = string.Empty;
            string[] campos = campo.Split('|');

            try
            {
                if (string.IsNullOrEmpty(campos[0]))
                {
                    mensagem = MsgCampoObrigatorio(campos);
                }
                else
                {
                    tipoCampo = Convert.ToDecimal(campos[0]);
                    if (tipoCampo == 0)
                    {
                        mensagem = MsgCampoInvalido(campos);
                    }
                }
            }
            catch (Exception)
            {
                mensagem = MsgCampoInvalido(campos);
            }

            return mensagem;
        }

        public string ValidarCampos(string campo, long tipoCampo)
        {
            string mensagem = string.Empty;
            string[] campos = campo.Split('|');

            try
            {
                if (string.IsNullOrEmpty(campos[0]))
                {
                    mensagem = MsgCampoObrigatorio(campos);
                }
                else
                {
                    tipoCampo = Convert.ToInt64(campos[0]);
                    if (tipoCampo == 0)
                    {
                        mensagem = MsgCampoInvalido(campos);
                    }
                }
            }
            catch (Exception)
            {
                mensagem = MsgCampoInvalido(campos);
            }

            return mensagem;
        }

        public string ValidarCampos(string campo, double tipoCampo)
        {
            string mensagem = string.Empty;
            string[] campos = campo.Split('|');

            try
            {
                if (string.IsNullOrEmpty(campos[0]))
                {
                    mensagem = MsgCampoObrigatorio(campos);
                }
                else
                {
                    tipoCampo = Convert.ToDouble(campos[0]);
                    if (tipoCampo == 0)
                    {
                        mensagem = MsgCampoInvalido(campos);
                    }
                }
            }
            catch (Exception)
            {
                mensagem = MsgCampoInvalido(campos);
            }

            return mensagem;
        }

        public string MsgCampoObrigatorio(string[] campos) 
        {
            return string.Format("<p><strong>Campo obrigatório não preenchido.</strong> Linha <strong>{0}</strong> e Coluna <strong>{1}</strong></p>", campos[1], campos[2]);
        }

        public string MsgCampoInvalido(string[] campos)
        {
            return string.Format("<p><strong>Campo inválido.</strong> Linha <strong>{0}</strong> Coluna <strong>{1}</strong></p>", campos[1], campos[2]);
        }

        public string MsgDataInvalida(string[] campos) 
        {
            return string.Format("<p><strong>Data Inválida.</strong> Ex formato na planinha: 10.10.2019 Linha <strong>{0}</strong> Coluna <strong>{1}</strong></p>", campos[1], campos[2]);
        }

        public static int ValidarValor(int propriedadem, dynamic objeto)
        {
            int i_valor = 0;
            if (objeto != null) int.TryParse(objeto.ToString(), out i_valor);
            return i_valor;
        }

        public static long ValidarValor(long propriedade, dynamic objeto)
        {
            long l_valor = 0;
            if (objeto != null) long.TryParse(objeto.ToString(), out l_valor);
            return l_valor;
        }

        public static string ValidarValor(string propriedade, dynamic objeto)
        {
            return objeto != null ? objeto.ToString() : string.Empty;
        }

        public static DateTime ValidarValor(DateTime propriedade, dynamic objeto)
        {
            DateTime d_valor = DateTime.MinValue;
            if (objeto != null) DateTime.TryParse(objeto.ToString().Replace(".", "/"), out d_valor);
            return d_valor;
        }

        public static decimal ValidarValor(decimal propriedade, dynamic objeto)
        {
            Decimal d_valor = 0;
            if (objeto != null) Decimal.TryParse(objeto.ToString(), out d_valor);
            return d_valor;
        }

        public static double ValidarValor(double propriedade, dynamic objeto)
        {
            double d_valor = 0;
            if (objeto != null) Double.TryParse(objeto.ToString(), out d_valor);
            return d_valor;
        }
    }
}