using Kauy.Projeto.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kauy.Projeto.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        protected ClienteContext Db;
        protected DbSet<Cliente> DbSet;

        public ClienteRepository()
        {
            Db = new ClienteContext();
            DbSet = Db.Set<Cliente>();
        }

        public Cliente Adicionar(Cliente cliente)
        {
            return DbSet.Add(cliente);
        }

        public void Apagar(Cliente cliente)
        {
            DbSet.Remove(cliente);
        }

        public Cliente Editar(Cliente cliente)
        {
            var entry = Db.Entry(cliente);
            DbSet.Attach(cliente);
            entry.State = EntityState.Modified;
            return cliente;
        }

        public List<Cliente> ObterPorCPFCNPJ(string cpfcnpj)
        {
            return DbSet.Where(w => w.CPFCNPJ == cpfcnpj && !w.Excluido).ToList();
        }

        public Cliente ObterPorId(int id)
        {
            return DbSet.Where(w => w.IdCliente == id).FirstOrDefault();
        }

        public List<Cliente> ObterPorNome(string nome)
        {
            return DbSet.Where(w => w.Nome == nome && !w.Excluido).ToList();
        }

        public List<Cliente> ObterPorNomeCPFCNPJ(string nome, string cpfcnpj)
        {
            return DbSet.Where(w => w.Nome == nome && w.CPFCNPJ == cpfcnpj && !w.Excluido).ToList();
        }

        public List<Cliente> ObterTodos()
        {
            return DbSet.Where(w => !w.Excluido).ToList();

        }

        public void Salvar()
        {
            Db.SaveChanges();
        }
    }
}
