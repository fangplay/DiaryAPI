using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiaryAPI.Models;

namespace DiaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryItemsController : ControllerBase
    {
        private readonly DiaryContext _context;

        public DiaryItemsController(DiaryContext context)
        {
            _context = context;
        }

        // GET: api/DiaryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiaryItems>>> GetDiaryItems()
        {
          if (_context.DiaryItems == null)
          {
              return NotFound();
          }
            return await _context.DiaryItems.ToListAsync();
        }

        // GET: api/DiaryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiaryItems>> GetDiaryItems(long id)
        {
          if (_context.DiaryItems == null)
          {
              return NotFound();
          }
            var diaryItems = await _context.DiaryItems.FindAsync(id);

            if (diaryItems == null)
            {
                return NotFound();
            }

            return diaryItems;
        }

        // PUT: api/DiaryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiaryItems(long id, DiaryItems diaryItems)
        {
            if (id != diaryItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(diaryItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaryItemsExists(id))
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

        // POST: api/DiaryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiaryItems>> PostDiaryItems(DiaryItems diaryItems)
        {
          if (_context.DiaryItems == null)
          {
              return Problem("Entity set 'DiaryContext.DiaryItems'  is null.");
          }
            _context.DiaryItems.Add(diaryItems);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetDiaryItems", new { id = diaryItems.Id }, diaryItems);
            return CreatedAtAction(nameof(GetDiaryItems), new { id = diaryItems.Id }, diaryItems);
        }

        // DELETE: api/DiaryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiaryItems(long id)
        {
            if (_context.DiaryItems == null)
            {
                return NotFound();
            }
            var diaryItems = await _context.DiaryItems.FindAsync(id);
            if (diaryItems == null)
            {
                return NotFound();
            }

            _context.DiaryItems.Remove(diaryItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiaryItemsExists(long id)
        {
            return (_context.DiaryItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
