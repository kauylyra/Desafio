using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kauy.Projeto.Dominio
{
    public struct CPF_CNPJ
    {
        private readonly string _value;

        private CPF_CNPJ(string value) { _value = value; }

        public static CPF_CNPJ Parse(string value)
        {
            if (TryParse(value, out var result))
            {
                return result;
            }
            throw new ArgumentException("CPF ou CNPJ inválido!");
        }

        public static bool TryParse(string value, out CPF_CNPJ cpfcnpj)
        {
            string dadosValidar = value?.Trim();
            dadosValidar = dadosValidar.Replace(".", "").Replace("-", "").Replace("/", "");

            bool ok = false;
            ok = CpfValido(dadosValidar);


            if (ok)
            {
                cpfcnpj = new CPF_CNPJ(dadosValidar.PadLeft(11, '0'));
                return ok;
            }

            ok = CnpjValido(dadosValidar);
            if (!ok)
            {
                cpfcnpj = new CPF_CNPJ(dadosValidar);
                return ok;
            }

            cpfcnpj = new CPF_CNPJ(dadosValidar.PadLeft(14, '0'));
            return ok;

        }


        public static string ToStringFormater(int tipo, string valor)
        {
            valor = valor?.Trim();
            valor = valor.Replace(".", "").Replace("-", "").Replace("/", "");
            if (tipo == 0)
            {
                valor = string.Format("{0:D11}", Int64.Parse(valor));

                return string.Format("{0}.{1}.{2}-{3}", valor.Substring(0, 3), valor.Substring(3, 3), valor.Substring(6, 3), valor.Substring(9, 2));
            }
            else
            {
                valor = string.Format("{0:D14}", Int64.Parse(valor));

                return string.Format("{0}.{1}.{2}/{3}-{4}", valor.Substring(0, 2), valor.Substring(2, 3), valor.Substring(5, 3), valor.Substring(8, 4), valor.Substring(12, 2));
            }
        }

        private static bool CpfValido(string valor)
        {
            string cpf = valor;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private static bool CnpjValido(string valor)
        {
            string cnpj = valor;
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }


        public static implicit operator CPF_CNPJ(string value)
          => Parse(value);
    }
}
