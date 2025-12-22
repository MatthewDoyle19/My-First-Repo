using System;
using System.Collections.Generic;

class Person
{
    private string name;
    private int age;

    public Person()
    {
        name = "Unknown";
        age = 0;
    }
    
    public Person(string Name, int Age)
    {
        name = Name;
        age = Age;
    }

    public string Name1
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public int Age1
    {
        get { return age; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Incorrect age");
            }
            age = value;
        }
    }

    public virtual void Display()
    {
        Console.WriteLine($"Name: {Name1}");
        Console.WriteLine($"Age: {Age1}");
    }
}

class Student : Person
{
    private int Id;
    private double Grade;

    public Student()
    {
        Id = 1;
        Grade = 0;
    }
    
    public Student(int id,string name, int age, double grade) : base(name, age)
    {
        Id = id;
        Grade = grade;
    }

    public int Id1
    {
        get { return Id; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Id cannot be negative"); 
            }
            Id = value;
        }
    }

    public double Grade1
    {
        get { return Grade; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Grade cannot be negative"); 
            }
            Grade = value;
        }
    }

    public override void Display()
    {  
        Console.WriteLine($"Id: {Id1}");
        Console.WriteLine($"Name: {Name1}");
        Console.WriteLine($"Age: {Age1}");
        Console.WriteLine($"Grade: {Grade1}");
        Console.WriteLine("--------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Student Management System!");
        
        List<Student> Students = new List<Student>();
        
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("---------------------------------------");
           
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Display Students");
            Console.WriteLine("3. Exit");
            
            Console.WriteLine("Choose an option:");
             int choice = Convert.ToInt32(Console.ReadLine());
             
            Console.WriteLine("---------------------------------------");
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("How Many Students You Want To Enter Their Info?");
                    int Num = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < Num; i++)
                    {
                        Student st = new Student();
                        
                         Console.WriteLine($"Enter Student {i + 1} ID ");
                         st.Id1 = Convert.ToInt32(Console.ReadLine());
                         
                         Console.WriteLine($"Enter Student {i + 1} Name "); 
                         st.Name1 = Console.ReadLine();
                         
                         Console.WriteLine($"Enter Student {i + 1} Age ");
                         st.Age1 = Convert.ToInt32(Console.ReadLine());
                         
                         Console.WriteLine($"Enter Student {i + 1} Grade ");
                         st.Grade1 = Convert.ToDouble(Console.ReadLine());
                         
                         Students.Add(st);
                         Console.WriteLine("Student added successfully!");
                         Console.WriteLine("--------------------------");
                    }
                    break;
                
                case 2:
                    if (Students.Count == 0)
                    {
                        Console.WriteLine("No Students Found");
                    }
                    else
                    { 
                        foreach (Student st in Students)
                        { 
                            st.Display(); 
                        }
                    }
                    break;
                
                case 3:
                    exit = true;
                    break;
                
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
        
        Console.WriteLine("Thank you for using the Student Management System. Goodbye!");
    }
}