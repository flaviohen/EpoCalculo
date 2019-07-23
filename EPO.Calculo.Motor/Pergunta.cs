using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPO.Calculo.Motor
{
    public class Pergunta
    {
        public int IdPergunta { get; set; }
        public string DescricaoPergunta { get; set; }
        public List<Resposta> lstReposta { get; set; }
    }
}
