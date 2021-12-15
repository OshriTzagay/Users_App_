using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_App
{
    public class User : IComparable
    {
        string firstName;
        string lastName;
        string email;
        int birthYear;
        public User(string firstName, string lastName, string email, int birthYear)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.birthYear = birthYear;
        }
        public User() { }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Email { get { return email; } set { email = value; } }
        public int BirthYear { get { return birthYear; } set { birthYear = value; } }

        public string printInfo()
        {
            return $"First Name : {this.FirstName}\n" +
                $"Last Name : {this.LastName}\n" +
                $"Email : {this.Email}\n" +
                $"Born in : {this.BirthYear}";
        }

        public int CompareTo(object obj)
        {
            User someUser = (User)obj;
            if (someUser.BirthYear > this.BirthYear)
            {
                return 1;
            }
            if (someUser.BirthYear < this.BirthYear)
            {
                return -1;
            }
            return 0;
        }

        public static void UsersEntry(List<User> theList)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Welcome To my Users App :)");

                Console.WriteLine("Gimmie User Name..");
                string UserFName = Console.ReadLine();
                Console.WriteLine("Gimmie User Last Name ");
                string UserLastName = Console.ReadLine();
                Console.WriteLine("Gimmie User Email ");
                string UserEmail = Console.ReadLine();
                Console.WriteLine("Gimmie User Birth Year");
                int UserBirthYear = int.Parse(Console.ReadLine());

                User user = new User(UserFName, UserLastName, UserEmail, UserBirthYear);

                theList.Add(user);

                theList.Sort();


            }
            foreach (User user in theList)
            {
                Console.WriteLine($"{user.FirstName}, {user.LastName}, {user.Email},{user.BirthYear}");
            }

        }
    }
}