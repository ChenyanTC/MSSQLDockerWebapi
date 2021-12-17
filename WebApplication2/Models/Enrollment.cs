namespace WebApplication2.Models;

public enum Grade
{
    A,B,C,D,F
}
public class Enrollment
{
    public  int EnrollmentID { get; set; }
    public int CourseID { get; set; }//Course表的Id，在此处为外键
    public int StudentID { get; set; }//Student表的Id，在此处为外键
    public Grade? Grate { get; set; }
    
    public Student Student { get; set; }
    public Course Course { get; set; }
}