using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBY___TCC.Classes
{
    public  class Clientes
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string ClienteFidelidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Referencia { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Situacao { get; set; }
        public int SaldoPontos { get; set; }
        public DateTime DataUltimaCompra { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
