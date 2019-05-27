using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPO.Calculo.Motor
{
    public class DadosAgroEquipamentos
    {
        public int Produto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string TipoPessoa { get; set; }
        public string NumeroCpfCnpj { get; set; }
        public string NomeSegurado { get; set; }
        public int Item { get; set; }
        public string TipoSeguro { get; set; }
        public string ApoliceAnterior { get; set; }
        public string SeguradoAnterior { get; set; }
        public string AnosExperiencia { get; set; }
        public double SinistroPremio { get; set; }
        public string PerguntaFinanciadoLeasing { get; set; }
        public string PerguntaPodeSerLocadoEventualmente { get; set; }
        public string PerguntaEquipamentoUtilizadoEmpreitada { get; set; }
        public string Financiado { get; set; }
        public int Equipamento { get; set; }
        public string ZeroKm { get; set; }
        public int Ano { get; set; }
        public string Chassi { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string NumeroMotor { get; set; }
        public string NotaFiscal { get; set; }
        public DateTime DataSaidaNotaFiscal { get; set; }
        public string NumeroSerie { get; set; }
        public string NumeroCep { get; set; }
        public string NumeroLocal { get; set; }
        public decimal ValorRisco { get; set; }
        public double Comissao { get; set; }
        public double Desconto { get; set; }
        public double Agravo { get; set; }
        public int CodigoCoberturaBasica { get; set; }
        public decimal LmiCoberturaBasica { get; set; }
        public List<CoberturaAdicional> lstCoberturasAdicional { get; set; }
    }
}
