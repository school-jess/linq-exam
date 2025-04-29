using library;

namespace tests;

[TestClass]
public class UnitTest1
{
    List<Student> students { get; set; }
    [TestInitialize]
    public void Setup()
    {
        students = new List<Student>() {
            new Student {StudentID = 101, FirstName = "Alice", LastName = "Smith", Scores = new List<int> {70, 70, 70, 70}},
            new Student {StudentID = 102, FirstName = "Bob", LastName = "Johnson", Scores = new List<int> {70, 73, 73, 73}},
            new Student {StudentID = 103, FirstName = "Charlie", LastName = "Brown", Scores = new List<int> {74, 74, 74, 74}},
            new Student {StudentID = 104, FirstName = "David", LastName = "Lee", Scores = new List<int> {85, 85, 85 , 85}},
            new Student {StudentID = 105, FirstName = "Eve", LastName = "Davis", Scores = new List<int> {90, 90, 90, 90}},
        };
    }

    [TestMethod]
    public void TestGetFailingStudents()
    {
        var failingStudents = Class1.getFailingStudents(students);
        Assert.IsTrue(failingStudents.Any());
    }

    [TestMethod]
    public void TestStudentsWithSameFirstName()
    {
        var studentsWithSameFirstName = Class1.getStudentWithSameFirstName(students);
        Assert.IsTrue(studentsWithSameFirstName.Any());
    }

    [TestMethod]
    public void TestSameGradeInSubject()
    {
        var sameGradeInSubject = Class1.groupedBySubject(students);
        foreach (var subject in sameGradeInSubject)
        {
            foreach (var grade in subject.Groups)
            {
                switch (grade.Grade)
                {
                    case 70:
                        if (subject.SubjectIndex == 0)
                        {
                            Assert.IsTrue(grade.Names.Count == 2);
                            foreach (var (actual, expected) in grade.Names.Zip(new string[2] { "Alice Smith", "Bob Johnson" }))
                            {
                                Assert.AreEqual(actual, expected);
                            }
                        }
                        else
                        {
                            Assert.IsTrue(grade.Names.Count == 1);
                            checkNames(grade, "Alice Smith");
                        }
                        break;
                    case 73:
                        Assert.IsTrue(grade.Names.Count == 1);
                        checkNames(grade, "Bob Johnson");
                        break;
                    case 74:
                        Assert.IsTrue(grade.Names.Count == 1);
                        checkNames(grade, "Charlie Brown");
                        break;
                    case 85:
                        Assert.IsTrue(grade.Names.Count == 1);
                        checkNames(grade, "David Lee");
                        break;
                    case 90:
                        Assert.IsTrue(grade.Names.Count == 1);
                        checkNames(grade, "Eve Davis");
                        break;
                }
            }
        }
    }
    private void checkNames(GradeGroup grade, string expected)
    {
        foreach (var name in grade.Names)
        {
            Assert.AreEqual(name, expected);
        }
    }
}