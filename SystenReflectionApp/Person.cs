using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystenReflectionApp
{
    interface IMovable
    {
        void Move();
    }

    interface ISleeper
    {
        void Sleep();
    }
    internal class Person : IMovable, ISleeper
    {
        int var;
        public string Name { get; set; } = "";
        public int Age { set; get; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        public void Print(int a)
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        void PrintPrivate()
        {
            Console.WriteLine($"Private. Name: {Name}, Age: {Age}");
        }

        public void Move()
        {
            Console.WriteLine("Move");
        }

        public void Sleep()
        {
            Console.WriteLine("Sleep");
        }

        public override string ToString()
        {
            return $"Private. Name: {Name}, Age: {Age}";
        }

        virtual public void Send(out double x, in string s, FileInfo info)
        {
            x = 100.0;
        }

        public Action action;
    }
}
