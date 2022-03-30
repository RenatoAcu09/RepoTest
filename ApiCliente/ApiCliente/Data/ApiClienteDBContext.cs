using ApiCliente.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCliente.Data
{
    public class ApiClienteDBContext:DbContext
    {
        public DbSet<Cliente>  Clientes ;

        public ApiClienteDBContext(DbContextOptions<ApiClienteDBContext> options) : base(options)
        {

        }

        public DbSet<ApiCliente.Models.Cliente> Cliente { get; set; }

    }
}
