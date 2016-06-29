namespace OldLot.API.Models
{
    public class VeiculoModel
    {
        public int id { get; protected set; }
        public string nome { get; set; }
        public int ano { get; set; }
        public FabricanteModel Fabricante { get; set; }
        public TipoDeVeiculoModel Tipo { get; set; }
    }
}