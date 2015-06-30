using System;
using System.Collections.Generic;

namespace ModuleEight
{
    #region Classes
    //Person base class containing the first name and last name fields
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Person Constructor
        public Person(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }
    }
    //Student classes with encapsulated fields inherits from Person base class
    class Student : Person
    {
        public DateTime birthDate { get; set; }
        public double gpa { get; set; }
        public Stack<int> grades=new Stack<int>();//Using Generic Stack collection for grades

        //Student Constructor passing the first and last name to the base constructor
        public Student(string first, string last, DateTime birthday, double gpa)
            : base(first, last)
        {
            this.birthDate = birthday;
            this.gpa = gpa;
        }
        //Take Test method
        public void TakeTest()
        {
            Console.WriteLine("Student {0} {1} is taking a test.", this.FirstName, this.LastName);
            Console.WriteLine();
        }
        public void PrintGrades()
        {
            Console.Write("Student {0} {1} has the following grades: ", this.FirstName, this.LastName);
            foreach (int grade in grades)//Print grades from the stack
            {
                Console.Write(" {0}", grade);
            }
            Console.WriteLine();
        }
       
    }

    //Teacher class with encapsulated fields inherits from Person base class
    class Teacher : Person
    {
        public string Subject { get; set; }

        //Teacher Constructor passing the first and last name to the base constructor
        public Teacher(string first, string last, string Sub)
            : base(first, last)
        {
            this.Subject = Sub;
        }
        //Grade Test Method
        public void GradeTest()
        {
            Console.WriteLine("Teacher {0} {1} is grading a test.", this.FirstName, this.LastName);
            Console.WriteLine();
        }
    }

    //University Program class also has degree object field
    class UProgram
    {
        public string ProgName { get; set; }
        public Degree UDegree { get; set; }
        public string DeptHead { get; set; }

        //UProgram Constructor
        public UProgram(string progname, Degree degree, string depthead)
        {
            this.ProgName = progname;
            this.UDegree = degree;
            this.DeptHead = depthead;
        }
    }
    //Degree class also has a course object field
    class Degree
    {
        public string DegreeType { get; set; }
        public string DegreeName { get; set; }
        public Course DCourse { get; set; }
        public int YearsOfStudy { get; set; }

        //Degree Constructor
        public Degree(string dType, string dName, Course course, int yrs)
        {
            this.DegreeType = dType;
            this.DegreeName = dName;
            this.DCourse = course;
            this.YearsOfStudy = yrs;
        }
    }
    //Course class with course code, title, credits and two generic lists for student and teacher objects
    class Course
    {
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public List<Student> StudentList = new List<Student>();//Using generic list collection of type Student
        public List<Teacher> TeacherList = new List<Teacher>();//Using generic list collection of type Teacher
        public double CreditsEarned { get; set; }

        //Constructor for course initialises course code, title and credits. List items added after creating course object
        public Course(string title, string code, double credits)
        {
            this.CourseCode = code;
            this.CourseTitle = title;
            this.CreditsEarned = credits;
        }

        //List students method
        public void ListStudents()
        {
            foreach (Student studentobj in StudentList)//for each Student object in the Student list
            {
                Console.WriteLine("FirstName:Student {0} LastName: {1}", studentobj.FirstName, studentobj.LastName);
                Console.WriteLine();
            }
        }

    }
    #endregion

    #region Main
    //Main Program
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate 3 student objects and populate the grades stack
            Student student1 = new Student("John", "Hamm", new DateTime(2011, 12, 1), 3.5);
            //Populate the grades stack for student 1
            student1.grades.Push(91);
            student1.grades.Push(75);
            student1.grades.Push(84);
            student1.grades.Push(97);
            student1.grades.Push(89);
            student1.TakeTest();//Sample call to Take test method in Student class
            student1.PrintGrades();//sample call to print grades from the grades stack
            Student student2 = new Student("George", "Lucas", new DateTime(1995, 11, 5), 4.0);
            //Populate the grades stack for student 2
            student2.grades.Push(65);
            student2.grades.Push(72);
            student2.grades.Push(80);
            student2.grades.Push(77);
            student2.grades.Push(79);
            Student student3 = new Student("John", "Smith", new DateTime(1995, 07, 06), 3.0);
            //populate the grades stack for student 3
            student3.grades.Push(55);
            student3.grades.Push(60);
            student3.grades.Push(59);
            student3.grades.Push(72);
            student3.grades.Push(77);     
           
            //Instantiate Teacher object
            Teacher teacher1 = new Teacher("Jack", "Sparrow", "Computers");
            teacher1.GradeTest();//Sample call to Grade Test method in Teacher class
            //Instantiate a Course Object and add objects to the teacher generic List and student generic list
            Course course1 = new Course("Programming with C#", "Comp01", 3);
           //Populate Teacher list
            course1.TeacherList.Add(teacher1);   
            //Populate the Student List
            course1.StudentList.Add(student1);
            course1.StudentList.Add(student2);
            course1.StudentList.Add(student3);


            //Instantiate a degree object and add the course
            Degree degree1 = new Degree("Undergrad", "Bachelor of Science", course1, 4);

            //Instantiate a UProgram and add the degree
            UProgram program1 = new UProgram("Information Technology", degree1, "Greg Burns");

            //Display the Program name and the degree.
            Console.WriteLine("The {0} program contains the {1} degree.", program1.ProgName, program1.UDegree.DegreeName);
            Console.WriteLine();
            //Display the degree name and the course it contains
            Console.WriteLine("The {0} degree contains the course {1}.", degree1.DegreeName, degree1.DCourse.CourseTitle);
            Console.WriteLine();
            //Display the course title and the number of students
            Console.WriteLine("The {0} course contains {1} students.", course1.CourseTitle, course1.StudentList.Count);
            Console.WriteLine();

            //Call the List Student method for the course
            course1.ListStudents();           
            Console.ReadLine();
        }
    }
    #endregion
}
