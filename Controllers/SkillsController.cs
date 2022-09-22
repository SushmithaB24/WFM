﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly RestAPIDBContext _context;

        public SkillsController(RestAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Skills
        [HttpGet, Route("GetSkills")]
        public ActionResult GetSkills()
        {
            var skills = _context.Skills.Include(s => s.SkillMaps).ThenInclude(s => s.Employees).ToList();

            return new OkObjectResult(skills);
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Skills>> GetSkills(decimal id)
        {
            var skills = await _context.Skills.FindAsync(id);

            if (skills == null)
            {
                return NotFound();
            }

            return skills;
        }

        // PUT: api/Skills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkills(decimal id, Skills skills)
        {
            if (id != skills.Skillid)
            {
                return BadRequest();
            }

            _context.Entry(skills).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillsExists(id))
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

        // POST: api/Skills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Skills>> PostSkills(Skills skills)
        {
            _context.Skills.Add(skills);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SkillsExists(skills.Skillid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSkills", new { id = skills.Skillid }, skills);
        }

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkills(decimal id)
        {
            var skills = await _context.Skills.FindAsync(id);
            if (skills == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skills);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillsExists(decimal id)
        {
            return _context.Skills.Any(e => e.Skillid == id);
        }
    }
}