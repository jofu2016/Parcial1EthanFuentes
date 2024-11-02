using Microsoft.EntityFrameworkCore;
using primerparcial.Models;

namespace primerparcial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DireccionCliente> DireccionesClientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<ReseñaCliente> ReseñasClientes { get; set; }
        public DbSet<MetodoPagoCliente> MetodosPagoClientes { get; set; }
        public DbSet<TipoPago> TiposPago { get; set; }
        public DbSet<CarritoCompras> CarritosCompras { get; set; }
        public DbSet<ItemCarritoCompras> ItemsCarritoCompras { get; set; }
        public DbSet<Promocion> Promociones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=JOFULINK\SQLEXPRESS;Database=MiTiendaUnClickDB;Trusted_Connection=True;");
            }
        }
    }
}
    