using library; // import 'library' namespace

namespace tests; // set up namespace 'tests'

[TestClass] // annotate class as a 'TestClass'
public class UnitTest1 // define 'UnitTest1' class 
{
    List<Student> students { get; set; } // in-memory database

    [TestInitialize] // annotate method as 'TestInitialize'
    public void Setup() // define method 'Setup'
    {
        students = new List<Student>() {
            new Student {StudentID = 101, FirstName = "Alice", LastName = "Smith", Scores = new List<int> {70, 70, 70, 70}},
            new Student {StudentID = 102, FirstName = "Bob", LastName = "Johnson", Scores = new List<int> {70, 73, 73, 73}},
            new Student {StudentID = 103, FirstName = "Charlie", LastName = "Brown", Scores = new List<int> {74, 74, 74, 74}},
            new Student {StudentID = 104, FirstName = "David", LastName = "Lee", Scores = new List<int> {85, 85, 85 , 85}},
            new Student {StudentID = 105, FirstName = "Eve", LastName = "Davis", Scores = new List<int> {90, 90, 90, 90}},
        }; // seed tests in-memory database
    }

    [TestMethod]  // annotate method as 'TestMethod'
    public void TestGetFailingStudents() // define method 'TestGetFailingStudents'
    {
        var failingStudents = Class1.getFailingStudents(students); // assert that the returned list of students with that failed has any items
        Assert.IsTrue(failingStudents.Any());
    }

    [TestMethod] // annotate method as 'TestMethod'
    public void TestStudentsWithSameFirstName() // define method 'TestStudentsWithSameFirstName'
    {
        var studentsWithSameFirstName = Class1.getStudentWithSameFirstName(students);
        Assert.IsTrue(studentsWithSameFirstName.Any()); // assert that the returned list of students with the same first name has any items
    }

    [TestMethod] // annotate method as 'TestMethod'
    public void TestSameGradeInSubject() // define method 'TestSameGradeInSubject'
    {
        var sameGradeInSubject = Class1.groupedBySubject(students);
        var allSubjectGrades = sameGradeInSubject.SelectMany(
            subject => subject.Groups,
            (subject, grade) => new { subject, grade }
        );

        foreach (var item in allSubjectGrades)
        {
            switch (item.grade.Grade)
            {
                case 70:
                    if (item.subject.SubjectIndex == 0)
                    {
                        Assert.IsTrue(item.grade.Names.Count == 2);
                        var expected = new[] { "Alice Smith", "Bob Johnson" };
                        foreach (var (actual, expectedName) in item.grade.Names.Zip(expected))
                        {
                            Assert.AreEqual(actual, expectedName);
                        }
                    }
                    else
                    {
                        Assert.IsTrue(item.grade.Names.Count == 1);
                        checkNames(item.grade, "Alice Smith");
                    }
                    break;

                case 73:
                    Assert.IsTrue(item.grade.Names.Count == 1);
                    checkNames(item.grade, "Bob Johnson");
                    break;

                case 74:
                    Assert.IsTrue(item.grade.Names.Count == 1);
                    checkNames(item.grade, "Charlie Brown");
                    break;

                case 85:
                    Assert.IsTrue(item.grade.Names.Count == 1);
                    checkNames(item.grade, "David Lee");
                    break;

                case 90:
                    Assert.IsTrue(item.grade.Names.Count == 1);
                    checkNames(item.grade, "Eve Davis");
                    break;
            }
        }
    }
    private void checkNames(GradeGroup grade, string expected) // Declare a private method named 'checkNames' that takes a GradeGroup and a string.
    {
        foreach (var name in grade.Names) // Loop through each 'name' in the 'Names' collection of the 'grade' object.
        {
            Assert.AreEqual(name, expected); // Assert that each name matches the expected name
        }
    }
}