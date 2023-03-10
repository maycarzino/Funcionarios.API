using Funcionarios.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Funcionarios.API.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<FuncionarioModel>
    {
        public void Configure(EntityTypeBuilder<FuncionarioModel> builder)
        {
            builder.HasKey(x => x.cdMatricula);
            builder.Property(x => x.dsNome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.dsFuncao).IsRequired().HasMaxLength(200);
            builder.Property(x => x.cdFuncao).IsRequired().HasMaxLength(8);
            builder.Property(x => x.dtInicio).HasMaxLength(200);
            builder.Property(x => x.UO).IsRequired().HasMaxLength(10);
        }
    }
}
