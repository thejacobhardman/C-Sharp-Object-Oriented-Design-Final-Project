using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Object_Oriented_Design_Final_Project
{
    internal class School
    {
        public School(string name)
        {
            Name = name;
            Members = new List<User>(); // Polymorphism
            Courses = new List<Course>();
        }

        public string Name { get; }

        protected List<User> Members; // Encapsulation

        protected List<Course> Courses; // Encapsulation

        private static bool GetStudentRoles(User user)
        {
            return user.GetRole() == "student";
        }

        public List<User> GetStudents() // Polymorphism
        {
            List<User> students = new(Members.FindAll(GetStudentRoles));

            return students;
        }

        private static bool GetInstructorRoles(User user)
        {
            return user.GetRole() == "instructor";
        }

        public List<User> GetInstructors() // Polymorphism
        {
            List<User> instructors = new(Members.FindAll(GetInstructorRoles));

            return instructors;
        }

        public List<Course> GetCourses() { return Courses; } // Encapsulation

        public string DisplayCourses()
        {
            string courses = "";

            foreach (Course course in Courses)
            {
                courses += "\n" + course.GetId() + ". " + course.GetName();
            }

            return courses;
        }

        public void AddCourse(Course course) { Courses.Add(course); } // Encapsulation

        public void RemoveCourse(Course course) { Courses.Remove(course); } // Encapsulation
    }
}
