namespace C_Sharp_Object_Oriented_Design_Final_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            School UNC = new("University of Northern Colorado");

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the " + UNC.Name + "'s management system.");
                Console.WriteLine("Please make a selection below.");

                bool validSelection = false;
                while (!validSelection)
                {
                    Console.WriteLine("\n1. Enter a new course. \n2. Enter a new student. \n3. Remove a student. \n4. Remove a course. \n5. Enter a student's grade. \n6. Display grade analytics. \n7. Quit.");
                    Console.Write("\nSelection: ");
                    string selection = Console.ReadLine();

                    // Add a new course
                    if (selection == "1")
                    {
                        Console.Clear();

                        Course newCourse = new();
                        string courseName = "";
                        int courseId = 0;
                        bool validCourse = false;
                        while (!validCourse)
                        {
                            Console.Write("Please enter the name of the course: ");
                            courseName = Console.ReadLine();
                            Console.Write("\nPlease enter the ID number of the course: ");
                            courseId = int.Parse(Console.ReadLine());

                            if (UNC.GetCourses().Count != 0)
                            {
                                bool courseFound = false;
                                foreach (Course course in UNC.GetCourses())
                                {
                                    if (course.GetId() == courseId)
                                    {
                                        Console.WriteLine("A course with that ID already exists. Please enter a valid ID number.");
                                        courseFound = true;
                                    }
                                }
                                if (!courseFound) { validCourse = true; }
                            } else
                            {
                                validCourse = true;
                            }
                        }
                        newCourse = new(courseName, courseId);

                        UNC.AddCourse(newCourse);

                        Console.WriteLine("\nSuccessfully added " + newCourse.GetName() + " to the list of courses with an ID number of " + newCourse.GetId());

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        validSelection = true;
                    } 
                    // Add a new student to a course
                    else if (selection == "2")
                    {
                        Console.Clear();
                        List<Course> courses = UNC.GetCourses();
                        Console.WriteLine(UNC.DisplayCourses());

                        if (courses.Count != 0)
                        {
                            bool validCourse = false;
                            Course selectedCourse = new();
                            while (!validCourse)
                            {
                                Console.Write("\nPlease select which course you would like to add a student to: ");
                                int courseID = int.Parse(Console.ReadLine());

                                foreach (Course course in courses)
                                {
                                    if (course.GetId() == courseID)
                                    {
                                        selectedCourse = course;
                                        validCourse = true;
                                    }
                                }

                                if (!validCourse) { Console.WriteLine("Could not find a course with that ID. Please enter a valid course ID."); }
                            }

                            Console.Write("\nPlease enter the student's ID number: ");
                            int studentID = int.Parse(Console.ReadLine());

                            Console.Write("\nPlease enter the student's first name: ");
                            string studentFirstName = Console.ReadLine();

                            Console.Write("\nPlease enter the student's last name: ");
                            string studentLastName = Console.ReadLine();

                            selectedCourse.AddStudent(new Student(studentFirstName, studentLastName, "student", studentID));

                            Console.WriteLine("\nSuccessfuly added " + studentFirstName + " " + studentLastName + " to the course " + selectedCourse.GetName() + " with an ID number of " + studentID + ".");
                        } else
                        {
                            Console.WriteLine("There are not currently any courses saved in the database.");
                        }

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        validSelection = true;
                    } 
                    // Remove a student from a course
                    else if (selection == "3")
                    {
                        Console.Clear();
                        List<Course> courses = UNC.GetCourses();
                        Console.WriteLine(UNC.DisplayCourses());

                        if (courses.Count != 0)
                        {
                            bool validCourse = false;
                            Course selectedCourse = new();
                            while (!validCourse)
                            {
                                Console.Write("\nPlease select which course you would like to remove a student from: ");
                                int courseID = int.Parse(Console.ReadLine());

                                foreach (Course course in courses)
                                {
                                    if (course.GetId() == courseID)
                                    {
                                        selectedCourse = course;
                                        validCourse = true;
                                    }
                                }

                                if (!validCourse) { Console.WriteLine("Could not find a course with that ID. Please enter a valid course ID."); }
                            }

                            List<Student> students = selectedCourse.GetStudents();
                            Console.WriteLine(selectedCourse.DisplayStudents());
                            bool validStudent = false;
                            Student selectedstudent = new();
                            while (!validStudent)
                            {
                                Console.Write("\nPlease select which student you would like to remove from this course: ");
                                int studentID = int.Parse(Console.ReadLine());

                                foreach (Student student in students)
                                {
                                    if (student.GetId() == studentID)
                                    {
                                        selectedstudent = student;
                                        validStudent = true;
                                    }
                                }

                                if (!validStudent) { Console.WriteLine("Could not find a student with that ID. Please enter a valid student ID."); }
                            }

                            selectedCourse.RemoveStudent(selectedstudent);

                            Console.WriteLine("\nSuccessfully removed " + selectedstudent.GetFirstName() + " " + selectedstudent.GetLastName() + " from " + selectedCourse.GetName() + ".");
                        } else
                        {
                            Console.WriteLine("There are not currently any courses saved in the database.");
                        }

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        validSelection = true;
                    } 
                    // Remove a course
                    else if (selection == "4")
                    {
                        Console.Clear();
                        List<Course> courses = UNC.GetCourses();
                        Console.WriteLine(UNC.DisplayCourses());

                        if (courses.Count != 0)
                        {
                            bool validCourse = false;
                            Course selectedCourse = new();
                            while (!validCourse)
                            {
                                Console.Write("\nPlease select which course you would like to remove: ");
                                int courseID = int.Parse(Console.ReadLine());

                                foreach (Course course in courses)
                                {
                                    if (course.GetId() == courseID)
                                    {
                                        selectedCourse = course;
                                        validCourse = true;
                                    }
                                }

                                if (!validCourse) { Console.WriteLine("Could not find a course with that ID. Please enter a valid course ID."); }
                            }

                            selectedCourse.RemoveAllStudents();
                            UNC.RemoveCourse(selectedCourse);

                            Console.WriteLine("\nSuccessfully removed " + selectedCourse.GetName() + ".");
                        } else
                        {
                            Console.WriteLine("There are not currently any courses in the database.");
                        }

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        validSelection = true;
                    } 
                    // Enter a student's grade
                    else if (selection == "5")
                    {
                        Console.Clear();
                        List<Course> courses = UNC.GetCourses();
                        Console.WriteLine(UNC.DisplayCourses());

                        if (courses.Count != 0)
                        {
                            bool validCourse = false;
                            Course selectedCourse = new();
                            while (!validCourse)
                            {
                                Console.Write("\nPlease select which course you would like to enter a stuident's grade for: ");
                                int courseID = int.Parse(Console.ReadLine());

                                foreach (Course course in courses)
                                {
                                    if (course.GetId() == courseID)
                                    {
                                        selectedCourse = course;
                                        validCourse = true;
                                    }
                                }

                                if (!validCourse) { Console.WriteLine("Could not find a course with that ID. Please enter a valid course ID."); }
                            }

                            List<Student> students = selectedCourse.GetStudents();
                            Console.WriteLine(selectedCourse.DisplayStudents());
                            bool validStudent = false;
                            Student selectedstudent = new();
                            while (!validStudent)
                            {
                                Console.Write("\nPlease select which student you would like to enter a grade for: ");
                                int studentID = int.Parse(Console.ReadLine());

                                foreach (Student student in students)
                                {
                                    if (student.GetId() == studentID)
                                    {
                                        selectedstudent = student;
                                        validStudent = true;
                                    }
                                }

                                if (!validStudent) { Console.WriteLine("Could not find a student with that ID. Please enter a valid student ID."); }
                            }

                            Console.Write("\nPlease enter the student's grade (0-100): ");
                            double studentGrade = double.Parse(Console.ReadLine());

                            Grade newGrade = new Grade(studentGrade, selectedCourse);
                            if (selectedstudent.GetGrades().Contains(newGrade))
                            {
                                selectedstudent.GetGrades().Remove(newGrade);
                                selectedstudent.AddGrade(newGrade);
                            }
                            else
                            {
                                selectedstudent.AddGrade(newGrade);
                            }

                            Console.WriteLine("\nSuccessfully saved " + selectedstudent.GetFirstName() + " " + selectedstudent.GetLastName() + "'s grade in " + selectedCourse.GetName() + " as " + selectedstudent.GetGrade(selectedCourse));
                        } else
                        {
                            Console.WriteLine("There are not currently any courses saved in the database.");
                        }

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        validSelection = true;
                    } 
                    // View grade analytics
                    else if (selection == "6")
                    {
                        // Getting list of grades
                        List<Grade> studentGrades = new();
                        foreach (Student student in UNC.GetStudents())
                        {
                            foreach (Grade grade in student.GetGrades())
                            {
                                studentGrades.Add(grade);
                                Console.WriteLine(grade);
                            }
                        }
                        studentGrades.Sort();

                        double averageStudentGrade = 0.0;
                        double minStudentGrade = 0.0;
                        double maxStudentGrade = 0.0;
                        double medianStudentGrade = 0.0;
                        double percentageOfAGrades = 0.0;
                        double percentageOfBGrades = 0.0;
                        double percentageOfCGrades = 0.0;
                        double percentageOfDGrades = 0.0;
                        double percentageOfFGrades = 0.0;

                        if (studentGrades.Count() != 0)
                        {
                            // Calculating average grade
                            foreach (Grade grade in studentGrades)
                            {
                                averageStudentGrade += grade.GetGrade();
                            }
                            averageStudentGrade /= UNC.GetStudents().Count();

                            // Calculating largest grade
                            maxStudentGrade = studentGrades.Last().GetGrade();
                            // Calculating smallest grade
                            minStudentGrade = studentGrades.First().GetGrade();

                            // Calculating median grade
                            int middleGrade = studentGrades.Count / 2;
                            medianStudentGrade = studentGrades.ElementAt(middleGrade).GetGrade();

                            // Calculating percentage of A grades
                            foreach (Grade grade in studentGrades)
                            {
                                if (grade.GetGrade() >= 90.0)
                                {
                                    percentageOfAGrades++;
                                }
                            }
                            percentageOfAGrades /= UNC.GetStudents().Count();
                            percentageOfAGrades *= 100;

                            // Calculating percentage of B grades
                            foreach (Grade grade in studentGrades)
                            {
                                if (grade.GetGrade() < 90.0 && grade.GetGrade() >= 80.0)
                                {
                                    percentageOfBGrades++;
                                }
                            }
                            percentageOfBGrades /= UNC.GetStudents().Count();
                            percentageOfBGrades *= 100;

                            // Calculating percentage of C grades
                            foreach (Grade grade in studentGrades)
                            {
                                if (grade.GetGrade() < 80.0 && grade.GetGrade() >= 70.0)
                                {
                                    percentageOfCGrades++;
                                }
                            }
                            percentageOfCGrades /= UNC.GetStudents().Count();
                            percentageOfCGrades *= 100;

                            // Calculating percentage of D grades
                            foreach (Grade grade in studentGrades)
                            {
                                if (grade.GetGrade() < 70.0 && grade.GetGrade() >= 60.0)
                                {
                                    percentageOfDGrades++;
                                }
                            }
                            percentageOfDGrades /= UNC.GetStudents().Count();
                            percentageOfDGrades *= 100;

                            // Calculating percentage of F grades
                            foreach (Grade grade in studentGrades)
                            {
                                if (grade.GetGrade() < 60.0)
                                {
                                    percentageOfFGrades++;
                                }
                            }
                            percentageOfFGrades /= UNC.GetStudents().Count();
                            percentageOfFGrades *= 100;
                        } else
                        {
                            Console.WriteLine("No grades found in the database.");
                        }

                        // Displaying the grade analytics
                        Console.Clear();
                        Console.WriteLine(studentGrades.Count());
                        Console.WriteLine("Displaying " + UNC.Name + "'s grade analytics.");

                        Console.WriteLine("\n----------------\n");

                        Console.WriteLine("Average Student Grade: " + averageStudentGrade);
                        Console.WriteLine("Minimum Student Grade: " + minStudentGrade);
                        Console.WriteLine("Maximum Student Grade: " + maxStudentGrade);
                        Console.WriteLine("Median Student Grade: " + medianStudentGrade);
                        Console.WriteLine("Percentage of A Grades: " + percentageOfAGrades + "%");
                        Console.WriteLine("Percentage of B Grades: " + percentageOfBGrades + "%");
                        Console.WriteLine("Percentage of C Grades: " + percentageOfCGrades + "%");
                        Console.WriteLine("Percentage of D Grades: " + percentageOfDGrades + "%");
                        Console.WriteLine("Percentage of F Grades: " + percentageOfFGrades + "%");

                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();
                        validSelection = true;
                    } 
                    // Quit the program
                    else if (selection == "7")
                    {
                        validSelection = true;
                        isRunning = false;
                    } 
                    // The user did not select a valid option
                    else
                    {
                        Console.WriteLine("\nPlease enter a valid selection.");
                    }
                }
            }

            Console.WriteLine("Press any key to close the program.");
            Console.ReadKey();
        }
    }
}