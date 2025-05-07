namespace library; // 'library' namespace

public class Student // student model
{
    public int StudentID { get; set; } // student id
    public string FirstName { get; set; } // student first name
    public string LastName { get; set; } // student last name
    public List<int> Scores { get; set; } // student scores
    public string FullName { get => $"{FirstName} {LastName}"; } // student fullname
}

public class GradeGroup
{
    public int Grade; // grade from a subject
    public List<string> Names; // list of names belonging to a grade
}

public class Subject
{
    public int SubjectIndex; // subject id
    public List<GradeGroup> Groups; // list of grades belonging to a subject
}

public class Class1 // main class
{
    public static List<string> getFailingStudents(List<Student> students) // method to get a list of failing students from a database
    {
        return (from student in students // loop through all the students
                let StudentAverage = student.Scores.Average() // get the average of the students scores
                where StudentAverage < 75.0 // check if student average is less than 75
                select student.FullName).ToList(); // select the fullname of a student and return the students who failed as a list from the linq expression
    }

    public static List<string> getStudentWithSameFirstName(List<Student> students) // method to get the students with the same first name
    {
        return (from student in students // loop through all the students
                where (from student_sec_loop in students // loop through the students again
                       where student.FirstName.Equals(student_sec_loop.FirstName) // check if the outer loop student's first name is equal to the inner loop student's first name
                       select student_sec_loop).Any() // select the inner student and check if there are any students from linq expression
                select student.FullName).ToList(); // select the fullname of a student and return the students with the same first name
    }

    public static List<Subject> groupedBySubject(List<Student> students) // method to get the grades of each subject and categorize them by their grade and create a List of names per grade
    {
        var subj = Enumerable.Range(0, students[0].Scores.Count) // create a list from 0 - 4
                         .Select(i => new // select the 'i' integer
                         Subject // create a new Subject structure
                         {
                             SubjectIndex = i, // set the 'SubjectIndex' to 'i' integer
                             Groups = students.GroupBy(s => s.Scores[i]) // set the 'Groups' field to 
                                              .Select(g => new GradeGroup { Grade = g.Key, Names = g.Select(s => s.FullName).ToList() }).ToList()
                         }).ToList(); // return the groups of grades as a list
        return subj; // return the 'subj' variable
    }
}
