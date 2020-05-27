using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi2020.DB;
using WebApi2020.Models;

namespace WebApi2020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SysRoleController : ControllerBase
    {
        private readonly MyContext _context;

        public SysRoleController(MyContext context)
        {
            _context = context;
        }

        // GET: api/SysRole
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SysRole>>> GetSysRole()
        {
            return await _context.SysRole.ToListAsync();
        }

        // GET: api/SysRole/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SysRole>> GetSysRole(int id)
        {
            var sysRole = await _context.SysRole.FindAsync(id);
            _context.SysRole.
            if (sysRole == null)
            {
                return NotFound();
            }

            return sysRole;
        }

        // PUT: api/SysRole/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSysRole(int id, SysRole sysRole)
        {
            if (id != sysRole.ID)
            {
                return BadRequest();
            }

            _context.Entry(sysRole).State = EntityState.Modified;

            try
            {
                _context.Database.BeginTransaction
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SysRoleExists(id))
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

        // POST: api/SysRole
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SysRole>> PostSysRole(SysRole sysRole)
        {
            _context.SysRole.Add(sysRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSysRole", new { id = sysRole.ID }, sysRole);
        }

        // DELETE: api/SysRole/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SysRole>> DeleteSysRole(int id)
        {
            var sysRole = await _context.SysRole.FindAsync(id);
            if (sysRole == null)
            {
                return NotFound();
            }

            _context.SysRole.Remove(sysRole);
            await _context.SaveChangesAsync();

            return sysRole;
        }

        private bool SysRoleExists(int id)
        {
            return _context.SysRole.Any(e => e.ID == id);
        }
    }
}
