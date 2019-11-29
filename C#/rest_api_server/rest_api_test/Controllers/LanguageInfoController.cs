using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rest_api_test.Models;

namespace rest_api_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageInfoController : ControllerBase
    {
        private readonly MSSQLContext _context;

        public LanguageInfoController(MSSQLContext context)
        {
            _context = context;
        }

        // GET: api/LanguageInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageInfo>>> GetLanguageInfo()
        {
            return await _context.LanguageInfo.ToListAsync();
        }

        // GET: api/LanguageInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageInfo>> GetLanguageInfo(string id)
        {
            var languageInfo = await _context.LanguageInfo.FindAsync(id);

            if (languageInfo == null)
            {
                return NotFound();
            }

            return languageInfo;
        }

        // PUT: api/LanguageInfo/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguageInfo(string id, LanguageInfo languageInfo)
        {
            if (id != languageInfo.LanguageCode)
            {
                return BadRequest();
            }

            _context.Entry(languageInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageInfoExists(id))
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

        // POST: api/LanguageInfo
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LanguageInfo>> PostLanguageInfo(LanguageInfo languageInfo)
        {
            _context.LanguageInfo.Add(languageInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LanguageInfoExists(languageInfo.LanguageCode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLanguageInfo", new { id = languageInfo.LanguageCode }, languageInfo);
        }

        // DELETE: api/LanguageInfo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LanguageInfo>> DeleteLanguageInfo(string id)
        {
            var languageInfo = await _context.LanguageInfo.FindAsync(id);
            if (languageInfo == null)
            {
                return NotFound();
            }

            _context.LanguageInfo.Remove(languageInfo);
            await _context.SaveChangesAsync();

            return languageInfo;
        }
        [HttpDelete]
        public void DeleteLanguageAll()
        {
            //from p in _context.LanguageInfo
            //where _context.LanguageInfo.Any(a => a.LanguageCode != "0")
            //select p;

            var test = _context.LanguageInfo
                .Where(b => b.LanguageCode != "0")
                .ToList();
            _context.LanguageInfo.RemoveRange(test);
            _context.SaveChanges();
        }

        private bool LanguageInfoExists(string id)
        {
            return _context.LanguageInfo.Any(e => e.LanguageCode == id);
        }
    }
}
