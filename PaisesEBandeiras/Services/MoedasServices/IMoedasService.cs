using PaisesEBandeiras.Models;

namespace PaisesEBandeiras.Services.MoedasServices
{
    public interface IMoedasService
    {
        Task<MoedasModel> BuscarCambioEspecifico(string nome);
    }
}