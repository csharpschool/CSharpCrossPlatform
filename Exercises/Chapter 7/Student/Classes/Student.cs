namespace Student.Classes;

class Student
{
    private readonly string firstName = string.Empty;
    private readonly string lastName = string.Empty;
    public string FullName => $"{firstName} {lastName}"; 
    public readonly int age = default;

    public Student() { }

    public Student(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
}