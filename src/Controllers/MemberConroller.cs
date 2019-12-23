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
    public class MemberController : ControllerBase
    {
        private readonly DBContext _context;

        public MemberController(DBContext context)
        {
            _context = context;
        }

        //GET All action
        [HttpGet]
        public ActionResult<List<Member>> GetAll() =>
            _context.Members.ToList();

        //GET by Id action
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetById(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        //POST action
        [HttpPost]
        public async Task<ActionResult<Member>> Create(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = member.Id_member }, member);
        }

        //PUT action
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Member member)
        {
            if (id != member.Id_member)
            {
                return BadRequest();
            }

            _context.Entry(member).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //DELETE action
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}