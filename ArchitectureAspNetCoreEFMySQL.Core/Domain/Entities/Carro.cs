namespace ArchitectureAspNetCoreEFMySQL.Core.Domain.Entities
{
    public class Carro
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string AnoModelo { get; set; }
        public string AnoFabricacao { get; set; }
    }
}
