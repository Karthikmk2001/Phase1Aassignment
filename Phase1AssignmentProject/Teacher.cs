using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1AssignmentProject
{
    class Teacher
    {
        private int teacherId;
        private string teacherName;
        private string teacherClass;
        private char teacherSection;
        public Teacher()
        {
            this.teacherId = 0;
            this.teacherName = "X";
            this.teacherClass = "X";
            this.teacherSection = 'X';
        }
        public Teacher(int teacherId, string teacherName, string teacherClass, char teacherSection)
        {
            this.teacherId = teacherId;
            this.teacherName = teacherName;
            this.teacherClass = teacherClass;
            this.teacherSection = teacherSection;
        }

        public void UploadTeacherDetails()
        {
            int id;
            string name;
            string className;
            char section;
            try
            {
                Console.WriteLine("Enter Teacher Id:");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Teacher Name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter Teacher Class:");
                className = Console.ReadLine();
                Console.WriteLine("Enter Teacher Section:");
                section = char.Parse(Console.ReadLine());

                Teacher teacher = new Teacher(id, name, className, section);
                try
                {
                    string filePath = @"C:\Users\kmk\OneDrive - ALLEGIS GROUP\Documents\TRAINING\PRACTICE\Phase1AssignmentProject\Phase1AssignmentProject\Phase1AssignmentProject\TeacherData.txt";
                    if (File.Exists(filePath))
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine($"{teacher.teacherId}|{teacher.teacherName}|{teacher.teacherClass}|{teacher.teacherSection}");
                        File.AppendAllText(filePath, stringBuilder.ToString());

                    }
                    else
                    {
                        throw new FileNotFoundException("File does not exists");
                    }
                }
                catch (FileNotFoundException exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }

        public void DisplayAllTeacherDetails()
        {
            try
            {
                string filePath = @"C:\Users\kmk\OneDrive - ALLEGIS GROUP\Documents\TRAINING\PRACTICE\Phase1AssignmentProject\Phase1AssignmentProject\Phase1AssignmentProject\TeacherData.txt";
                if (File.Exists(filePath))
                {
                    string[] textFromFile = File.ReadAllLines(filePath);
                    Console.WriteLine("ID | NAME | CLASS | SECTION");
                    foreach (string line in textFromFile)
                    {
                        Console.WriteLine(line);
                    }

                }
            }
            catch (FileNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }

        public void DisplayTeacherDetails()
        {
            try
            {
                string filePath = @"C:\Users\kmk\OneDrive - ALLEGIS GROUP\Documents\TRAINING\PRACTICE\Phase1AssignmentProject\Phase1AssignmentProject\Phase1AssignmentProject\TeacherData.txt";
                if (File.Exists(filePath))
                {
                    int count = 0;
                    string name;
                    string[] singleTeacherData;
                    string[] textFromFile = File.ReadAllLines(filePath);
                    Console.WriteLine("Enter the Name of the Teacher you want to display the details:");
                    name = Console.ReadLine();
                    foreach (string line in textFromFile)
                    {
                        singleTeacherData = line.Split('|');
                        if (singleTeacherData[1] == name)
                        {
                            count++;
                            Console.WriteLine($"ID:{singleTeacherData[0]}\nNAME:{singleTeacherData[1]}\nCLASS:{singleTeacherData[2]}\nSECTION:{singleTeacherData[3]}");
                        }

                    }
                    if (count == 0)
                    {
                        Console.WriteLine($"No Data Exists of Teacher Named:{name}");
                    }
                }
                else
                {
                    throw new FileNotFoundException("File does not exists");
                }
            }
            catch (FileNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        public void UpdateTeacherDetails()
        {
            try
            {
                string filePath = @"C:\Users\kmk\OneDrive - ALLEGIS GROUP\Documents\TRAINING\PRACTICE\Phase1AssignmentProject\Phase1AssignmentProject\Phase1AssignmentProject\TeacherData.txt";
                if (File.Exists(filePath))
                {
                    Console.WriteLine("Enter the Name of the Teacher you want to update the details:");
                    String name = Console.ReadLine();
                    string[] singleTeacherData;
                    string[] textFromFile = File.ReadAllLines(filePath);
                    string newClass;
                    char newSection;
                    Teacher teacher = new Teacher();

                    foreach (string line in textFromFile)
                    {
                        singleTeacherData = line.Split('|');
                        if (singleTeacherData[1] == name)
                        {
                            int id = int.Parse(singleTeacherData[0]);
                            Console.WriteLine("Enter the new CLASS:");
                            newClass = Console.ReadLine();
                            Console.WriteLine("Enter the new SECTION:");
                            newSection = char.Parse(Console.ReadLine());
                            teacher=new Teacher(id, name, newClass, newSection);
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine($"{teacher.teacherId}|{teacher.teacherName}|{teacher.teacherClass}|{teacher.teacherSection}");
                            File.WriteAllText(filePath, stringBuilder.ToString());
                        }

                    }
                    foreach(string line in textFromFile)
                    {
                        singleTeacherData = line.Split('|');
                        if (singleTeacherData[1] != name)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.AppendLine($"{singleTeacherData[0]}|{singleTeacherData[1]}|{singleTeacherData[2]}|{singleTeacherData[3]}");
                            File.AppendAllText(filePath, stringBuilder.ToString());
                        }
                    }
                    
                }
            }
            catch (FileNotFoundException exp)
            {
                Console.WriteLine(exp.Message);
            }

        }
        class MainEntry
        {
            static void Main(string[] args)
            {
                //string filePath = @"C:\Users\kmk\OneDrive - ALLEGIS GROUP\Documents\TRAINING\PRACTICE\Phase1AssignmentProject\Phase1AssignmentProject\Phase1AssignmentProject\TeacherData.txt";

                Teacher t1 = new Teacher();
                int choice;
                string ch="";
                do
                {
                    Console.WriteLine("1.Enter New Teacher Details\n2.Display All Teacher Details\n3.Display Particular Teacher Details\n4.Update Particular Teacher Details");

                    Console.WriteLine("Enter your choice:");
                    choice = int.Parse(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:t1.UploadTeacherDetails();
                            break;
                        case 2: t1.DisplayAllTeacherDetails();
                            break;
                        case 3:t1.DisplayTeacherDetails();
                            break;
                        case 4:
                            t1.UpdateTeacherDetails();
                            break;
                        default:Console.WriteLine("Invalid Choice");
                            break;
                            

                    }
                    Console.WriteLine("Do you wish to continue(yes/no)?");
                    ch = Console.ReadLine();
                } while (ch == "yes" || ch == "YES");
            }
        }
    }
}
