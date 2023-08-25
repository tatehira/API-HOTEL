namespace ProductsApi.Models.HotelModels
{
    public class Quarto
    {
        public int Id { get; set; }
        public int NumeroQuarto { get; set; }
        public TipoQuarto Tipo { get; set; }
        public Status StatusQuarto { get; set; }
        public List<Reserva> Reserva { get; set; }
    }

    public enum TipoQuarto
    {
        Standart,
        Deluxe,
        SuitePresidencial
    }
    
    public enum Status
    {
        Disponivel,
        Ocupado,
        Manutencao
    }
}
