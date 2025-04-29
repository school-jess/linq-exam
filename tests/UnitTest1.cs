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
        var sameGradeInSubject = Class1.groupedBySubject(students); // to group the students by subject and their corresponding grades
        foreach (var subject in sameGradeInSubject) // loop through each subject
        {
            foreach (var grade in subject.Groups) // loop through each grade in subject
            {
                switch (grade.Grade) // switch statement to handle logic based on the value "grade.Grade"
                {
                    case 70: // enters this block if "grade.Grade" is 70
                        if (subject.SubjectIndex == 0) // check if the subject index is 0
                        {
                            Assert.IsTrue(grade.Names.Count == 2); // asserts that there are exactly 2 names associated with the grade
                            foreach (var (actual, expected) in grade.Names.Zip(new string[2] { "Alice Smith", "Bob Johnson" })) // loops through both grade.Names and a list of expected names
                            {
                                Assert.AreEqual(actual, expected); // asserts that each actual name matches the expected name
                            }
                        }
                        else
                        {
                            Assert.IsTrue(grade.Names.Count == 1); // Verify that there is exactly one name associated with this grade
                            checkNames(grade, "Alice Smith"); // Check that the only name is "Alice Smith"
                        }
                        break;
                    case 73:
                        Assert.IsTrue(grade.Names.Count == 1); // Ensure there is exactly one name for grade 73
                        checkNames(grade, "Bob Johnson"); // Confirm that the name is "Bob Johnson"
                        break;
                    case 74:
                        Assert.IsTrue(grade.Names.Count == 1); // Ensure there is exactly one name for grade 74
                        checkNames(grade, "Charlie Brown"); // Confirm that the name is "Charlie Brown"
                        break;
                    case 85:
                        Assert.IsTrue(grade.Names.Count == 1); // Ensure there is exactly one name for grade 85
                        checkNames(grade, "David Lee"); // Confirm that the name is "David Lee"
                        break;
                    case 90:
                        Assert.IsTrue(grade.Names.Count == 1); // Ensure there is exactly one name for grade 90
                        checkNames(grade, "Eve Davis"); // Confirm that the name is "Eve Davis"
                        break;
                }
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