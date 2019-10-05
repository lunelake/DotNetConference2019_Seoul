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

        public static void ApiSomething(Person? person)
        {
            if(person is null)
            {
                Console.WriteLine("Person 데이터가 제대로 안들어왔어. 오류 처리해야지.");
                return;
            }

            var length = person.GetMiddleNameLength();
            Console.WriteLine($"길이는 {length}다");
        }

        public static Person? Person { get; set; }

        public static void ReferenceSomething()
        {
            Person?.GetMiddleNameLength();
        }

        public void Dispose()
        {
            Person = null;
        }

        static int GetMiddleNameLength(Person person)
        {

            if (IsNotNull(person.MiddleName))
                return person.MiddleName.Length;
            return 0;
        }

        static bool IsNotNull([NotNullWhen(true)] string? value) => !string.IsNullOrEmpty(value);
   
    }

    public class Person
    {
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string LastName { get; set; }

        public Person(string first, string last)
        {
            FirstName = first;
            MiddleName = null;
            LastName = last;
        }

        public int GetMiddleNameLength()
        {
            //if (MiddleName is null) return 0;
            return MiddleName?.Length??0;
        }
    }
}
