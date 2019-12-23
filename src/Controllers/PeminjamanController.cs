using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibrarySystm.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeminjamanController : ControllerBase
    {
        private readonly DBContext _context;

        public PeminjamanController(DBContext context)
        {
            _context = context;
        }

        //GET All action
        [HttpGet]
        public ActionResult<List<Peminjaman>> GetAll() =>
            _context.Peminjamans.ToList();

        //GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Peminjaman>> GetById(int id)
        {
            var peminjaman = await _context.Peminjamans.FindAsync(id);

            if (peminjaman == null)
            {
                return NotFound();
            }

            return peminjaman;
        }

        //POST action
        [HttpPost]
        public async Task<ActionResult<Peminjaman>> Create(Peminjaman peminjaman)
        {
            _context.Peminjamans.Add(peminjaman);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = peminjaman.Id_transaksi }, peminjaman);
        }

        //PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Peminjaman peminjaman)
        {
            if (id != peminjaman.Id_transaksi)
            {
                return BadRequest();
            }

            _context.Entry(peminjaman).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var peminjaman = await _context.Peminjamans.FindAsync(id);

            if (peminjaman == null)
            {
                return NotFound();
            }

            _context.Peminjamans.Remove(peminjaman);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}