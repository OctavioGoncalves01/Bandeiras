using PaisesEBandeiras.Models;

namespace PaisesEBandeiras.Services.PaisesServices
{
    public interface IPaisesService
    {

        Task<List<PaisesModel>> BuscarTodosPaises();
        Task<List<PaisesModelDetalhes>> BuscarPaisEspecifico(string nome);
        Task<List<PaisesModel>> BuscarPorContinente(string continenteNome);
        
    }
}