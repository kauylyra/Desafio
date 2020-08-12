using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kauy.Projeto.Dominio
{
    public interface IClienteRepository
    {
        Cliente Adicionar(Cliente cliente);
        Cliente Editar(Cliente cliente);
        void Apagar(Cliente cliente);
        List<Cliente> ObterTodos();
        List<Cliente> ObterPorCPFCNPJ(string cpfcnpj);
        Cliente ObterPorId(int id);
        List<Cliente> ObterPorNome(string nome);
        List<Cliente> ObterPorNomeCPFCNPJ(string nome,string cpfcnpj);
        void Salvar();

    }
}
