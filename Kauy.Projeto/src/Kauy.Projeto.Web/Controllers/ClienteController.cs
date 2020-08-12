using Kauy.Projeto.Dominio;
using Kauy.Projeto.Repository;
using Kauy.Projeto.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kauy.Projeto.Web.Controllers
{
    public class ClienteController : Controller
    {
        private Cliente_Service cliente_Service;
        private ClienteRepository clienteRepository;

        public ClienteController()
        {
            clienteRepository = new ClienteRepository();
            cliente_Service = new Cliente_Service(clienteRepository);
        }
        public ActionResult Index(string cpfcnpj,string nome)
        {
            var clientes = cliente_Service.ObterPorNomeeCPFCNPJ(cpfcnpj, nome);

            var clientesViewModel = clientes.Select(s =>
                new ClienteViewModel
                {
                    IdCliente = s.IdCliente,
                    Nome = s.Nome,
                    CPFCNPJ = s.ObterCPFCNPJFormatado(),
                    Fone = s.Fone,
                    DDD = s.DDD,
                    Tipo = s.Tipo,
                    DataCriacao = s.DataCriacao
                }
                ).ToList();
            return View(clientesViewModel);
        }
        public ActionResult Details(int id)
        {
            var cliente = cliente_Service.ObterPorId(id);
            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                CPFCNPJ = cliente.ObterCPFCNPJFormatado(),
                Fone = cliente.Fone,
                DDD = cliente.DDD,
                Tipo = cliente.Tipo,
                DataCriacao = cliente.DataCriacao
            };
            return View(clienteViewModel);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            try
            {
                var cliente = new Cliente(clienteViewModel.Nome, clienteViewModel.Tipo, clienteViewModel.CPFCNPJ, clienteViewModel.DDD, clienteViewModel.Fone);
                cliente_Service.Adicionar(cliente);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var cliente = cliente_Service.ObterPorId(id);
            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                CPFCNPJ = cliente.ObterCPFCNPJFormatado(),
                Fone = cliente.Fone,
                DDD = cliente.DDD,
                Tipo = cliente.Tipo,
                DataCriacao = cliente.DataCriacao
            };
            return View(clienteViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, ClienteViewModel clienteViewModel)
        {
            try
            {
                var cliente = new Cliente(clienteViewModel.Nome, clienteViewModel.Tipo, clienteViewModel.CPFCNPJ, clienteViewModel.DDD, clienteViewModel.Fone, clienteViewModel.IdCliente, clienteViewModel.DataCriacao);
                cliente_Service.Editar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var cliente = cliente_Service.ObterPorId(id);
            ClienteViewModel clienteViewModel = new ClienteViewModel()
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                CPFCNPJ = cliente.ObterCPFCNPJFormatado(),
                Fone = cliente.Fone,
                DDD = cliente.DDD,
                Tipo = cliente.Tipo,
                DataCriacao = cliente.DataCriacao
            };
            return View(clienteViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, ClienteViewModel clienteViewModel)
        {
            try
            {
                var cliente = cliente_Service.ObterPorId(id);
                cliente_Service.Apagar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }
    }
}
