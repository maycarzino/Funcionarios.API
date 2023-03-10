using Funcionarios.API.Data;
using Funcionarios.API.Models;
using Funcionarios.API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Funcionarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionario _funcionarioRepositorio;
        public FuncionarioController(IFuncionario funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<FuncionarioModel>>> ListarFuncionarios()
        {
            List<FuncionarioModel> funcionarios = await _funcionarioRepositorio.ListarFuncionarios();
            return Ok(funcionarios);
        }
        [HttpGet("{cdMatricula}")]
        public async Task<ActionResult<FuncionarioModel>> ListarFuncionariosMatricula(int cdMatricula)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.ListarFuncionariosMatricula(cdMatricula);

            return funcionario == null ? NotFound() : Ok(funcionario);

        }
        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> CadastrarFuncionario([FromBody] FuncionarioModel funcionarioModel)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            FuncionarioModel funcionario = await _funcionarioRepositorio.CadastrarFuncionario(funcionarioModel);
            return Ok(funcionario);
        }
        [HttpPut("{cdMatricula}")]
        public async Task<ActionResult<FuncionarioModel>> AtualizarFuncionario([FromBody] FuncionarioModel funcionarioModel, int cdMatricula)
        {
            funcionarioModel.cdMatricula = cdMatricula;
            FuncionarioModel funcionario = await _funcionarioRepositorio.AtualizarFuncionario(funcionarioModel, cdMatricula);

            return Ok(funcionario);

        }

        [HttpDelete("{cdMatricula}")]
        public async Task<ActionResult> DeletarFuncionario(int cdMatricula)
        {
            bool delete = await _funcionarioRepositorio.DeletarFuncionario(cdMatricula);

            return Ok(delete);
        }

        //funcionarios?unidade={nome_unidade}
        [HttpGet("{unidade}")]
        public ActionResult<IEnumerable<FuncionarioModel>> ListarPorUnidade([FromQuery] string unidade)
        {
            var funcionarios = _funcionarioRepositorio.ListarPorUnidade(unidade);
            if (!funcionarios.Any())
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }

        //funcionarios?data_inicio={data_inicio}
        [HttpGet]
        public ActionResult<IEnumerable<FuncionarioModel>> ListarPorData([FromQuery] DateTime data_inicio)
        {
            var funcionarios = _funcionarioRepositorio.ListarPorData(data_inicio);
            if (!funcionarios.Any())
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }

        //funcionarios?funcao={codigo_funcao}
        [HttpGet]
        public ActionResult<IEnumerable<FuncionarioModel>> ListarPorFuncao([FromQuery] int codigo_funcao)
        {
            var funcionarios = _funcionarioRepositorio.ListarPorFuncao(codigo_funcao);
            if (!funcionarios.Any())
            {
                return NotFound();
            }

            return Ok(funcionarios);
        }
    
    }
}

