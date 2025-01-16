using CadastroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAPI
{
    [ApiController]
    [Route("api/[controller]")]    
    
    public class CadastroController : ControllerBase
    {
       private readonly ICadastroService _cadastroService;

       public CadastroController(ICadastroService cadastroService)
       {
           _cadastroService = cadastroService;
       }

       [HttpPost("buscar-valor-total")]
       public IActionResult CalcularValorTotal([FromBody] CadastroRequest request)
       {
           if (request.Parcelas <= 0 || request.Valor <= 0)
               throw new Exception("Parcelas e valor devem ser maiores que zero.");
           
           var response = _cadastroService.CalcularValorTotal(request);
           return Ok(new { Total = response });
       }
       
       [HttpGet("busca-por-id/{id}")]
       public IActionResult Consultar(int id)
       {
           var nome = _cadastroService.ConsultarNomePorId(id);

           if (string.IsNullOrEmpty(nome))
               throw new Exception("Id não encontrado");

           return Ok(new { Nome = nome });
       }
    }
}