using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kauy.Projeto.Web.Models
{
    public class ClienteViewModel
    {
		[Display(Name = "ID do Cliente")]
		public int IdCliente { get; set; }
		[Required]
		[StringLength(150, MinimumLength = 2)]
		public string Nome { get; set; }
		[Required]
		public byte Tipo { get; set; }
		[Display(Name = "CPF/CNPJ")]
		[Required]
		public string CPFCNPJ { get; set; }
		[Required]
		[StringLength(2, MinimumLength = 2)]
		public string DDD { get; set; }
		[Required]
		[StringLength(9, MinimumLength = 8)]
		public string Fone { get; set; }
		[Display(Name = "Data de Criação")]
		[Required]
		public DateTime DataCriacao { get; set; }
	}
}

