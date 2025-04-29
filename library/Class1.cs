namespace library;

public class Student
{
    public int StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> Scores { get; set; }
    public string FullName { get => $"{FirstName} {LastName}"; }
}

public class GradeGroup
{
    public int Grade;
    public List<string> Names;
}

public class Subject
{
    public int SubjectIndex;
    public List<GradeGroup> Groups;
}

public class Class1
{
    public static List<string> getFailingStudents(List<Student> students)
    {
        return (from student in students
                let StudentAverage = student.Scores.Average()
                where StudentAverage < 75.0
                select student.FullName).ToList();
    }

    public static List<string> getStudentWithSameFirstName(List<Student> students)
    {
        return (from student in students
                where (from student_sec_loop in students
                       where student.FirstName.Equals(student_sec_loop.FirstName)
                       select student_sec_loop).Any()
                select student.FullName).ToList();
    }

    public static List<Subject> groupedBySubject(List<Student> students)
    {
        var subj = Enumerable.Range(0, students[0].Scores.Count)
                         .Select(i => new
                         Subject
                         {
                             SubjectIndex = i,
                             Groups = students.GroupBy(s => s.Scores[i])
                                              .Select(g => new GradeGroup { Grade = g.Key, Names = g.Select(s => s.FullName).ToList() }).ToList()
                         }).ToList();
        return subj;
    }
}
