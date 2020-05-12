using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDzController.Data;
using EDzController.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EDzController.Controllers.V1.Assignments
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Teacher")]
    public class TeacherAssignmentController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherAssignmentController(AppDbContext context) => _context = context;

        [HttpGet]
        public IEnumerable<Assignment> GetAssignments() => _context.Assignments;
        
        [HttpGet("{id}", Name = "GetAssignments")]
        public async Task<IActionResult> GetAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null) return NotFound();

            return Ok(assignment);
        }
        
        [HttpPost]
        public async Task <IActionResult> PostAssignment([FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignment", new { id = assignment.Id }, assignment);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment([FromRoute] int id, [FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != assignment.Id) return BadRequest();

            _context.Entry(assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(id)) return NotFound();

                throw;
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null) return NotFound();

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return Ok(assignment);
        }
        
        private bool AssignmentExists(int id) => _context.Assignments.Any(e => e.Id == id);
    }
}