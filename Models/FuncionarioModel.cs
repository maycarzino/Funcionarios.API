using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Funcionarios.API.Models
{
    public class FuncionarioModel
    {
        
        public int cdMatricula { get; set; }
        
        public string dsNome { get; set; }
        
        public string dsFuncao { get; set; }
       
        public int cdFuncao { get; set; }
        
        public DateTime dtInicio { get; set; }
        
        public string UO { get; set; } 

    }
}
