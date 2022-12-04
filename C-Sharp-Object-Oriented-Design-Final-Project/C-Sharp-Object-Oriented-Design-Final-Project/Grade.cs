using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Object_Oriented_Design_Final_Project
{
    internal class Grade
    {
        public Grade()
        {
            Value = 0.0;
            Course = new Course();
        }

        public Grade(double value)
        {
            Value = value;
            Course = new Course();
        }

        public Grade (Course course)
        {
            Value = 0.0;
            Course = course;
        }

        public Grade (double value, Course course)
        {
            Value = value;
            Course = course;
        }

        protected double Value; // Encapsulation

        protected Course Course; // Encapsulation

        public double GetGrade() { return Value; } // Encapsulation

        public Course GetCourse() { return Course; } // Encapsulation
    }
}
