using Funcionarios.API.Models;

namespace Funcionarios.API.Repositorios.Interfaces
{
    public interface IFuncionario
    {
        Task<List<FuncionarioModel>> ListarFuncionarios();
        Task<FuncionarioModel> ListarFuncionariosMatricula(int cdMatricula);
        Task<FuncionarioModel> CadastrarFuncionario(FuncionarioModel funcionario);
        Task<FuncionarioModel> AtualizarFuncionario(FuncionarioModel funcionario, int cdMatricula);
        Task<bool> DeletarFuncionario(int cdMatricula);
        IEnumerable<FuncionarioModel> ListarPorUnidade(string UO);
        IEnumerable<FuncionarioModel> ListarPorData(DateTime dtInicio);
        IEnumerable<FuncionarioModel> ListarPorFuncao(int cdFuncao);
    }
}
