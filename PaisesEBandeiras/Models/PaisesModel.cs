namespace PaisesEBandeiras.Models
{
    public class PaisesModel
    {
        public string? NomePais { get; set; }
        public string? NomeCapital { get; set; }
        public string? Bandeira { get; set; }
        public string? Area { get; set; }
        public int? Populacao { get; set; }
    }

    public class PaisesModelDetalhes{
        public string? NomePais { get; set; }
        public string? NomeCapital { get; set; }
        public string? Area { get; set; }
        public string? Bandeira { get; set; }
        public int? Populacao { get; set; }
        public string? Regiao { get; set; }
        public string? SubRegiao { get; set; }
        public string? Moeda { get; set; }
        public List<string>? Linguas { get; set; } 
      

    }
}