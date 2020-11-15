namespace RepositoryDemo.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public long? Grade { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}