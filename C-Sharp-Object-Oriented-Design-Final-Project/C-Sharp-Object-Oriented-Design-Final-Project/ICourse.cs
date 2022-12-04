using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace C_Sharp_Object_Oriented_Design_Final_Project
{
    internal interface ICourse // Interfaces
    {
        public string GetName();

        public int GetId();

        public List<Student> GetStudents();

        public void AddStudent(Student newStudent);

        public void RemoveStudent(Student student);
    }
}
