using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models.HotelModels
{
    [Table("Hotels")]
    public class Hotel
    {
        public int Id { get; set; }
        public double ValorDiaria { get; set; }
        public string NomeHotel { get; set; }
        public List<Quarto> Quarto { get; set; }
        public Regiao Regiao { get; set; }
    }
    public class Quarto
    {
        public int Id { get; set; }
        public int NumeroQuarto { get; set; }
        public TipoQuarto Tipo { get; set; }
        public StatusEnum StatusQuarto { get; set; }
        public List<Reserva> Reserva { get; set; }
    }

    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public ReservaEnum StatusReserva { get; set; }
    }
}
