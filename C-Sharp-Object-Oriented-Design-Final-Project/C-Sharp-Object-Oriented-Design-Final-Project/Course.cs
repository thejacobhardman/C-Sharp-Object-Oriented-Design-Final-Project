using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Object_Oriented_Design_Final_Project
{
    internal class Course : ICourse // Inheritance/Interfaces
    {
        public Course()
        {
            Name = "Placeholder";
            Id = 0;
            Students = new List<Student>();
        }

        public Course(string name, int id)
        {
            Name = name;
            Id = id;
            Students = new List<Student>();
        }

        protected string Name; // Encapsulation

        protected int Id; // Encapsulation

        protected Instructor? Instructor; // Encapsulation

        protected List<Student> Students; // Encapsulation

        public string GetName() { return Name; } // Encapsulation

        public int GetId() { return Id; } // Encapsulation

        public Instructor? GetInstructor() { 
            if (Instructor != null) { return Instructor; }
            else
            {
                Console.WriteLine("This course does not currently have an instructor assigned to teach it.");
                return null;
            }
        } // Encapsulation

        public List<Student> GetStudents() { return Students; } // Encapsulation

        public string DisplayStudents()
        {
            string students = "";

            foreach (Student student in Students)
            {
                students += "\n" + student.GetId() + ". " + student.GetFirstName() + " " + student.GetLastName();
            }

            return students;
        }

        public void AssignInstructor(Instructor newInstructor) { Instructor = newInstructor; } // Encapsulation

        public void RemoveInstructor() { Instructor = null; } // Encapsulation

        public void AddStudent(Student newStudent) { 
            Students.Add(newStudent);
            newStudent.AddCourse(this);
        } // Encapsulation

        public void RemoveStudent(Student student) { 
            Students.Remove(student);
            student.DropCourse(this);
        } // Encapsulation

        public void RemoveAllStudents()
        {
            Students.Clear();
        }
    }
}
