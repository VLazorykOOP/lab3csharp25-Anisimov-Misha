using System;

class Person
{
    protected string name;
    protected int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public virtual void Show()
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }

    public virtual int CompareTo(Person other)
    {
        return this.age.CompareTo(other.age);
    }
}

class Student : Person
{
    private string faculty;
    private int year;

    public Student(string name, int age, string faculty, int year) : base(name, age)
    {
        this.faculty = faculty;
        this.year = year;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Faculty: {faculty}, Year: {year}");
    }

    public override int CompareTo(Person other)
    {
        if (other is Student student)
        {
            return this.year.CompareTo(student.year);
        }
        return base.CompareTo(other);
    }
}

class Teacher : Person
{
    private string department;
    private string specialization;

    public Teacher(string name, int age, string department, string specialization) : base(name, age)
    {
        this.department = department;
        this.specialization = specialization;
    }
    
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Department: {department}, Specialization: {specialization}");
    }

    public override int CompareTo(Person other)
    {
        if (other is Teacher teacher)
        {
            return this.department.CompareTo(teacher.department);
        }
        return base.CompareTo(other);
    }
}

class DepartmentHead : Teacher
{
    private int experienceYears;

    public DepartmentHead(string name, int age, string department, string specialization, int experienceYears)
        : base(name, age, department, specialization)
    {
        this.experienceYears = experienceYears;
    }

    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Experience: {experienceYears} years");
    }

    public override int CompareTo(Person other)
    {
        if (other is DepartmentHead departmentHead)
        {
            return this.experienceYears.CompareTo(departmentHead.experienceYears);
        }
        return base.CompareTo(other);
    }
}

class Program
{
    static void FillArray(Person[] persons)
    {
        persons[0] = new Student("John Doe", 20, "Computer Science", 2);
        persons[1] = new Teacher("Jane Smith", 40, "Mathematics", "Algebra");
        persons[2] = new DepartmentHead("Mark Johnson", 50, "Physics", "Quantum Mechanics", 10);
        persons[3] = new Student("Alice Brown", 22, "Biology", 3);
        persons[4] = new Teacher("Michael Davis", 35, "Chemistry", "Organic Chemistry");
    }

    static void Main()
    {
        try
        {
            Person[] persons = new Person[5];
            FillArray(persons);
            Console.WriteLine("Information about people:");
            foreach (var person in persons)
            {
                person.Show();
                Console.WriteLine();
            }
            Array.Sort(persons, (p1, p2) => p1.CompareTo(p2));
            Console.WriteLine("Sorted information:");
            foreach (var person in persons)
            {
                person.Show();
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
