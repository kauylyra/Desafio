using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kauy.Projeto.Dominio
{
    public class Cliente
    {
        public Cliente()
        {

        }
        public Cliente(string nome, byte tipo, string cPFCNPJ, string dDD, string fone)
        {
            IdCliente = 0;
            Nome = nome;
            Tipo = tipo;
            CPFCNPJ = cPFCNPJ;
            DDD = dDD;
            Fone = fone;
            DataCriacao = DateTime.Now;
            Excluido = false;
        }

        public Cliente(string nome, byte tipo, string cPFCNPJ, string dDD, string fone, int idcliente, DateTime dataCriacao)
        {
            IdCliente = idcliente;
            Nome = nome;
            Tipo = tipo;
            CPFCNPJ = cPFCNPJ;
            DDD = dDD;
            Fone = fone;
            DataCriacao = dataCriacao;
            Excluido = false;

        }
        public int IdCliente { get; private set; }
        public string Nome { get; private set; }
        public byte Tipo { get; private set; }
        public string CPFCNPJ { get; private set; }
        public string DDD { get; private set; }
        public string Fone { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Excluido { get; private set; }

        public void Validar()
        {
            CPF_CNPJ cPF_CNPJ = new CPF_CNPJ();
            if (!CPF_CNPJ.TryParse(CPFCNPJ, out cPF_CNPJ))
            {
                throw new ArgumentException("CPF ou CPNJ invalido");
            }
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentException("Preencha Nome");
            }
            if (string.IsNullOrEmpty(Fone))
            {
                throw new ArgumentException("Preencha Fone");
            }
            if (string.IsNullOrEmpty(DDD))
            {
                throw new ArgumentException("Preencha DDD");
            }
        }

        public string ObterCPFCNPJFormatado()
        {
            return CPF_CNPJ.ToStringFormater(Tipo, CPFCNPJ);
        }

        public void AlterarParaExcluido()
        {
            Excluido = true;
        }
    }
}
