using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Models.HotelModels
{
    [Table("Hotels")]
    public class Hotel
    {
        public int Id { get; set; }
        public string NomeHotel { get; set; }
        public Quarto Quarto { get; set; }
        public Regiao Regiao { get; set; }
    }

    public enum Regiao
    {
        Sul,
        Norte,
        Leste
    }
}
