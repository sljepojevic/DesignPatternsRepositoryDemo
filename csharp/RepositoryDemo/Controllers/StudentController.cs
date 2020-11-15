using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryDemo.Models;
using RepositoryDemo.Repository;

namespace RepositoryDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private Context _context;
        private IStudentRepository _studentRepository;

        private BaseRepository<Student> _baseRepositoryStudent;
        private BaseRepository<Course> _baseRepositoryCourse;
        private BaseRepository<Enrollment> _baseRepositoryEnrollment;


        public StudentController(Context context, ILogger<StudentController> logger,
            IStudentRepository studentRepository)
        {
            _context = context;
            _logger = logger;
            _studentRepository = studentRepository;
            _baseRepositoryStudent = new BaseRepository<Student>(_context);
            _baseRepositoryCourse = new BaseRepository<Course>(_context);
            _baseRepositoryEnrollment = new BaseRepository<Enrollment>(_context);
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            _logger.Log(LogLevel.Debug, "Get students");
            return _baseRepositoryStudent.Get();
            // return _studentRepository.GetStudents();
            // return _context.Students.AsEnumerable().ToArray();
        }

        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            _logger.Log(LogLevel.Debug, "Get student with id " + id);
            return _baseRepositoryStudent.GetById(id);
        }

        [HttpGet("{id}/enrollments")]
        public ICollection<Enrollment> GetStudentsEnrollment(int id)
        {
            _logger.Log(LogLevel.Debug, "Get student with id " + id);
            Student student = _baseRepositoryStudent.GetById(id);
            return student.Enrollments;
        }

        [HttpPost]
        public OkResult CreateStudent(Student student)
        {
            _studentRepository.InsertStudent(student);
            _studentRepository.Save();
            return Ok();
        }
    }
}