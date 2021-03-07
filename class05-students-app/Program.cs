using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace class05_students_app
{
    class Program
    {
        public static string filename = "\\students.txt";
        public static string directory = "C:\\Users\\" + Environment.UserName + "\\tmpData";
        public static string path = directory + filename;
        static void Main(string[] args)
        {
            ConsoleKeyInfo opt;
            do
            {
                ShowMenu();
                opt = Console.ReadKey(true);
                Console.Clear();
                switch (opt.Key)
                {
                    case ConsoleKey.D1: case ConsoleKey.NumPad1:
                        CreateStudent();
                        break;
                    case ConsoleKey.D2: case ConsoleKey.NumPad2:
                        ListStudents();
                        break;
                    case ConsoleKey.Escape:
                        Console.WriteLine("Vuelve Pronto");
                        Console.ReadKey();
                        break;
                    default:
                        break;

                }
            } while (opt.Key != ConsoleKey.Escape);
        }
        static void ShowMenu()
        {
            //menu
            CenterText("CONTROL DE ESTUDIANTES");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Curso: PROGRAMACIÓN I");
            Console.WriteLine("Nombre: Luis Eduardo Alvarado Celano");
            Console.WriteLine("Carnet: 0900-20-7376");
            Console.WriteLine("Sección: C");
            Console.WriteLine("\n");
            CenterText("-------------------------------------");
            CenterText("MENÚ PRINCIPAL");
            CenterText("-------------------------------------");
            CenterLeftText("(1). AGREGAR NUEVO ESTUDIANTE");
            CenterLeftText("(2). VER ESTUDIANTES REGISTRADOS");
            CenterLeftText("(Esc). SALIDA");
            CenterText("-------------------------------------");
            CenterText("ELIJA EL NÚMERO DE OPCIÓN [ ]");
            CenterText("-------------------------------------");

        }
        static void CreateStudent()
        {
            models.Students students = new models.Students();
            CenterText("INFORMACIÓN A COMPLETAR DEL ESTUDIANTE");
           
            Console.SetCursorPosition(20, 7); Console.WriteLine("---------------------------------------------------------------------");
            Console.SetCursorPosition(20, 8); Console.WriteLine("DATOS GENERALES");
            Console.SetCursorPosition(20, 9); Console.WriteLine("---------------------------------------------------------------------");
            Console.SetCursorPosition(20, 10); Console.WriteLine("ID DEL ALUMNO:       [____________________________________________]");
           // Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(52, 10);
            students.SetId(Console.ReadLine());
            Console.SetCursorPosition(20, 11); Console.WriteLine("NOMBRE DEL ALUMNO:   [____________________________________________]");
            //Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(52, 11);
            students.SetName(Console.ReadLine());
            Console.SetCursorPosition(20, 12); Console.WriteLine("DIRECCIÓN DEL ALUMNO:[____________________________________________]");
           // Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(52, 12);
            students.SetAddress(Console.ReadLine());
            Console.SetCursorPosition(20, 13); Console.WriteLine("EDAD DEL ALUMNO:     [____________________________________________]");
           // Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(52, 13);
            students.SetAge(Console.ReadLine());
            Console.SetCursorPosition(20, 15); Console.WriteLine("---------------------------------------------------------------------");
            Console.SetCursorPosition(20, 16); Console.WriteLine("DATOS ESPECÍFICOS");
            Console.SetCursorPosition(20, 17); Console.WriteLine("---------------------------------------------------------------------");
            Console.SetCursorPosition(20, 18); Console.WriteLine("CARRERA UNIVERSITARIA:[____________________________________________]");
            //Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(52, 18);
            students.SetCarrier(Console.ReadLine());
            Console.SetCursorPosition(20, 19); Console.WriteLine("SEMESTRE:             [___________________________________________]");
           // Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(52, 19);
            students.SetSemester(Console.ReadLine());
            try
            {
                if (!Directory.Exists(directory))
                {
                   DirectoryInfo di = Directory.CreateDirectory(directory);
                }
                if (!File.Exists(path))
                {
                    using StreamWriter stream = File.CreateText(path);
                    stream.WriteLine(students.GetLine());
                    stream.Close();
                }
                else
                {
                    using StreamWriter stream = File.AppendText(path);
                    stream.WriteLine(students.GetLine());
                    stream.Close();
                }
                Console.SetCursorPosition(20, 20); Console.WriteLine("---------------------------------------------------------------------");
                Console.SetCursorPosition(20, 21); Console.WriteLine("ALUMNO INGRESADO CORRECTAMENTE");
                Console.SetCursorPosition(20, 22); Console.WriteLine("---------------------------------------------------------------------");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void ListStudents()
        {
            CenterText("LISTADO DE ESTUDIANTES");
            try
            {
                if (!File.Exists(path)) throw new Exception("No existe un listado de estudiantes aún");
                string[] students = File.ReadAllLines(path);
                if (students.Length == 0) throw new Exception("No hay estudiantes registrados");
                Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 6); Console.WriteLine("ID");
                Console.SetCursorPosition(15, 6); Console.WriteLine("NOMBRE");
                Console.SetCursorPosition(35, 6); Console.WriteLine("EDAD");
                Console.SetCursorPosition(55, 6); Console.WriteLine("DIRECCION");
                Console.SetCursorPosition(75, 6); Console.WriteLine("SEMESTRE");
                Console.SetCursorPosition(95, 6); Console.WriteLine("CARRERA UNIVERSITARIA");
                Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 8);
                int curPos = 9;
                foreach (string student in students)
                {
                    models.Students studentModel = new models.Students();
                    string[] delimitedStudent = student.Split(",");
                    studentModel.SetAll(delimitedStudent);
                    Console.SetCursorPosition(5, curPos); Console.WriteLine(studentModel.GetId());
                    Console.SetCursorPosition(15, curPos); Console.WriteLine(studentModel.GetName());
                    Console.SetCursorPosition(35, curPos); Console.WriteLine(studentModel.GetAge());
                    Console.SetCursorPosition(55, curPos); Console.WriteLine(studentModel.GetAddress());
                    Console.SetCursorPosition(75, curPos); Console.WriteLine(studentModel.GetSemester());
                    Console.SetCursorPosition(95, curPos); Console.WriteLine(studentModel.GetCarrier());
                    curPos++;
                }
                Console.SetCursorPosition(5, curPos); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
            }

        }
        static void CenterText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
        /// <summary>
        /// Centra el texto al centro agregando un margen izquierdo de 0 
        /// </summary>
        /// <param name="text"></param>
        static void CenterLeftText(string text)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + text.Length - 15) + "}", text));
        }
    }
}
