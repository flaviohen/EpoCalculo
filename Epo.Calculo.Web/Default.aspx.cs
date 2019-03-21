using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using EPO.Calculo.Motor;
using System.Text;
using System.Collections;

namespace Epo.Calculo.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            filme.id = @"123346&<""";
            filme.titulo = "Teste><ç";
            filme.nota = 1.2;
            filme.ano = 2008;
            filme.Pessoa = new Pessoa();
            filme.Pessoa.ID = "10";
            filme.Pessoa.Nome = @"Çida <>&""";
            filme.Pessoa.Idade = 80;

            Label1.Text = string.Format("id:{0} - titulo:{1} - nota:{2} - ano:{3}", filme.id, filme.titulo, filme.nota, filme.ano);
            foreach (var item in filme.lstPessoa)
            {
                Label3.Text += string.Format("ID:{0} - Nome:{1} - Idade:{2}", item.ID, item.Nome, item.Idade); 
            }

            Label5.Text = string.Format("ID:{0} - Nome:{1} - Idade:{2}", filme.Pessoa.ID, filme.Pessoa.Nome, filme.Pessoa.Idade);

            TransformarCaracteresHTML(filme);

            Label2.Text = string.Format("id:{0} - titulo:{1} - nota:{2} - ano:{3}", filme.id, filme.titulo, filme.nota, filme.ano);
            foreach (var item in filme.lstPessoa)
            {
                Label4.Text += string.Format("ID:{0} - Nome:{1} - Idade:{2}", item.ID, item.Nome, item.Idade);
            }

            Label6.Text = string.Format("ID:{0} - Nome:{1} - Idade:{2}", filme.Pessoa.ID, filme.Pessoa.Nome, filme.Pessoa.Idade);
        }


        public void TransformarCaracteresHTML(object objeto)
        {
            PropertyInfo[] properties = objeto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo item in properties)
            {
                var value2 = item.GetValue(objeto, null);
                if (item.PropertyType.Name == "String")
                {
                    EncodeCaracteres(item, objeto);
                }
                else
                {
                    if (!item.PropertyType.IsPrimitive && item.PropertyType.IsGenericType)
                    {
                        if (value2 != null)
                        {
                            EncodeRecursive(item, value2);
                        }
                    }
                    else if (!item.PropertyType.IsPrimitive && item.PropertyType.IsClass) 
                    {
                        if (value2 != null) 
                        {
                            TransformarCaracteresHTML(value2);
                        }
                    }
                }
            }
        }

                    
        public void EncodeCaracteres(PropertyInfo propriedades, object objeto)
        {
            string value = propriedades.GetValue(objeto, null).ToString();
            string caracteresSubstituido = HttpUtility.HtmlEncode(value);
            propriedades.SetValue(objeto, caracteresSubstituido, null);
        }

        public void EncodeRecursive(PropertyInfo propriedade, object objeto) 
        {
            if (!propriedade.PropertyType.IsPrimitive && propriedade.PropertyType.IsGenericType)
            {
                if (objeto != null) 
                {
                    Type myType = objeto.GetType();
                    Type listType = typeof(List<>).MakeGenericType(myType);
                    IList myList = (IList)Activator.CreateInstance(listType);
                    myList = (IList)objeto;

                    foreach (var item2 in myList)
                    {
                        PropertyInfo[] propriedades = item2.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                        foreach (PropertyInfo item3 in propriedades)
                        {
                            var value3 = item3.GetValue(item2, null);
                            if (item3.PropertyType.Name == "String")
                            {
                                EncodeCaracteres(item3, item2);
                            }
                            else
                            {
                                if (!item3.PropertyType.IsPrimitive && item3.PropertyType.IsGenericType)
                                {
                                    if (value3 != null) 
                                    {
                                        EncodeRecursive(item3, value3);
                                    } 
                                }
                                else if (!item3.PropertyType.IsPrimitive && item3.PropertyType.IsClass)
                                {
                                    if (value3 != null) 
                                    {
                                        TransformarCaracteresHTML(item2);
                                    }
                                }
                            }
                        }
                    }
                }  
            }
            else if (!propriedade.PropertyType.IsPrimitive && propriedade.PropertyType.IsClass)
            {
                TransformarCaracteresHTML(propriedade);
            }
        }
    }
}
