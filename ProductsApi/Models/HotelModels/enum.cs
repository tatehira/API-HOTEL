using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models.HotelModels
{
    public enum ReservaEnum
    {
        Reservado = 0,
        Processando = 1,
        NaoReservado = 2
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


    public enum Regiao
    {
        Sul = 0,
        Norte = 1,
        Leste = 2
    }

}
