using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPO.Calculo.Motor
{
    public class EpoCalculo
    {
        public float qtdIncentivar { get; set; }
        public float qtdNaoIncentivar { get; set; }
        public float somaIncentivarENaoIncentivar { get; set; }
        public float percentualIncentivar { get; set; }
        public float percentualNaoIncentivar { get; set; }
        private const float limitePercentual = 5000;

        public EpoCalculo() 
        {
            qtdIncentivar = limitePercentual;
            qtdNaoIncentivar = 0;
        }

        public EpoCalculo Calcular(EpoCalculo epoca) 
        {
            epoca.percentualIncentivar = ((epoca.qtdIncentivar * 1) / limitePercentual) * 100;
            epoca.percentualNaoIncentivar = ((epoca.qtdNaoIncentivar * 1) / limitePercentual) * 100;

            return epoca;
        }

        public void Incentivar(ref EpoCalculo epoca) 
        {
            if (epoca.qtdIncentivar != limitePercentual) 
            {
                if (epoca.qtdNaoIncentivar != 0) 
                {
                    epoca.qtdIncentivar = epoca.qtdIncentivar + 1;
                    epoca.qtdNaoIncentivar = epoca.qtdNaoIncentivar - 1;
                    this.Calcular(epoca);
                }
            }
        }

        public void NaoIncentivar(ref EpoCalculo epoca) 
        {
            if (epoca.qtdNaoIncentivar != limitePercentual)
            {
                if (epoca.qtdIncentivar != 0)
                {
                    epoca.qtdIncentivar = epoca.qtdIncentivar - 1;
                    epoca.qtdNaoIncentivar = epoca.qtdNaoIncentivar + 1;
                    this.Calcular(epoca);
                }
            }
        }

    }
}
