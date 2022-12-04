using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Object_Oriented_Design_Final_Project
{
    internal class Instructor : User // Inheritance
    {
        public Instructor(string firstName, string lastName, string role): base(firstName, lastName, role)
        {
            FirstName = firstName; // Inheritance
            LastName = lastName; // Inheritance
            Role = role; // Inheritance
            Courses = new List<Course>();
        }

        protected List<Course> Courses; // Encapsulation

        public List<Course> GetCourses() { return Courses; } // Encapsulation

        public void AssignToCourse(Course course)
        {
            course.AssignInstructor(this);
            Courses.Add(course);
        }

        public void DropCourse(Course course)
        {
            course.RemoveInstructor();
            Courses.Remove(course);
        }
    }
}
