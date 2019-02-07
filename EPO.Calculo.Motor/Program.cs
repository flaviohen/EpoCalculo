using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace EPO.Calculo.Motor
{
    class Program
    {
        static void Main(string[] args)
        {
            //EpoCalculo calculo = new EpoCalculo();
            //new EpoCalculo().Calcular(calculo);

            //Console.WriteLine(string.Format("Percentual Incentivar: {0}%",calculo.percentualIncentivar));
            //Console.WriteLine(string.Format("Percentual Nao Incentivar: {0}%", calculo.percentualNaoIncentivar));

            //for (int i = 0; i < 25; i++)
            //{
            //    new EpoCalculo().NaoIncentivar(ref calculo);
            //}

            //Console.WriteLine(string.Format("Percentual Incentivar: {0}%", calculo.percentualIncentivar));
            //Console.WriteLine(string.Format("Percentual Nao Incentivar: {0}%", calculo.percentualNaoIncentivar));

            //Console.ReadKey();


            var responseValue = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create("https://copadosfilmes.azurewebsites.net/api/filmes");
            request.Method = "GET";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
            }

            DataContractJsonSerializer jsonConvert = new DataContractJsonSerializer(typeof(List<Filme>));
            MemoryStream ms = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(responseValue));
            List<Filme> lstFilme = (List<Filme>)jsonConvert.ReadObject(ms);

            lstFilme = lstFilme.OrderBy(c => c.titulo).ToList();

            foreach (var item in lstFilme.Take(8).ToList())
            {
                Console.WriteLine(string.Concat(item.titulo, " - ", item.ano, " - ", item.nota));
            }

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Copa Filmes Quartas de Final");
            foreach (var item in new Filme().DecidirQuartasDeFinal(lstFilme))
            {
                Console.WriteLine(string.Concat(item.titulo, " - ", item.ano, " - ", item.nota));
            }


            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Copa Filmes Semi Final");
            foreach (var item in new Filme().DecidirSemiFinal(new Filme().DecidirQuartasDeFinal(lstFilme)))
            {
                Console.WriteLine(string.Concat(item.titulo, " - ", item.ano, " - ", item.nota));
            }

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Copa Filmes Final");
            int i = 1;
            foreach (var item in new Filme().DecidirFinal(new Filme().DecidirSemiFinal(new Filme().DecidirQuartasDeFinal(lstFilme))))
            {
                Console.WriteLine(string.Concat(i," º ",item.titulo, " - ", item.ano, " - ", item.nota));
                i++;
            }
            Console.ReadKey();
        }

        
    }
}
