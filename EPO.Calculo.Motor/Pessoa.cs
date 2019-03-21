using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPO.Calculo.Motor
{
    public class Pessoa
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public List<Filme> lstFilme { get; set; }
        public Filme Filme { get; set; }
    }
}
