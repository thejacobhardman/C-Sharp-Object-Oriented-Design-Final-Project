using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Object_Oriented_Design_Final_Project
{
    internal class Student : User, IStudent // Inheritance/Interfaces
    {
        public Student()
        {
            FirstName = "placeholder";
            LastName = "placeholder";
            Role = "placeholder";
            ID = 0;
            Courses = new List<Course>();
            Grades = new List<Grade>();
            GPA = 0.0;
        }

        public Student(string firstName, string lastName, string role, int id): base(firstName, lastName, role)
        {
            FirstName = firstName; // Inheritance
            LastName = lastName; // Inheritance
            Role = role; // Inheritance
            ID = id;
            Courses = new List<Course>();
            Grades = new List<Grade>();
            GPA = 0.0;
        }

        protected int ID; // Encapsulation

        protected List<Course> Courses; // Encapsulation

        protected List<Grade> Grades; // Encapsulation

        protected double GPA; // Encapsulation

        public int GetId() { return ID; } // Encapsulation

        public List<Grade> GetGrades() { return Grades; } // Encapsulation

        public double GetGrade(Course course)
        {
            Grade selectedGrade = new();
            foreach (Grade grade in Grades)
            {
                if (grade.GetCourse() == course)
                {
                    selectedGrade = grade;
                    break;
                }
            }
            return selectedGrade.GetGrade();
        }

        public double GetGPA() { return GPA; } // Encapsulation

        public void AddGrade(Grade newGrade) { Grades.Add(newGrade); }

        public double CalculateGPA()
        {
            GPA = 0.0;

            foreach (Grade grade in Grades)
            {
                GPA += grade.GetGrade();
            }

            GPA /= Grades.Count;

            return GPA;
        }

        public void AddCourse(Course course) { 
            //course.AddStudent(this); 
            Courses.Add(course);
        } // Interfaces

        public void DropCourse(Course course) { 
            //course.RemoveStudent(this);
            Courses.Add(course);
        } // Interfaces
    }
}
