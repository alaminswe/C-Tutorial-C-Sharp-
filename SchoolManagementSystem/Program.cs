using Microsoft.VisualBasic;

class SchoolManagementSystem
{
    static void Main(string[] args)
    {
        School school = new School("Dhaka Model School");

        Student s1 = new Student("Rahim", 16, "rahim@gmail.com", "STU001");
        s1.GPA = 3.8;

        Student s2 = new Student("Karim", 17, "karim@gmail.com", "STU002");
        s2.GPA = 2.6;

        Teacher t1 = new Teacher("Mr. Hasan", 35, "hasan@school.com", "Math", 1200000);


        school.AddStudent(s1);   // ✅ Student Rahim added.
        school.AddStudent(s2);   // ✅ Student Karim added.
        school.AddTeacher(t1);   // ✅ Teacher Mr. Hasan added.
        Console.WriteLine("Showing All of School Students and teachers: ");
        Console.WriteLine();
        school.ShowAll();

        Console.WriteLine();
        Console.WriteLine("Introducing All of them: ");
        school.IntroduceAll();
    }
}

class Person
{
    //fields
    private string _name;
    private int _age;
    private string _email;

    // Constructor
    public Person() : this("Unknown", 0, "invalid@email.com") { }
    public Person(string name, int age, string email)
    {
        this.Name = name;
        this.Age = age;
        this.Email = email;
    }
    // Properties
    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrEmpty(value) ? "Unknown" : value;
    }
    public int Age
    {
        get => _age;
        set => _age = (value >= 0 && value <= 120) ? value : 0;
    }
    public string Email
    {
        get => _email;
        set => _email = !string.IsNullOrEmpty(value) && value.Contains("@") ? value : "invalid@email.com";
    }


    public string Info => $"{Name} (Age: {Age})";
    public virtual void Introduce()
    {
        Console.WriteLine($"Hi, I am {Name}");
    }
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Name: {Name} | Age: {Age} | Email: {Email}");
    }

}
class Student : Person
{
    private double _gpa;

    public Student(string name, int age, string email, string id) : base(name, age, email)
    {
        StudentId = id;
    }

    public string StudentId { get; init; }
    public double GPA
    {
        get => _gpa;
        set => _gpa = (value >= 0.0 && value <= 4.0) ? value : 0.0;
    }

    public string Grade => (GPA >= 3.5) ? "A+" : (GPA >= 3.0) ? "A" : (GPA >= 2.5) ? "B" : "C";

    public override void Introduce()
    {
        base.Introduce();
        Console.WriteLine($"I am student. ID: {StudentId}, GPA: {GPA}, Grade: {Grade}");
    }

}

class Teacher : Person
{
    private string _subject;
    private decimal _salary;

    public Teacher(string name, int age, string email, string subject, decimal salary) : base(name, age, email)
    {
        Subject = subject;
        Salary = salary;
    }

    public string Subject
    {
        get => _subject;
        set => _subject = !string.IsNullOrEmpty(value) ? value : "General";
    }
    public decimal Salary
    {
        get => _salary;
        set => _salary = (value >= 10000) ? value : 10000;
    }

    public decimal MonthlySalary => Salary / 12;

    public override void Introduce()
    {
        base.Introduce();
        Console.WriteLine($"I teach {Subject}.");
    }

    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Subject: {Subject} | Monthly Salary: {MonthlySalary:N3}");
    }

}

class School
{
    private string _schoolName;
    private List<Student> _students;
    private List<Teacher> _teachers;

    public School(string schoolName)
    {
        _schoolName = schoolName;
        _students = new List<Student>();
        _teachers = new List<Teacher>();
    }

    public void AddStudent(Student s)
    {
        _students.Add(s);
        Console.WriteLine($"✅ Student {s.Name} added.");
    }

    public void AddTeacher(Teacher t)
    {
        _teachers.Add(t);
        Console.WriteLine($"✅ Teacher {t.Name} added.");
    }

    public void ShowAllStudents()
    {
        Console.WriteLine($"\n--- Students ({_students.Count}) ---");
        foreach (var s in _students)
            s.DisplayDetails();
    }

    public void ShowAllTeachers()
    {
        Console.WriteLine($"\n--- Teachers ({_teachers.Count}) ---");
        foreach (var t in _teachers)
            t.DisplayDetails();

    }

    public void ShowAll()
    {
        Console.WriteLine($"\n===== {_schoolName} =====");
        ShowAllStudents();
        ShowAllTeachers();
    }
    public void IntroduceAll()
    {
        List<Person> everyone = new List<Person>();
        everyone.AddRange(_students);   // ✅ Student is-a Person — কাজ করে!
        everyone.AddRange(_teachers);   // ✅ Teacher is-a Person — কাজ করে!

        foreach (Person p in everyone)
            p.Introduce();              // ✅ Polymorphism! নিজের version চলে
    }

}