using PaisesEBandeiras.Models;

namespace PaisesEBandeiras.Services.ClimaServices
{
    public interface IClimaService
    {
        Task<WeatherModel> BuscaClimaCidadeEspecifica(string nomeCidade);
    }
}