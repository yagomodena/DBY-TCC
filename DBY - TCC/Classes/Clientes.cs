using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBY___TCC.Classes
{
    public  class Clientes
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string TelefoneResidencial { get; set; }
        public string TelefoneCelular { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Referencia { get; set; }
        public string Numero { get; set; }

        public Clientes(string nome, string cPF, DateTime dataNascimento, string sexo, string telefoneResidencial, string telefoneCelular, string email, string cEP, string rua, string bairro, string complemento, string cidade, string uF, string referencia, string numero)
        {
            Nome = nome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            TelefoneResidencial = telefoneResidencial;
            TelefoneCelular = telefoneCelular;
            Email = email;
            CEP = cEP;
            Rua = rua;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            UF = uF;
            Referencia = referencia;
            Numero = numero;
        }
    }
}
