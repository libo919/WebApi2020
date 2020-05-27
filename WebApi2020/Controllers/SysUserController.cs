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
    public class SysUserController : ControllerBase
    {
        private readonly ModelContext _context;

        public SysUserController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/SysUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SysUser>>> GetSysUser()
        {
            return await _context.SysUser.ToListAsync();
        }

        // GET: api/SysUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SysUser>> GetSysUser(int id)
        {
            var sysUser = await _context.SysUser.FindAsync(id);

            if (sysUser == null)
            {
                return NotFound();
            }

            return sysUser;
        }

        // PUT: api/SysUser/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSysUser(int id, SysUser sysUser)
        {
            if (id != sysUser.ID)
            {
                return BadRequest();
            }

            _context.Entry(sysUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SysUserExists(id))
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

        // POST: api/SysUser
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SysUser>> PostSysUser(SysUser sysUser)
        {
            _context.SysUser.Add(sysUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSysUser", new { id = sysUser.ID }, sysUser);
        }

        // DELETE: api/SysUser/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SysUser>> DeleteSysUser(int id)
        {
            var sysUser = await _context.SysUser.FindAsync(id);
            if (sysUser == null)
            {
                return NotFound();
            }

            _context.SysUser.Remove(sysUser);
            await _context.SaveChangesAsync();

            return sysUser;
        }

        private bool SysUserExists(int id)
        {
            return _context.SysUser.Any(e => e.ID == id);
        }
    }
}
