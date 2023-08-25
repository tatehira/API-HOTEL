namespace ProductsApi.Models.HotelModels
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public ReservaEnum StatusReserva { get; set; }
    }

    public enum ReservaEnum
    { 
        Reservado,
        Processando,
        NaoReservado
    }

}
