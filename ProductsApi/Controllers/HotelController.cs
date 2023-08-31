using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Models;
using ProductsApi.Models.HotelModels;
using System.Collections;
using System.Data.SqlTypes;
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
        public async Task<ActionResult<Hotel>> GetHotelId(int id)
        {
            Hotel aHotel = await _context.Hotels.FindAsync(id);

            if (aHotel == null)
                return NotFound("Não foi localizado o hotel informado!");

            List<Hotel> hotel = new List<Hotel>();

            List<Hotel> getHotels = await _context.Hotels.Where(i => i.Id == id).ToListAsync();

            foreach (var model in getHotels)
            {
                hotel.Add(model);

                List<Quarto> getQuartos = await _context.Quartos.Where(i => i.HotelId == id).ToListAsync();
                
                foreach(var a in hotel)
                {
                    a.Quartos = getQuartos;
                }
            }

            return Ok(hotel);
        }

        [HttpPost("CreateHotel")]
        public async Task<ActionResult> CreateHotel(string nomeHotel, Regiao regiaoHotel)
        {
            Hotel getHotelId = await _context.Hotels.FirstOrDefaultAsync(h => h.NomeHotel == nomeHotel);

            if (getHotelId != null)
                return BadRequest("Já possui hotel com esse nome!");

            bool IsNumerable = int.TryParse(nomeHotel, out _);

            if (IsNumerable)
                return BadRequest("Digite um nome válido para o hotel!");

            if (nomeHotel == null)
                return BadRequest("O nome do hotel não foi preenchido!");

            Hotel hotel = new Hotel()
            {
                NomeHotel = nomeHotel,
                Regiao = regiaoHotel,
            };

            await _context.Hotels.AddAsync(hotel);

            await _context.SaveChangesAsync();

            return Ok(hotel);
        }

        [HttpPost("CreateQuartos")]
        public async Task<ActionResult> CreateQuarto(int numQuarto, int diaria, TipoQuarto tipo, StatusEnum statusQuarto, int hotelId)
        {
            List<Hotel> findHotel = _context.Hotels.Where(i => i.Id == hotelId).ToList();
            
            Quarto getQuarto = await _context.Quartos.FindAsync(numQuarto);

            if (getQuarto != null)
                return BadRequest("Já possui quarto cadastrado com esse número!");

            if (findHotel.Count == 0)
                return BadRequest("Não há hotel com o identificador informado");

            if (numQuarto == 0)
                return BadRequest("O Número do quarto não pode ser 0!");

            if (numQuarto < 0)
                return BadRequest("O número do quarto não pode ser negativo!");

            Quarto objQuarto = new Quarto();
            {
                objQuarto.HotelId = hotelId;
                objQuarto.QuartoId = hotelId;
                objQuarto.Tipo = tipo;
                objQuarto.NumeroQuarto = numQuarto;
                objQuarto.StatusQuarto = statusQuarto;
                objQuarto.ValorDiaria = diaria;
            }

            List<Quarto> quartoInsert = new List<Quarto>();

            quartoInsert.Add(objQuarto);

            foreach(Hotel hotel in findHotel)
            {
                hotel.Quartos = quartoInsert;
            }

            await _context.SaveChangesAsync();

            return Ok(findHotel);
        }

        [HttpPut("UpdateHotel")]
        public async Task<ActionResult> UpdateHotel(string nomeAntigo, string nomeNovo, Regiao regiaoAntiga, Regiao regiaoNova)
        {
            List<Hotel> hotelsToUpdate = await _context.Hotels.Where(n => n.NomeHotel == nomeAntigo && n.Regiao == regiaoAntiga).ToListAsync();

            if (hotelsToUpdate.Count == 0)
                return NotFound("Hotel não econtrado!");

            foreach(var model in hotelsToUpdate)
            {
                model.NomeHotel = nomeNovo;
                model.Regiao = regiaoNova;
            }

            await _context.SaveChangesAsync();

            return Ok(hotelsToUpdate);
        }

        [HttpDelete("DeleteHotel")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            Hotel dbHotel = await _context.Hotels.Where(i => i.Id == id).FirstOrDefaultAsync();

            if (dbHotel == null)
                return BadRequest("Não há Hotel com Id informado! ");

            Quarto dbQuarto = await _context.Quartos.Where(q => q.HotelId == dbHotel.Id).FirstOrDefaultAsync();

            if (dbQuarto != null)
                _context.Quartos.Remove(dbQuarto);

            Reserva dbReserva = await _context.Reservas.Where(r => r.QuartoId == dbHotel.Id).FirstOrDefaultAsync();

            if (dbReserva != null)
                _context.Reservas.Remove(dbReserva);

            _context.Hotels.Remove(dbHotel);

            await _context.SaveChangesAsync();

            return Ok("Hotel removido com sucesso!");

        }

        [HttpGet("GetRegion")]
        public ActionResult<Hotel> GetHotelDisponivel(Regiao regiao)
        {
            List<Hotel> aHotel = _context.Hotels.Where(r => r.Regiao == regiao).ToList();

            if (aHotel.Count == 0)
                return BadRequest("Sem hotel disponível na região!");

            List<Hotel> hotelInsert = new List<Hotel>();

            foreach (var a in aHotel)
            {
                List<Quarto> findId = _context.Quartos.Where(i => i.HotelId == a.Id).Where(s => s.StatusQuarto == StatusEnum.Disponivel).ToList();

                if (findId == null)
                    return BadRequest("Não foi encontrado quarto com Id correspondente!");

                a.Quartos = findId;

                hotelInsert.Add(a);
            }

            return Ok(hotelInsert);
        }

        [HttpPost("CreateReserva")]
        public async Task<ActionResult<Hotel>> CreateReserva(string nomeHotel, int numeroQuarto, Reserva reserva)
        {
            List<Hotel> getHotel = await _context.Hotels.Where(h => h.NomeHotel == nomeHotel).ToListAsync();

            List<Quarto> getQuarto = await _context.Quartos.Where(q => q.NumeroQuarto == numeroQuarto).ToListAsync();

            List<Quarto> quarto = new List<Quarto>();
            
            Hotel hotels = new Hotel();

            Reserva reservaInsert = new Reserva();

            reservaInsert.Entrada = reserva.Entrada;
            reservaInsert.Saida = reserva.Saida;
            reservaInsert.StatusReserva = ReservaEnum.Reservado;

            List<Reserva> reservaList = new List<Reserva>();

            reservaList.Add(reservaInsert);

            foreach (var a in getQuarto)
            {
                a.Reservas = reservaList;

                quarto.Add(a);              
            }

            foreach (var a in getHotel)
            {
                hotels.NomeHotel = nomeHotel;
                hotels.Id = a.Id;
                hotels.Quartos = quarto;
                hotels.Regiao = a.Regiao;
            }

            await _context.AddAsync(reservaInsert);

            await _context.SaveChangesAsync();

            return Ok(hotels);
        }


        #region Métodos
        public async Task<bool> GetQuartoCadastrado(int numQuarto)
        {
            return await _context.Quartos.AnyAsync(i => i.NumeroQuarto == numQuarto);
        }
        #endregion Métodos

    }
}
