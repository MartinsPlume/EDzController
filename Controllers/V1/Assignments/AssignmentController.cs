using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
    
    public class AssignmentController : Controller
    {
        private readonly AppDbContext _context;

        public AssignmentController(AppDbContext context) => _context = context;

        [Authorize(Roles = "Student, Teacher")]
        [HttpGet]
        public IEnumerable<AssignmentInfo> GetAssignments()
        {
            var currentUser = HttpContext.User;
            var userRole = currentUser
                .Claims
                .FirstOrDefault(c => c.Type == "UserRole")?
                .Value.ToString();
            
            var assignments = _context.Assignments
                .Select(u => new AssignmentInfo()
                {
                    Id = u.Id,
                    ShortInstruction = u.ShortInstruction,
                    UserId = u.User.Id,
                    UserEmail = u.User.Email,
                    ExerciseId = u.Exercise.Id
                });

            if (userRole != null && userRole.Equals("Teacher"))
                return assignments;
            
            var userEmail = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            return assignments.Where(u => u.UserEmail == userEmail);
        }

        [Authorize(Roles = "Student, Teacher")]
        [HttpGet("{id}", Name = "GetAssignments")]
        public async Task<IActionResult> GetAssignment([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null) return NotFound();

            return Ok(assignment);
        }
        
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public async Task <IActionResult> PostAssignment([FromBody] Assignment assignment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignment", new { id = assignment.Id }, assignment);
        }
        
        [Authorize(Roles = "Teacher")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment([FromRoute] int id, [FromBody] AssignmentInfo assignmentInfo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var assignment = new Assignment()
            {
                Exercise = await _context.Exercises.FindAsync(assignmentInfo.ExerciseId),
                Id = id,
                User = await _context.Users.FindAsync(assignmentInfo.UserId),
                ShortInstruction = assignmentInfo.ShortInstruction
            };

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
        
        [Authorize(Roles = "Teacher")]
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