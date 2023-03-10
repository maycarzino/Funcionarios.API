using Funcionarios.API.Data;
using Funcionarios.API.Models;
using Funcionarios.API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Funcionarios.API.Repositorios
{
    public class FuncionarioRepositorio : IFuncionario
    {
        private readonly FuncionarioAPIDbContext _dbContext;
        public FuncionarioRepositorio(FuncionarioAPIDbContext funcAPIDbContext)
        {
            _dbContext = funcAPIDbContext;
        }
        public async Task<FuncionarioModel> ListarFuncionariosMatricula(int cdMatricula)
        {
            return await _dbContext.Funcionarios.FirstOrDefaultAsync(x => x.cdMatricula == cdMatricula);
        }
        public async Task<List<FuncionarioModel>> ListarFuncionarios()
        {
            return await _dbContext.Funcionarios.ToListAsync();
        }

        public async Task<FuncionarioModel> CadastrarFuncionario(FuncionarioModel funcionario)
        {

            await _dbContext.Funcionarios.AddAsync(funcionario);
            _dbContext.SaveChanges();
            return funcionario;

        }
        public async Task<FuncionarioModel> AtualizarFuncionario(FuncionarioModel funcionario, int cdMatricula)
        {
            FuncionarioModel funcMatricula = await ListarFuncionariosMatricula(cdMatricula);

            if (funcMatricula == null)
            {
                throw new Exception($"Funcionário com a matrícula:{cdMatricula} não foi encontrado");
            }

            funcMatricula.cdMatricula = cdMatricula;
            funcMatricula.dsNome = funcionario.dsNome;
            funcMatricula.dsFuncao = funcionario.dsFuncao;
            funcMatricula.cdFuncao = funcionario.cdFuncao;
            funcMatricula.UO = funcionario.UO;

            _dbContext.Funcionarios.Update(funcMatricula);
            await _dbContext.SaveChangesAsync();

            return funcMatricula;
        }

        public async Task<bool> DeletarFuncionario(int cdMatricula)
        {
            FuncionarioModel funcMatricula = await ListarFuncionariosMatricula(cdMatricula);

            if (funcMatricula == null)
            {
                throw new Exception($"Funcionário com a matrícula:{cdMatricula} não foi encontrado");
            }

            _dbContext.Funcionarios.Remove(funcMatricula);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public IEnumerable<FuncionarioModel> ListarPorUnidade(string UO)
        {
            return _dbContext.Funcionarios.Where(x => x.UO == UO);
        }

        public IEnumerable<FuncionarioModel> ListarPorData(DateTime dtInicio)
        {
            return _dbContext.Funcionarios.Where(x => x.dtInicio == dtInicio);
        }

        public IEnumerable<FuncionarioModel> ListarPorFuncao(int cdFuncao)
        {
            return _dbContext.Funcionarios.Where(x => x.cdFuncao == cdFuncao);
        }
    }
}
