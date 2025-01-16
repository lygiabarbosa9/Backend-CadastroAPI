using CadastroAPI.Models;

namespace CadastroAPI;

public interface ICadastroService
{
    public double CalcularValorTotal(CadastroRequest request);
    public string ConsultarNomePorId(int id);
}