using Kauy.Projeto.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kauy.Projeto.Repository
{
    class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.IdCliente);
            //HasKey(c => new {c.Id, c.CPF});

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.CPFCNPJ)
                .IsRequired()
                .HasMaxLength(14);

            Property(c => c.Tipo)
                .IsRequired();

            Property(c => c.DDD)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.Fone)
                .IsRequired()
                .HasMaxLength(9);

            Property(c => c.DataCriacao)
                .IsRequired();

            Property(c => c.Excluido)
                .IsRequired();

            ToTable("Cliente");
        }
    }
}

