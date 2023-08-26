using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models.HotelModels
{
    [Table("Reservas")]
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public ReservaEnum StatusReserva { get; set; }
    }

    public enum ReservaEnum
    { 
        Reservado = 0,
        Processando = 1,
        NaoReservado = 2
    }

}
