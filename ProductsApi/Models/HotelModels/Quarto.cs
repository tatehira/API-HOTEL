using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models.HotelModels
{
    [Table("Quartos")]
    public class Quarto
    {
        public int Id { get; set; }
        public int NumeroQuarto { get; set; }
        public TipoQuarto Tipo { get; set; }
        public StatusEnum StatusQuarto { get; set; }
        public List<Reserva> Reserva { get; set; }
    }

    public enum TipoQuarto
    {
        Standart = 0,
        Deluxe = 1,
        SuitePresidencial = 2
    }
    
    public enum StatusEnum
    {
        Disponivel = 0,
        Ocupado = 1,
        Manutencao = 2
    }
}
