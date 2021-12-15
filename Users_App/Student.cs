using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Users_App
{
    public class Student : User
    {

        public string studentClass;

        public string StudentClass
        {
            get { return studentClass; }
            set { studentClass = value; }
        }
        public Student() { }
        public Student(string firstName, string lastName, string email, int birthYear, string studentClass) : base(firstName, lastName, email, birthYear)
        {
            this.studentClass = studentClass;
        }

        public string printStudInfo()
        {
            return $"{base.printInfo()}\nGrade:{this.studentClass}";
        }

    }
}
