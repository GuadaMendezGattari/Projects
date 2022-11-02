using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Data;
using Users.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Users.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        public readonly UsersDbContext _context;

        public UsersController(UsersDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = from item in _context.User
                           select new User()
                           {
                               Id = item.Id,
                               Name = item.Name,
                               Username = item.Username
                           };
                var users = await list.ToListAsync();
                return Ok(users);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var us = await _context.User.FindAsync(id);
                if (us == null) return NotFound();
                var user = new User()
                           {
                               Id = us.Id,
                               Name = us.Name,
                               Username = us.Username
                           };
                return Ok(user);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                var users = from b in _context.User
                            where b.Username == user.Username
                            select b;
                if (users.Count() == 0)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return Ok(new {success = false, message = "Fue agregado con exito"});
                } else
                {
                    return Ok(new { success = true, message = "Ya hay un usuario con ese nombre" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] User user)
        {
            try
            {
                if (id != user.Id) return BadRequest();
                _context.Update(user);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Usuario modificado con exito" });
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var user = await _context.User.FindAsync(id);
                if (user == null) return NotFound();
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(new {message = "Usuario eliminado con exito"});
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

