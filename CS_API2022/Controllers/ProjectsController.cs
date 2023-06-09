using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CS_API2022.Data;
using CS_API2022.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.Build.Framework;

namespace CS_API2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]


    public class ProjectsController : ControllerBase
    {
        private readonly CS_API2022Context _context;

        public ProjectsController(CS_API2022Context context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projects>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Projects>> GetProjects(int id)
        {
            var projects = await _context.Projects.FindAsync(id);

            if (projects == null)
            {
                return NotFound();
            }

            return projects;
        }
        [HttpGet]
        [Route("/Tasks/Search/{Employeeid:int}")]
        public List<Projects> GetTasksAssigned(int Employeeid)
        {
            List<Projects> tasks = new List<Projects>();
            var t = _context.Projects.Where(t => t.UserId == Employeeid);
            foreach (var task in t)
                tasks.Add(task);



            return tasks;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjects(int id, Projects projects)
        {
            if (id != projects.Id)
            {
                return BadRequest();
            }

            _context.Entry(projects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(id))
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

        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Projects>> PostProjects(Projects projects)
        {
            _context.Projects.Add(projects);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjects", new { id = projects.Id }, projects);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjects(int id)
        {
            var projects = await _context.Projects.FindAsync(id);
            if (projects == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(projects);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
