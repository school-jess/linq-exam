// See https://aka.ms/new-console-template for more information
using library; // import "library" namespace

List<Student> students = new List<Student>() {
    new Student {StudentID = 101, FirstName = "Alice", LastName = "Smith", Scores = new List<int> {85, 92, 78, 95}},
    new Student {StudentID = 102, FirstName = "Bob", LastName = "Johnson", Scores = new List<int> {76, 88, 90, 70}},
    new Student {StudentID = 103, FirstName = "Charlie", LastName = "Brown", Scores = new List<int> {92, 95, 90, 98}},
    new Student {StudentID = 104, FirstName = "David", LastName = "Lee", Scores = new List<int> {68, 75, 80 , 70}},
    new Student {StudentID = 105, FirstName = "Eve", LastName = "Davis", Scores = new List<int> {95, 75, 92, 97}},
}; // seed in-memory database


List<Student> newStudents = new List<Student>() {
    new Student {StudentID = 106, FirstName = "a", LastName = "b", Scores = new List<int> {80, 80, 80, 80}},
    new Student {StudentID = 107, FirstName = "c", LastName = "d", Scores = new List<int> {81, 81, 81, 81}},
    new Student {StudentID = 108, FirstName = "e", LastName = "f", Scores = new List<int> {82, 82, 82, 82}},
    new Student {StudentID = 109, FirstName = "g", LastName = "h", Scores = new List<int> {83, 83, 83 , 83}},
    new Student {StudentID = 110, FirstName = "i", LastName = "j", Scores = new List<int> {84, 84, 84, 84}},
    new Student {StudentID = 111, FirstName = "k", LastName = "l", Scores = new List<int> {85, 85, 85, 85}},
    new Student {StudentID = 112, FirstName = "m", LastName = "n", Scores = new List<int> {86, 86, 86, 86}},
    new Student {StudentID = 113, FirstName = "o", LastName = "p", Scores = new List<int> {87, 87, 87, 87}},
    new Student {StudentID = 114, FirstName = "q", LastName = "r", Scores = new List<int> {88, 88, 88 , 88}},
    new Student {StudentID = 115, FirstName = "s", LastName = "t", Scores = new List<int> {95, 75, 92, 97}},
}; // create a new list of students
foreach (var newStudent in newStudents) // loopp through the new students
{
    students.Add(newStudent); // add new student to the in-memory database of students
}

var failingStudents = Class1.getFailingStudents(students); // get failing students
Console.WriteLine("Failing Students:");
foreach (var failingStudent in failingStudents) // loop through failing students
{
    Console.WriteLine(failingStudent); // print to console each failing student
}
Console.WriteLine();

Console.WriteLine("Students with the same first name:");
var studentsWithSameFirstName = Class1.getStudentWithSameFirstName(students);// get students with the same starting firstname
foreach (var studentWithSameFirstName in studentsWithSameFirstName)// loop students with the same first name
{
    Console.WriteLine(studentWithSameFirstName); // print to console each student with same first name
}
Console.WriteLine();

Console.WriteLine("Students grouped by the same score for each subject");
var sameGradeInSubject = Class1.groupedBySubject(students); // get the grades of each subject and categorize them by their grade and create a List of names per grade
foreach (var subject in sameGradeInSubject) // loop through each subject
{
    Console.WriteLine(subject.SubjectIndex); // print to console each subject index
    foreach (var gradeGroup in subject.Groups) // loop through each grade in subject
    {
        Console.WriteLine(gradeGroup.Grade); // print to console each grade
        foreach (var studentName in gradeGroup.Names) // loop through each name in grade
        {
            Console.WriteLine(studentName); // print to console each student from grade group in subject
        }
        Console.WriteLine(); // print to console a newline for formatting of different grades of a subject
    }
    Console.WriteLine(); // print to console a newline for formatting of different subjects
}
