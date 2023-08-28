using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models.HotelModels
{
    [Table("Hotels")]
    public class Hotel
    {
        public int Id { get; set; }
        public string NomeHotel { get; set; }
        public Regiao Regiao { get; set; }
        public Guid SenhaHotel { get; set; }
        public List<Quarto> Quartos { get; set; }
    }

    [Table("Quartos")]
    public class Quarto
    {
        public int Id { get; set; }
        public Guid HotelKey { get; set; }
        public int NumeroQuarto { get; set; }
        public double ValorDiaria { get; set; }
        public TipoQuarto Tipo { get; set; }
        public StatusEnum StatusQuarto { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
    
    [Table("Reservas")]
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public ReservaEnum StatusReserva { get; set; }
    }
}
