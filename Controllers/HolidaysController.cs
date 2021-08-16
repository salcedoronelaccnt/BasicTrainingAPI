using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicTraining.Data;
using BasicTraining.Models;

namespace BasicTraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        private readonly BasicTrainingContext _context;

        public HolidaysController(BasicTrainingContext context)
        {
            _context = context;
        }

        // GET: api/Holidays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Holiday>>> GetHoliday()
        {
            return await _context.Holiday.ToListAsync();
        }

        // GET: api/Holidays/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Holiday>> GetHoliday(string id)
        {
            var holiday = await _context.Holiday.FindAsync(id);

            if (holiday == null)
            {
                return NotFound();
            }

            return holiday;
        }

        // PUT: api/Holidays/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoliday(string id, Holiday holiday)
        {
            if (id != holiday.HolidayID)
            {
                return BadRequest();
            }

            _context.Entry(holiday).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HolidayExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Holidays
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Holiday>> PostHoliday(Holiday holiday)
        {
            _context.Holiday.Add(holiday);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HolidayExists(holiday.HolidayID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHoliday", new { id = holiday.HolidayID }, holiday);
        }

        // DELETE: api/Holidays/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Holiday>> DeleteHoliday(string id)
        {
            var holiday = await _context.Holiday.FindAsync(id);
            if (holiday == null)
            {
                return NotFound();
            }

            _context.Holiday.Remove(holiday);
            await _context.SaveChangesAsync();

            return holiday;
        }

        private bool HolidayExists(string id)
        {
            return _context.Holiday.Any(e => e.HolidayID == id);
        }
    }
}
