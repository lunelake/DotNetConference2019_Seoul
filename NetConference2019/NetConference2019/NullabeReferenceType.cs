using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace NetConference2019
{
    public class NullabeReferenceType
    {
        public static void Demo()
        {
            var person = new Person("JongIn", "Lee");
            var middleLength = GetMiddleNameLength(person);
            Console.WriteLine($"중간 이름의 길이는 : {middleLength} 입니다.");
        }

        public static int GetMiddleNameLength(Person person)
        {
            return person.MiddleName.Length;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
        }
    }
}
