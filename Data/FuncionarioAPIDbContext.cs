using Funcionarios.API.Data.Map;
using Funcionarios.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Funcionarios.API.Data
{
    public class FuncionarioAPIDbContext : DbContext
    {
        public FuncionarioAPIDbContext(DbContextOptions<FuncionarioAPIDbContext> options) : base(options)
        {

        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}


