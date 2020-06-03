using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp13
{
    delegate void Welcome(string lastname, string firstname);
    delegate void End(string lastname);

    interface IPeople
    {
        void PrintPeople();
        void PrintSport();
    }

    public class InfoPeople
    {
        public static int Number = 0;
        public int Id { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private int Age { get; set; }

        public string FName
        {
            get
            {
                return FirstName;
            }
            set
            {
                FirstName = value;
            }
        }

        public string LName
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }

        public int age
        {
            get
            {
                return Age;
            }
            set
            {
                Age = value;
            }
        }

        public InfoPeople(string firstName, string lastName, int age)
        {
            Number++;
            Id = Number;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    public class SportMan
    {
        protected InfoPeople People;
        public string NameSport { get; }

        public SportMan(string FirstName, string LastName, int Age, string nameSport)
        {
            People = new InfoPeople(FirstName, LastName, Age);
            NameSport = nameSport;
        }

        public void PrintMan()
        {
            Console.WriteLine("Surname: " + People.LName);
            Console.WriteLine("Name: " + People.FName);
            Console.WriteLine("Age: " + People.age);
            Console.WriteLine("Name sport: " + NameSport);
        }

        public string GetLastName() => People.LName;

        public string GetFirstName() => People.FName;

        delegate void MessageHandler(string message);

        public void Show()
        {
            try
            {
                throw new ArgumentException("Произошла ошибка");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            ShowMessage("Привет!", (string mes) => Console.WriteLine(mes));
        }

        static void ShowMessage(string mes, MessageHandler handler)
        {
            handler(mes + " пользователь");
        }
    }

    interface ISpecialist
    {
        string SelectedJob { get; }
        int Exp { get; }
    }

    class Specialist : SportMan, ISpecialist, IPeople, IComparable<Specialist>
    {
        public string SelectedJob { get; }
        public int Exp { get; set; }

        public Specialist(string FirstName, string LastName, int Age, string nameSport, string selectedJob, int exp)
            : base(FirstName, LastName, Age, nameSport)
        {
            SelectedJob = selectedJob;
            Exp = exp;
        }

        public int CompareTo(Specialist obj)
        {
            return this.Exp.CompareTo(obj.Exp);
        }

        public void PrintPeople()
        {
            Console.WriteLine(People.FName + " " + People.FName + " " + People.age);
        }

        public void PrintSport()
        {
            Console.WriteLine(NameSport);
        }

        public void Print()
        {
            Console.WriteLine(People.Id + "" + People.FName + " " + People.FName + " " + People.age + " " + SelectedJob + " " + Exp);
        }
    }



    class Program
    {
        static void Hello(string lastName, string firstName)
        {
            Console.WriteLine($"Привет, {lastName} {firstName}");
        }

        static void Bay(string lastName, string firstName)
        {
            Console.WriteLine($"Пока, {lastName} {firstName}");
        }

        static void Main(string[] args)
        {
            Specialist specialist = new Specialist("Михальцов", "Данила", 21, "Борьба", "Программист", 1);
            Specialist specialist1 = new Specialist("Стас", "Ананас", 19, "Футбол", "Повар", 4);

            specialist.Print();
            specialist1.Print();
            specialist.PrintPeople();
            specialist.PrintSport();

            Welcome welcome = Hello;
            welcome += Bay;
            welcome(specialist.GetLastName(), specialist.GetFirstName());

            End handler = delegate (string str)
            {
                Console.WriteLine("Пока " + str);
            };

            handler(specialist.GetLastName());

            specialist.Show();
            Console.ReadKey();
        }
    }
}