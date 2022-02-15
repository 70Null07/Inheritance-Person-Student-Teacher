using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Создать иерархию классов Каждый класс должен содержать свойства а также вирутальную функцию
// Print() и переопределенную функцию ToString() Основная программа должна создавать массив
// объектов Person или их наследников после чего выдавать их на экран. у каждого объекта Teacher должен
// быть список объектов класса Students, которыми он руководит, у каждого объекта класса Student - объект класса
// Teacher


namespace ConsoleApplication1
{
    public class Person : System.Object
    {
        protected int age;
        protected string name, surname;

        public Person()
        {
            age = 0;
            name = default;
            surname = default;
        }

        public Person(int _age, string _name, string _surname)
        {
            age = _age;
            name = _name;
            surname = _surname;
        }

        public Person(Person _Person)
        {
            age = _Person.age;
            name = _Person.name;
            surname = _Person.surname;
        }

        public virtual void Print()
        {
            Console.WriteLine("Person NAME and SURNAME {0} {1} and AGE is {2}", name, surname, age);
        }

        public virtual void Scan()
        {
            Console.WriteLine("\t\t Input age(number): ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("\t\t Input name and surname(string): ");
            name = Console.ReadLine();
            surname = Console.ReadLine();
        }

        public override bool Equals(object obj)
        {
            Person temp = (Person) obj;
            if (temp.age == age && temp.name == name && temp.surname == name)
            {
                return true;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return age.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("[FirstName = {0}", name);
            sb.AppendFormat(" Surname = {1}", surname);
            sb.AppendFormat(" Age = {2}]", age);
            return sb.ToString();
        }
    }

    public class Student : Person
    {
        private bool univers_place;
        private double avg_mark;
        private string group;
        private string teacher;

        public Student() : base ()
        {
            univers_place = default;
            avg_mark = default;
            group = default;
            teacher = default;
        }

        public Student(string _teacher, bool _univers_place, double _avg_mark, string _group, int _age, string _name, string _surname)
        : base (_age, _name, _surname)
        {
            univers_place = _univers_place;
            avg_mark = _avg_mark;
            group = _group;
            teacher = _teacher;
        }

        public string Teacher
        {
            get
            {
                return teacher;
            }
            set
            {
                teacher = value;
            }
        }
        public override void Print()
        {
            Console.WriteLine("[Student's First name = {0}, Surname = {1}," +
                " Age = {2}, Univers place is {3}, Average mark = {4}," +
                " and Group = {5}", name, surname, age, univers_place, avg_mark, group);
        }

        public override void Scan()
        {
            base.Scan();
            Console.WriteLine("\t\t Input univers place(bool): ");
            univers_place = bool.Parse(Console.ReadLine());
            Console.WriteLine("\t\t Input average mark(number): ");
            avg_mark = double.Parse(Console.ReadLine());
            Console.WriteLine("\t\t Input group(string): ");
            group = Console.ReadLine();
            Console.WriteLine("\t\t Input teacher's surname(string): ");
            teacher = Console.ReadLine();
        }

        public void SetGroup()
        {
            group = Console.ReadLine();
        }

        public void SetAverage()
        {
            avg_mark = double.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" [Univers place = {0}", univers_place);
            sb.AppendFormat(" Avg. mark = {1}", avg_mark);
            sb.AppendFormat(" Group = {2}]", group);
            return base.ToString() + sb.ToString();
        }
    }

    public class Teacher : Person
    {
        private List<Student> list_students;
        private string position;
        private int seniority;

        public Teacher() : base()
        {
            position = default;
            seniority = 0;
            list_students = new List<Student>();
        }

        public Teacher(string _position, int _seniority, int _age, string _name, string _surname)
            : base(_age, _name, _surname)
        {
            position = _position;
            seniority = _seniority;
            list_students = new List<Student>();
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public override void Print()
        {
            Console.WriteLine("[Teacher's First name = {0}, Surname = {1}," +
                " Age = {2}, Position is {3}, Seniority = {4}]", name, surname, age, position, seniority);
            Console.WriteLine();
            Console.WriteLine("I have this students: ");
            foreach (var student in list_students)
            {
                student.Print();
                Console.WriteLine();
            }
        }

        public override void Scan()
        {
            base.Scan();
            Console.WriteLine("\t\t Input position(string): ");
            position = Console.ReadLine();
            Console.WriteLine("\t\t Input seniority(number): ");
            seniority = int.Parse(Console.ReadLine());
        }

        public void SetPosition()
        {
            position = Console.ReadLine();
        }

        public void SetSeniority()
        {
            seniority = int.Parse(Console.ReadLine());
        }

        public void AddStudent(Student student)
        {
           list_students.Add(student);
        }

        public bool RemoveStudent(Student student)
        {
            return list_students.Remove(student);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" [Position = {0}", position);
            sb.AppendFormat(" Senoirity = {1}]", seniority);
            return base.ToString() + sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)

        {
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();
            string usr_inp;
            //students.Add(new Student("BOND",true,4.89,"BPI20-02",22,"Alex", "Samuel"));
            //students.Add(new Student("BOND",true, 3.67, "BPI17-02", 25, "Max", "April"));
            //students.Add(new Student("Split",true, 5.00, "BPI21-02", 19, "Alise", "June"));
            //students.Add(new Student("Text",false, 2.11, "BPI22-02", 18, ".NET6", ".0"));

            //teachers.Add(new Teacher("Proffecor",35,62,"JAMES","BOND"));
            //teachers.Add(new Teacher("Docent", 20, 45, "Line", "Split"));
            //teachers.Add(new Teacher("Docent", 12, 41, "Default", "Text"));

            //for (int i = 0; i <= students.Count - 1; i++)
            //{
            //    for (int j = 0; j <= teachers.Count - 1; j++)
            //    {
            //        if (teachers[j].Surname == students[i].Teacher)
            //        {
            //            teachers[j].AddStudent(students[i]);
            //        }
            //    }
            //}
            //foreach (var teacher1 in teachers)
            //{
            //    teacher1.Print();
            //}
            //Console.ReadLine();

            do
            {
                Console.WriteLine("\t\t\t 1. Add new student \n\t\t\t 2. Add new teacher \n\t\t\t 3. Update relationships Teacher-Student \n\t\t\t 4. Print Teachers with every student \n\t\t\t 5. Exit");
                try
                {
                    usr_inp = Console.ReadLine();
                    switch (int.Parse(usr_inp))
                    {
                        case 1:
                            {
                                Student temp = new Student();
                                temp.Scan();
                                students.Add(temp);
                                Console.WriteLine("\t\t\t Student successfully added!");
                            }
                            break;
                        case 2:
                            {
                                Teacher temp = new Teacher();
                                temp.Scan();
                                teachers.Add(temp);
                                Console.WriteLine("\t\t\t Teacher successfully added!");
                            }
                            break;
                        case 3:
                            {
                                for (int i = 0; i <= students.Count - 1; i++)
                                {
                                    for (int j = 0; j <= teachers.Count - 1; j++)
                                    {
                                        if (teachers[j].Surname == students[i].Teacher)
                                        {
                                            teachers[j].AddStudent(students[i]);
                                        }
                                    }
                                }
                                Console.WriteLine("\t\t\t Relationships successfully updated!");
                            }
                            break;
                        case 4:
                            {
                                foreach (var teacher1 in teachers)
                                {
                                    teacher1.Print();
                                }
                            }
                            break;
                        case 5:
                            return;
                        default:
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    Console.ReadLine();
                }
                    
            }
            while (true);
        }
    }
}
