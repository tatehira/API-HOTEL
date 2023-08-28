using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Models.HotelModels;
using System.Linq;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelsContext _context;
        public HotelController(HotelsContext context)
        {
            _context = context;
        }

        [HttpGet("GetHotel/{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            Hotel aHotel = await _context.Hotels.FindAsync(id);

            if (aHotel == null)
                return NotFound("Não foi localizado o hotel informado!");

            return Ok(aHotel);
        }

        [HttpPost("CreateHotel")]
        public async Task<ActionResult> CreateHotel(string nomeHotel, Regiao regiaoHotel)
        {
            Hotel hotel = new Hotel();
            if(hotel == null)
                return BadRequest("O hotel está nulo! Revise os campos.");

            bool IsNumerable = int.TryParse(nomeHotel, out _);
            if (IsNumerable)
                return BadRequest("Digite um nome válido para o hotel!");

            hotel.NomeHotel = nomeHotel;
            hotel.Regiao = regiaoHotel;
            hotel.SenhaHotel = Guid.NewGuid();
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();

            return Ok($"Hotel cadastrado! Salve a senha para adicionar futuros quartos: {hotel.SenhaHotel}");
        }

        [HttpPost("CreateQuartos")]
        public async Task<ActionResult> CreateQuarto(Quarto quarto, Guid key)
        {
            quarto.HotelKey = key;

            List<Hotel> HotelKey = _context.Hotels.Where(k => k.SenhaHotel == key).ToList();

            if(HotelKey == null)
                return BadRequest("Não foi localizado hotel com essa chave!");


            if (quarto.NumeroQuarto < 0)
                return BadRequest("O número do quarto não pode ser negativo!");

            await _context.Quartos.AddAsync(quarto);

            await _context.SaveChangesAsync();

            return Ok("Hotel criado com sucesso! \n" + HotelKey);
        }

        [HttpPut("UpdateHotel")]
        public async Task<ActionResult> UpdateHotel(Hotel hotel)
        {
            var dbHotel = await _context.Hotels.FindAsync(hotel.Id);

            if (dbHotel == null)
                return NotFound();

            dbHotel.Adapt(hotel);

            await _context.SaveChangesAsync();

            return Ok(hotel);
        }

        [HttpDelete("DeleteHotel")]
        public async Task<ActionResult> DeleteHotel(string nome)
        {
            var dbHotel = await _context.Hotels.Where(i => i.NomeHotel == nome).FirstOrDefaultAsync();

            if (dbHotel == null)
                return BadRequest("Não há Hotel com Id informado! ");

            var dbQuarto = await _context.Quartos.Where(q => q.Id == dbHotel.Id).FirstOrDefaultAsync();
            var dbReserva = await _context.Reservas.Where(r => r.Id == dbHotel.Id).FirstOrDefaultAsync();

            try
            {
                _context.Hotels.Remove(dbHotel);
                _context.Quartos.Remove(dbQuarto);
                _context.Reservas.Remove(dbReserva);

                await _context.SaveChangesAsync();

                return Ok("Hotel removido com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest("Não foi possível remover do sistema!");
            }
        }


        [HttpGet("GetRegion")]
        public ActionResult<Hotel> GetRegion(Regiao regiao)
        {
            try
            {
                var aHotel = _context.Hotels.Where(r => r.Regiao == regiao).ToList();

                List<Hotel> hotelInsert = new List<Hotel>();

                foreach (var a in aHotel)
                {
                    a.Quartos = _context.Quartos.Where(i => i.Id == a.Id).ToList();
                    hotelInsert.Add(a);
                }

                return Ok(hotelInsert);
            }

            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro na busca de acordo com a região!");
            }

        }
    }
}
