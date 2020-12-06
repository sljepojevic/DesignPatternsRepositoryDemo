using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RepositoryDemo.Models;
using RepositoryDemo.Repository;

namespace RepositoryDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private Context _context;
        private IStudentRepository _studentRepository;

        private BaseRepository<Student> _baseRepositoryStudent;
        private BaseRepository<Course> _baseRepositoryCourse;
        private BaseRepository<Enrollment> _baseRepositoryEnrollment;


        public StudentController(Context context, IStudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
            _baseRepositoryStudent = new BaseRepository<Student>(_context);
            _baseRepositoryCourse = new BaseRepository<Course>(_context);
            _baseRepositoryEnrollment = new BaseRepository<Enrollment>(_context);
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        { 
            return _context.Students.ToList();
            // return _studentRepository.GetStudents();
            // return _baseRepositoryStudent.Get();
        }

        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            return _baseRepositoryStudent.GetById(id);
        }

        /*
         * Returns OK if firstName and lastName is the same
         * Throws exception otherwise
         */
        [HttpGet("{id}/sameName")]
        public OkResult CheckIfFirstNameAndLastNameIsTheSame(int id)
        { 
            var student = _context.Students.Find(id);
            
           // var student = _studentRepository.GetStudentById(id);

            if(CheckName(student) != 0)
                throw new Exception("FirstName and LastName is not the same");

            return Ok();
        }

        [HttpGet("{id}/enrollments")]
        public ICollection<Enrollment> GetStudentsEnrollment(int id)
        {
            Student student = _baseRepositoryStudent.GetById(id);
            return student.Enrollments;
        }

        [HttpPost]
        public OkResult CreateStudent(Student student)
        {
            // if (student.FirstName.Length == 0)
            // {
            //     throw new Exception("First name should not be empty!");
            // }
            // _context.Students.Add(student);

            _studentRepository.InsertStudent(student);
            _studentRepository.Save();

            /*
             * -----
             */
            return Ok();
        }
        
        private int CheckName(Student student)
        {
            if (student.FirstName != student.LastName)
                return 0;
            return -1;
        }
    }
}