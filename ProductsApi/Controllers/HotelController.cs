﻿using Mapster;
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
            var contextHotel = await _context.Hotels.Where(a => a.NomeHotel == hotel.NomeHotel).ToListAsync();

            var contextReserva = await _context.Reservas.Where(i => i.Id == hotel.Id).ToListAsync();

            Hotel validationHotel = new Hotel();

            Reserva ValidationReserva = new Reserva();

            foreach (var a in contextHotel)
            {
                validationHotel.Adapt(a);
            }

            foreach (var b in contextReserva)
            {
                ValidationReserva.Adapt(b);
            }

            if (validationHotel.NomeHotel == hotel.NomeHotel && validationHotel.Regiao == hotel.Regiao)
                throw new Exception("Este hotel já está cadastrado nesta região! ");

            if (ValidationReserva.Saida < ValidationReserva.Entrada)
                throw new Exception("Data Saida menor que a data de Entrada! ");

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
        public async Task<ActionResult> DeleteHotel(string nome)
        {
            var dbHotel = await _context.Hotels.Where(i => i.NomeHotel == nome).FirstOrDefaultAsync();
            var dbQuarto = await _context.Quartos.Where(q => q.Id == dbHotel.Id).FirstOrDefaultAsync();
            var dbReserva = await _context.Reservas.Where(r => r.Id == dbHotel.Id).FirstOrDefaultAsync();

            if (dbHotel == null && dbQuarto == null && dbReserva == null)
                throw new Exception("Não há Hotel/Quarto/Reserva com Id informado! ");

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
                string error = "Não foi possível remover do sistema!";

                return BadRequest(error);
            }
        }


        [HttpGet]
        [Route("GetRegion")]
        public async Task<ActionResult<Hotel>> GetRegion(Regiao regiao)
        {
            try
            {
                List<Hotel> aHotel = _context.Hotels.Where(r => r.Regiao == regiao).ToList();
                List<Hotel> hotelInsert = new List<Hotel>();

                foreach (var a in aHotel)
                {
                    hotelInsert.Add(a);
                }

                return Ok(hotelInsert);
            }

            catch (Exception ex)
            {
                string error = "Ocorreu um erro na busca de acordo com a região!";

                return BadRequest(error);
            }
           
        }
    }
}
