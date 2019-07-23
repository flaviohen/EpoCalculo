using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPO.Calculo.Motor;

namespace Epo.Calculo.Web
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Pergunta> lstPergunta = new List<Pergunta>();

            for (int i = 0; i < 5; i++)
            {
                Pergunta pergunta = new Pergunta();
                pergunta.IdPergunta = i+1;
                pergunta.DescricaoPergunta = "Pergunta" + (i+1);

                Resposta resposta = new Resposta();
                resposta.IdReposta = i + 1;
                resposta.DescricaoResposta = "SIM";
                pergunta.lstReposta = new List<Resposta>();

                pergunta.lstReposta.Add(resposta);

                Resposta resposta2 = new Resposta();
                resposta2.IdReposta = i + 2;
                resposta2.DescricaoResposta = "NÂO";

                pergunta.lstReposta.Add(resposta2);

                lstPergunta.Add(pergunta);
            }

            foreach (var item in lstPergunta)
            {
                UserControl uc = (UserControl)Page.LoadControl("~/Perguntas.ascx");

                uc.ID = item.IdPergunta.ToString();
                ((HiddenField)uc.FindControl("hdnIDPergunta")).Value = item.IdPergunta.ToString();
                ((Label)uc.FindControl("DescricaoPergunta")).Text = item.DescricaoPergunta;

                ((DropDownList)uc.FindControl("ddlResposta")).DataSource = item.lstReposta;
                ((DropDownList)uc.FindControl("ddlResposta")).DataValueField = "IdReposta";
                ((DropDownList)uc.FindControl("ddlResposta")).DataTextField = "DescricaoResposta";
                ((DropDownList)uc.FindControl("ddlResposta")).DataBind();

                pnlPerguntas.Controls.Add(uc);
            }
        }
    }
}
