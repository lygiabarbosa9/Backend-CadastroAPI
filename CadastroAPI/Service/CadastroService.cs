using CadastroAPI.Models;

namespace CadastroAPI
{
    public class CadastroService : ICadastroService
    {
        private readonly List<KeyValuePair<int, string>> _lista;
        
        public CadastroService()
        {
            _lista = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(1, "João"),
                new KeyValuePair<int, string>(2, "Maria"),
                new KeyValuePair<int, string>(3, "Ana"),
                new KeyValuePair<int, string>(4, "Pedro")
            };
        }
        
        public double CalcularValorTotal(CadastroRequest request)
        {
            var valor = request.Valor * request.Parcelas;
            var valorPorcentagem = valor * 0.05;
            return valor + valorPorcentagem;
        }

        public string ConsultarNomePorId(int id)
        {
            var result = _lista.FirstOrDefault(x => x.Key == id);
            return result.Equals(default(KeyValuePair<int, string>)) ? null : result.Value;
        }
    }
}