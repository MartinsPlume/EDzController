using EDzController.Data;
using EDzController.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EDzController.Controllers.V1.Exercises
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ExercisesController(AppDbContext context) => _context = context;

        [HttpGet]
        [Authorize(Roles = "Teacher, Student")]
        public IEnumerable<Exercise> GetExercises()
        {
            var currentUser = HttpContext.User;
            var userRole = currentUser
                .Claims
                .FirstOrDefault(c => c.Type == "UserRole")?
                .Value.ToString();
            
            if (userRole != null && userRole.Equals("Teacher")) return _context.Exercises;
            
            var userEmail = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var exercises = _context.Assignments.Where(u => u.User.Email == userEmail).Select(u => u.Exercise.Id);
            
            return _context.Exercises.Where(e=>exercises.Contains(e.Id));
        }

        [Authorize(Roles = "Teacher, Student")]
        [HttpGet("{id}", Name = "GetExercises")]
        public async Task<IActionResult> GetExercise([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null) return NotFound();

            return Ok(exercise);
        }

        // POST: api/Exercise
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> PostProduct([FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
        }

        // PUT: api/Exercise/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> PutExercise([FromRoute] int id, [FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != exercise.Id) return BadRequest();

            _context.Entry(exercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id)) return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null) return NotFound();

            if (ExerciseExistsInAssignment(id))
            {
                return Forbid();
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return Ok(exercise);
        }

        private bool ExerciseExistsInAssignment(int id) => _context.Assignments.Any(a => a.Id == id);

        private bool ExerciseExists(int id) => _context.Exercises.Any(e => e.Id == id);
    }
}
