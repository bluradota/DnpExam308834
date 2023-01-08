
using Entities;

using Microsoft.AspNetCore.Mvc;
using WebApi.Data;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDataAccess _dataAccess;

        public StudentsController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _dataAccess.GetAllStudents();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _dataAccess.GetStudentById(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            var updatedStudent = await _dataAccess.UpdateStudent(student);

            if (updatedStudent == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var createdStudent = await _dataAccess.AddStudent(student);
            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var student = await _dataAccess.DeleteStudent(id);
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }
    }
}