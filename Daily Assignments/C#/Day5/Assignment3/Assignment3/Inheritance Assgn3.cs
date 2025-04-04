using System;

namespace Assignment3
{
    class Inheritance_Assgn3
    {
        //    static void Main(string[] args)
        //    {
        //        Console.WriteLine("Enter Student Details:");

        //        Console.Write("Roll No: ");
        //        int rollNo = Convert.ToInt32(Console.ReadLine());

        //        Console.Write("Name: ");
        //        string name = Console.ReadLine();

        //        Console.Write("Class: ");
        //        string studentClass = Console.ReadLine();

        //        Console.Write("Semester: ");
        //        int semester = Convert.ToInt32(Console.ReadLine());

        //        Console.Write("Branch: ");
        //        string branch = Console.ReadLine();

        //        Student student = new Student(rollNo, name, studentClass, semester, branch);

        //        student.GetMarks();

        //        Console.WriteLine("\n--- Student Information ---");
        //        student.DisplayData();

        //        Console.WriteLine("\n--- Result ---");
        //        student.DisplayResult();

        //        Console.ReadLine();
        //    }
        //}

        class Student
        {
            int rollNo;
            string name;
            string studentClass;
            int semester;
            string branch;
            int[] marks = new int[5];

            public Student(int rollNo, string name, string studentClass, int semester, string branch)
            {
                this.rollNo = rollNo;
                this.name = name;
                this.studentClass = studentClass;
                this.semester = semester;
                this.branch = branch;
            }
            public void GetMarks()
            {
                Console.WriteLine("\nEnter marks for 5 subjects:");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write("Subject " + (i + 1) + ": ");
                    marks[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            public void DisplayResult()
            {
                int total = 0;
                bool failed = false;

                for (int i = 0; i < 5; i++)
                {
                    if (marks[i] < 35)
                    {
                        failed = true;
                    }
                    total += marks[i];
                }

                double average = total / 5.0;

                if (failed)
                {
                    Console.WriteLine("Result: Failed (One or more subjects < 35)");
                }
                else if (average < 50)
                {
                    Console.WriteLine("Result: Failed (Average < 50)");
                }
                else
                {
                    Console.WriteLine("Result: Passed");
                }
            }
            public void DisplayData()
            {
                Console.WriteLine("Roll No     : " + rollNo);
                Console.WriteLine("Name        : " + name);
                Console.WriteLine("Class       : " + studentClass);
                Console.WriteLine("Semester    : " + semester);
                Console.WriteLine("Branch      : " + branch);

                Console.Write("Marks       : ");
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(marks[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
