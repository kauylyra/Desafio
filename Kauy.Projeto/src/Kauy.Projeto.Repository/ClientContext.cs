using Kauy.Projeto.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kauy.Projeto.Repository
{
    public class ClienteContext : DbContext
    {
        public ClienteContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
              .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Configurations.Add(new ClienteConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
           

            return base.SaveChanges();
        }
    }
}

