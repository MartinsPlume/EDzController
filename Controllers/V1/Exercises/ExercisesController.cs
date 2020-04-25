using EDzController.Data;
using EDzController.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDzController.Controllers.V1.Exercises
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ExercisesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IEnumerable<Exercise> GetProducts()
        {
            return _context.Exercises;
        }

        // GET: api/Exercise/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetExercise([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return Ok(exercise);
        }

        // POST: api/Exercise
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> PostProduct([FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercise", new { id = exercise.ExerciseId }, exercise);
        }

        // PUT: api/Exercise/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> PutExercise([FromRoute] int id, [FromBody] Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercise.ExerciseId)
            {
                return BadRequest();
            }

            _context.Entry(exercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> DeleteExercise([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var excercise = await _context.Exercises.FindAsync(id);
            if (excercise == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(excercise);
            await _context.SaveChangesAsync();
            return Ok(excercise);
        }

        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.ExerciseId == id);
        }
    }
}
