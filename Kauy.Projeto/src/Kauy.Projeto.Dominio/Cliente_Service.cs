using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Kauy.Projeto.Dominio
{
    public class Cliente_Service
    {
        private IClienteRepository clienteRepository;

        public Cliente_Service(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Cliente Adicionar (Cliente cliente)
        {
            cliente.Validar();

            List<Cliente> clientesExiste = clienteRepository.ObterPorCPFCNPJ(cliente.CPFCNPJ);

            if (clientesExiste.Any())
            {
                throw new ArgumentException("Cliente já existente");
            }

            clienteRepository.Adicionar(cliente);
            clienteRepository.Salvar();
            return cliente;
        }
        public Cliente Editar(Cliente cliente)
        {
            cliente.Validar();
            clienteRepository.Editar(cliente);
            clienteRepository.Salvar();

            return cliente;
        }
        public Cliente Apagar(Cliente cliente)
        {
           // cliente.Validar();
            cliente.AlterarParaExcluido();
            clienteRepository.Editar(cliente);
            clienteRepository.Salvar();
            return cliente;
        }
        public List<Cliente> ObterTodos()
        {
            return clienteRepository.ObterTodos();
        }
        public List<Cliente> ObterPorCPFCNPJ(string cpfcnpj)
        {
            return clienteRepository.ObterPorCPFCNPJ(cpfcnpj);
        }
        public List<Cliente> ObterPorNomeeCPFCNPJ(string cpfcnpj,string nome)
        {
            if (!string.IsNullOrEmpty(cpfcnpj)  && !string.IsNullOrEmpty(nome))
            {
                return clienteRepository.ObterPorNomeCPFCNPJ(nome, cpfcnpj);
            }
            if (!string.IsNullOrEmpty(cpfcnpj))
            {
                return clienteRepository.ObterPorCPFCNPJ(cpfcnpj);
            }
            if (!string.IsNullOrEmpty(nome))
            {
                return clienteRepository.ObterPorNome(nome);
            }
            return clienteRepository.ObterTodos();
        }
        public Cliente ObterPorId(int id)
        {
            return clienteRepository.ObterPorId(id);
        }
    }
}
