using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Epo.Calculo.Web
{
    public partial class Perguntas : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlResposta_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (hdnIDPergunta.Value)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
            }
        }
    }
}