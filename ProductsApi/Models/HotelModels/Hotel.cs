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

    public enum Regiao
    {
        Sul,
        Norte,
        Leste
    }
}
