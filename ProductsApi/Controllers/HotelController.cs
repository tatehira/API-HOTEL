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

        [HttpGet]
        [Route("GetHotel/{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            Hotel aHotel = await _context.Hotels.FindAsync(id);

            if (aHotel == null)
                return NotFound();

            return Ok(aHotel);
        }

        [HttpPost]
        [Route("CreateHotel")]
        public async Task<IActionResult> CreateHotel(Hotel hotel)
        {
            var context = await _context.Hotels.Where(a => a.NomeHotel.Contains(hotel.NomeHotel)).ToListAsync();

            foreach (var a in context)
            {
                if (a.NomeHotel == hotel.NomeHotel)
                    throw new Exception("Hotel já cadastrado no banco!");
            }

            await _context.Hotels.AddAsync(hotel);

            await _context.SaveChangesAsync();

            return Ok(hotel);
        }

        [HttpPut]
        [Route("UpdateHotel")]
        public async Task<ActionResult> UpdateHotel(Hotel hotel)
        {
            var dbHotel = await _context.Hotels.FindAsync(hotel.Id);

            if (dbHotel == null)
                return NotFound();

            dbHotel.Adapt(hotel);

            await _context.SaveChangesAsync();

            return Ok(hotel);
        }

        [HttpDelete]
        [Route("DeleteHotel")]
        public async Task<ActionResult> DeleteHotel(int id)
        {
            var dbHotel = await _context.Hotels.FindAsync(id);

            if (dbHotel == null)
                return NotFound();

            _context.Hotels.Remove(dbHotel);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // 

        [HttpGet]
        [Route("GetRegion")]
        public async Task<ActionResult<Hotel>> GetRegion(Regiao regiao)
        {
            List<Hotel> aHotel = _context.Hotels.Where(r => r.Regiao == regiao).ToList();

            List<Hotel> hotelInsert = new List<Hotel>();

            foreach(var a in aHotel)
            {
                hotelInsert.Add(a);
            }

            if (aHotel == null)
                return NotFound();
            
            return Ok(hotelInsert);
        }
    }
}
