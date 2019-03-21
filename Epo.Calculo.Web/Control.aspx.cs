using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Epo.Calculo.Web
{
    public partial class Control : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FindControlRecursive(this.Page.Master);
        }

        public static void RemoverCaracteresTexto(TextBox controle)
        {
            if (controle.Text.Contains("&"))
            {
                controle.Text = controle.Text.Replace("&", "E");
            }
            if (controle.Text.Contains("&amp;") || controle.Text.Contains("Eamp;"))
            {
                controle.Text = controle.Text.Replace("&amp;", "");
                controle.Text = controle.Text.Replace("Eamp;", "");
            }
        }

        public static void FindControlRecursive(System.Web.UI.Control Root)
        {
            if (Root.GetType() == typeof(TextBox))
            {
                TextBox txt = ((TextBox)Root);
                RemoverCaracteresTexto(txt);
            }

            foreach (System.Web.UI.Control Ctl in Root.Controls)
            {
                FindControlRecursive(Ctl);
            }
        }
    }
}